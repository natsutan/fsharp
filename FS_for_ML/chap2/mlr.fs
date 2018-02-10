#load "../../FsLab.Templates-basic/packages/FsLab/FsLab.fsx"

open System
open System.IO
open MathNet.Numerics
open MathNet.Numerics.LinearAlgebra
open MathNet.Numerics.LinearAlgebra.Double

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

//シータの計算
let theta_MPG = (created2.Transpose() * created2).Inverse() * created2.Transpose() * milePerGallon

let unkownCarDetails = vector [4.;140.;90.;2264.;15.5]

let predictMPG = theta_MPG * unkownCarDetails
