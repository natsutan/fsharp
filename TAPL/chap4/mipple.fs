// F# の詳細については、http://fsharp.org を参照してください
// 詳細については、'F# チュートリアル' プロジェクトを参照してください。

let TmTrue = true
let TmFalse = false
let TmZero = 0


type term =
    TmTrue 
    | TmFalse
    | TmIf of term * term * term
    | TmZero
    | TmSucc of term
    | TmPred of term
    | TmIsZero of term

let rec isnumericalval (t:term) :bool =
    match t with
    | TmZero -> true
    | TmSucc (t1) -> isnumericalval t1
    | TmPred (t1) -> isnumericalval t1    
    | _ -> false
    


[<EntryPoint>]
let main argv =
    let zero = TmZero 
    let one = TmSucc(zero)
    let two = TmSucc(one)
    let one_ = TmPred(two)

    let T = TmTrue
    let F = TmFalse
    
    
    printfn "Is zero numeric? %A" (isnumericalval zero)
    printfn "Is one numeric? %A" (isnumericalval one)
    printfn "Is two numeric? %A" (isnumericalval two)
    printfn "Is one_ numeric? %A" (isnumericalval one_)
    printfn "Is true numeric? %A" (isnumericalval T)
    printfn "Is false numeric? %A" (isnumericalval F)

    // sample
    // let scaner = Scan(file)
    // let parser = Parser(scanner)
    // let ast = Parser.parse()
    
    // let mipple = InterPreter()
    // let val = mipple.eval(ast)
    // for ast in Parser.parse_line()
    //     val = miiple.eval(ast)
    //     printfn "%A" val
    
    0 // 整数の終了コードを返します
