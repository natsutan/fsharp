// F# の詳細については、http://fsharp.org を参照してください
// 詳細については、'F# チュートリアル' プロジェクトを参照してください。

open XPlot.GoogleCharts
let z = [for i in -10. .. 10. -> (i,1./(1.+exp -i))]
let options =
  Options
    ( title = "Sigmoid Function", curveType = "function",
      legend = Legend(position = "bottom") )

let chart = z |> Chart.Line |> Chart.WithOptions options |> Chart.WithLabels ["g(z)"]



let a = 10

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // 整数の終了コードを返します
