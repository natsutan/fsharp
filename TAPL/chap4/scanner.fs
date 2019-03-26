module Scanner

open Logger

type TokenType =
    CAMMA
    | RIGHT_PAREN 
    | LEFT_PAREN 
    | TRUE
    | FALSE
    | IF
    | THEN
    | ELSE
    | ZERO
    | SUCC
    | PRED
    | ISZERO

type Token = {token_type :TokenType; line :int; pos :int ; str :string; src_line :string}

let private c_to_s(c :char) :string = sprintf "%O" c
let private is_letter(c :char) :bool = System.Char.IsLetter(c)

let rec private scan_word(s:string) :string = 
    let len = String.length s
    if len <= 1 then
        s
    else
        let c1 = s.[1]
        if not (is_letter c1) then 
            s.[0..0]
        else
            s.[0..0] + scan_word s.[1..len-1]

let private scan_line(l :string) : (string * int) List  =
    let mutable result : (string * int) List = []
    let mutable p = 0
    let len = (String.length l)

    while p < len do
        let ch = l.[p]
        match ch with
        | ';' | '(' | ')' | '0' ->
            let token :string = c_to_s ch
            result <- result @ [(token, p)]
        | ' ' | '\n' -> ()
        | _  when is_letter ch -> 
            let w = scan_word(l.[p..len-1])            
            result <- result @ [(w, p)]
            // この下で1必ず1増やすので先に引いておく
            p <- p + String.length w - 1

        | _ -> failwithf "Scan error %s pos %d" l p

        p <- p + 1
           
    result 
    
let s_to_token(word_info:string * int, src:string, line_num:int):Token =
    let word = fst word_info
    let pos = snd word_info

    match word with 
    | ";" ->  {token_type = CAMMA; line = line_num; pos = pos; str = ""; src_line = src}
    | ")" ->  {token_type = RIGHT_PAREN; line = line_num; pos = pos; str = ""; src_line = src}
    | "(" ->  {token_type = LEFT_PAREN; line = line_num; pos = pos; str = ""; src_line = src}
    | "true" ->  {token_type = TRUE; line = line_num; pos = pos; str = ""; src_line = src}
    | "false" ->  {token_type = FALSE; line = line_num; pos = pos; str = ""; src_line = src}
    | "if" ->  {token_type = IF; line = line_num; pos = pos; str = ""; src_line = src}
    | "then" ->  {token_type = THEN; line = line_num; pos = pos; str = ""; src_line = src}
    | "else" ->  {token_type = ELSE; line = line_num; pos = pos; str = ""; src_line = src}
    | "0" -> {token_type = ZERO; line = line_num; pos = pos; str = ""; src_line = src}
    | "succ" -> {token_type = SUCC; line = line_num; pos = pos; str = ""; src_line = src}
    | "pred" -> {token_type = PRED; line = line_num; pos = pos; str = ""; src_line = src}
    | "iszero" -> {token_type = ISZERO; line = line_num; pos = pos; str = ""; src_line = src}
    | _ -> failwithf "Unkown token \"%s\" :%s (line %d pos %d)" word src line_num pos

 
type Scanner(source :string, logger:Logger.Logger) =
    //propertiy
    let mutable line = 0
    let source = source
    let mutable tokens : Token List = []
    let mutable logger = logger
    do
        let st = new System.IO.StreamReader(source)
        let data = st.ReadToEnd().Replace("\r\n", "\n")
        let source_lines = data.Split('\n') 
        printfn "read %A, %A lines" source (Array.length source_lines)

        let mutable line_num = 0
        for src_line in source_lines do
            //変換用の関数定義
            let fn(s) = s_to_token(s, src_line, line_num)

            let scan = scan_line src_line
            let token_list = List.map fn scan
            tokens <- List.append tokens token_list
            line_num <- line_num + 1

    member x.print_source() = printfn "%A" source
    member x.Tokens with get() = tokens
        



