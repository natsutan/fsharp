// F# の詳細については、http://fsharp.org を参照してください
// 詳細については、'F# チュートリアル' プロジェクトを参照してください。
open Scanner

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
    if Array.length argv <> 1 then
        printfn "Usage:mipple sourefile"
        exit 1
    
    let source_file = argv.[0]
    let scaner = Scanner.Scanner(source_file) 

    scaner.print_source()
            
    printfn "%A" argv
    
    //if len(argv) <> 1 then
        
    

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
