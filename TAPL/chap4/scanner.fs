module scanner

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

type Token = {ttype: TokenType; line: int; pos :int; str: string}


type Scanner(source) =
    class
        let source = source
        

    end

