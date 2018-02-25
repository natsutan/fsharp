// F# の詳細については、http://fsharp.org を参照してください
// 詳細については、'F# チュートリアル' プロジェクトを参照してください。

open NUnit.Framework
open stack

[<Test>]
let stack_basic_test() =
    let s = stack.Stack<int>();
    s.Push 5
    Assert.AreEqual(5, s.Pop)

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // 整数の終了コードを返します
