#load "../../FsLab.Templates-basic/packages/FsLab/FsLab.fsx"
open System
open FSharp.Data
open XPlot.GoogleCharts
open MathNet.Numerics.LinearRegression
open MathNet.Numerics.Fit

let genRandomTemps count =
  let rnd = System.Random()
  List.init count (fun _ -> rnd.Next (40, 100))
  
let temps = genRandomTemps 50
let t_d = 19

let RH_Formula = temps |> List.map (fun t -> float ((100 - 5 * (t - t_d))))
let temp_Array = temps |> List.map (fun t -> float t)


let from_Formula = Array.zip (List.toArray temp_Array) (List.toArray RH_Formula)
let (rhb0, rhb1) = SimpleRegression.Fit from_Formula

let regressionPairs = temp_Array |> List.map (fun t -> (t, rhb0, rhb1 * t))
                     
let formulaSpots   = from_Formula
let regressionLine = regressionPairs

let chart = ["scatter"; "lines" ]
[formulaSpots; regressionLine]
|> Chart.Combo
|> Chart.WithOptions 
     (Options(series = [| for typ in series -> Series(typ) |]))
