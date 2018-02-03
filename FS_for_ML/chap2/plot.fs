#load "../../FsLab.Templates-basic/packages/FsLab/FsLab.fsx"
open System
open FSharp.Data
open XPlot.GoogleCharts

let x =  [14.;16.;27.;42.;39.;50.;83.]
let y = [02.;05.;07.;09.;10.;13.;20.]

let b1 = 0.243756371049949 
let b0 = -0.00828236493374135 

let regressionPairs = x |> List.map ( fun xElem -> (xElem, b0 + b1* float xElem ))
let pairs = List.zip x y
  
let series = ["scatter"; "lines" ]
[pairs; regressionPairs]
|> Chart.Combo
|> Chart.WithOptions 
     (Options(series = [| for typ in series -> Series(typ) |]))





