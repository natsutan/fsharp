#load "../../FsLab.Templates-basic/packages/FsLab/FsLab.fsx"

open System
open System.IO
open MathNet.Numerics
open MathNet.Numerics.LinearAlgebra
open MathNet.Numerics.LinearAlgebra.Double
open MathNet.Numerics.LinearRegression
open XPlot.GoogleCharts

let tof (t : string) = float t

let rows = File.ReadAllLines("C:\\home\\myproj\\fsharp\\FS_for_ML\\chap2\\data\\mpg.csv")
           |> Array.map(fun t -> t.Split(',') |> Array.toSeq |> Seq.take 6 |> Seq.toArray |> Array.map tof)
           |> Array.toSeq
           |> Seq.take 350
           |> Seq.toArray

let created1 = DenseMatrix.OfRowArrays rows
let milePerGallon = created1.Column 0
let created2 = created1.RemoveColumn 0
let Y_MPG = milePerGallon

let tau = 1.

let unknownCarDetails = vector [4.;140.;90.;2264.;15.5]
let values = [|for i in 0 .. 349 -> (created2.Row i).Subtract(unknownCarDetails).L2Norm() / (2. * tau ** 2.) |]

let weightedMPG = DiagonalMatrix.ofDiagArray values

let Theta_MPG = (created2.Transpose() * weightedMPG * created2).Inverse() * created2.Transpose() * weightedMPG * milePerGallon

let predictedMPG = Theta_MPG * unknownCarDetails

// Graph
let mpgPairs = [|for i in 0 .. 349 -> (i, milePerGallon.At(i)) |]
let predeictedMPGPairs = [|for i in 0 .. 349 -> (i, Theta_MPG * created2.Row(i))|]
let mpgResidual = [| for i in 0 .. 349 -> (milePerGallon.At(i),
                                           Theta_MPG * created2.Row(i),
                                           milePerGallon.At(i) - Theta_MPG * created2.Row(i)) |]

let mpgResidualPair = [|for i in 0 .. 349 -> (i, abs(milePerGallon.At(i) - Theta_MPG * created2.Row(i))) |]

let graph = ["scatter"; "lines" ; "bars"]
[mpgPairs;  predeictedMPGPairs; mpgResidualPair]
|> Chart.Combo
|> Chart.WithOptions 
     (Options(series = [| for typ in graph -> Series(typ) |]))
