module Parser
open Logger
open Scanner

type Term =
    TmTrue of Token
    | TmFalse of Token
    | TmIf of Term * Term * Term
    | TmZero of Token
    | TmSucc of Token * Term
    | TmPred of Token * Term
    | TmIsZero of Token * Term
    | TmDummy


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
        asts

    member x.parse_term(tokens: Token List):Term * int =
        TmDummy, 1
    
