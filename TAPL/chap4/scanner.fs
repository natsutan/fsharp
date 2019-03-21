module Scanner

open System.Threading

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
    | PREV

type Token = {token_type :TokenType; line :int; pos :int ; str :string}


type Scanner(source :string) =
    //propertiy
    let mutable line = 0
    let source = source
    let mutable tokens : Token List = []
    do
        let st = new System.IO.StreamReader(source)
        let data = st.ReadToEnd().Replace("\r\n", "\n")
        let source_lines = data.Split('\n') 
        printfn "read %A, %A lines" source (Array.length source_lines)

        for source_line in source_lines do
            let words = source_line.Split(' ')


            line <- line + 1

    member x.print_source() = printfn "%A" source
        


let private scan_line(l :string) : (string * int) array  =
    let mutable result : (string * int) List = []
    let mutable word = ""
    let mutable p = 0
    for c in l do
        match c with 
        | ';' | '(' | ')'  ->
            let token :string = sprintf "%O" c
            result <- result @ [(token, p)]
        | ' ' | '\n' -> ()
        | _  when System.Char.IsLetter(c) -> printfn "%O" c
        | _ -> failwithf "Scan error %d %c" p c

        p <- p + 1
           
    let arr = List.toArray result 
    arr
