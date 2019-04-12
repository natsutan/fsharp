module Parser
open Logger
open Scanner

type Term =
    TmTrue
    | TmFalse
    | TmIf of Term * Term * Term
    | TmZero
    | TmSucc of Term
    | TmPred of Term
    | TmIsZero of Term
    | TmComma
    | TmDummy

let paser_err_string(token:Token):string = 
    let src = "\t" + token.src_line + "\n"
    let src_info = sprintf "\tline %d\n" token.line
    let mutable pos_str = "\t"
    for i = 1 to token.pos do
        pos_str <- pos_str + " "

    let err_str = src_info + src + pos_str + "^\n"
    err_str

type Parser(logger:Logger.Logger) =
    let logger = logger
    let mutable asts: Term List = []
    let mutable pos = 0

    member x.parse(tokens: Token List) =
        let len = List.length tokens
        while pos < len do
            let term, consume_tokens = x.parse_term(tokens.[pos..])
            asts <- asts @ [term]
            pos <- pos + consume_tokens
            let num = x.sync(tokens.[pos], [CAMMA])
            pos <- pos + num
        asts

    member x.parse_term(tokens: Token List):Term * int =
        let token = tokens.Head
        let t = token.token_type
        match t with
        | CAMMA | RIGHT_PAREN -> 
            let msg1 = sprintf "illegal token %O" t
            let msg2 = paser_err_string token
            logger.Log(msg1+msg2, Logger.LogLevel.ERROR)
            TmDummy, 1                
        | LEFT_PAREN  -> 
            let t, num1 = x.parse_term(tokens.[1..])
            let next_token = tokens.[num1+1]
            let num2 = x.sync(tokens.[num1+1], [RIGHT_PAREN])
            t, num1 + num2 + 1
        | TRUE -> TmTrue, 1
        | FALSE -> TmFalse, 1
        | ZERO -> TmZero, 1
        | IF -> TmDummy, 1
        | THEN -> TmDummy, 1
        | ELSE -> TmDummy, 1
        | SUCC -> 
            let t, num = x.parse_term(tokens.[1..])
            TmSucc(t), num + 1
        | PRED -> 
            let t, num = x.parse_term(tokens.[1..])
            TmPred(t), num + 1
        | ISZERO -> TmDummy, 1


    member x.sync(token: Token, sync_list) : int  =

        if List.contains token.token_type sync_list then
            1
        else        
            let msg1:string = sprintf "%O not found\n" sync_list
            let msg2 = paser_err_string token
            logger.Log(msg1+msg2, Logger.LogLevel.ERROR)
            1


