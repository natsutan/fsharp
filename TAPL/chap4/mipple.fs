// F# の詳細については、http://fsharp.org を参照してください
// 詳細については、'F# チュートリアル' プロジェクトを参照してください。
open Logger
open Scanner
open Parser

//let TmTrue = true
//let TmFalse = false
//let TmZero = 0


[<EntryPoint>]
let main argv =
    if Array.length argv <> 1 then
        printfn "Usage:mipple sourefile"
        exit 1
    
    let logger = Logger.Logger()

    let source_file = argv.[0]
    let scaner = Scanner.Scanner(source_file, logger) 
    
    let parser = Parser.Parser(logger)
    let asts = parser.parse(scaner.Tokens)
    printfn "%A" asts

            
        
    

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
