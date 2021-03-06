﻿open MathNet.Numerics.LinearAlgebra
open System.IO

//https://archive.ics.uci.edu/ml/machine-learning-databases/auto-mpg/auto-mpg.data
//let data_file = "C:\\home\\myproj\\fsharp\\FS_for_ML\\chap2\\data\\auto-mpg.data"
//let rows = File.ReadAllLines(data_file)
//               |> Array.map ( fun t -> t.Split(',') |> Array.map(fun t -> float t))

//行列
let y = matrix [ [1.;2.;3.]
                 [4.;5.;6.]
                 [7.;8.;9.]]

printfn "%A" y

let y' = y.Transpose()

printfn "%A" y'

let y1 = matrix [ [1.;2.;3.]
                  [4.;5.;6.]
                  [7.;0.8;9.]]

let y1' = y1.Inverse()

printfn "%A" y1'

let y1t = y1'.Trace()

printfn "%A" y1t

let qr = y.QR()

printfn "Q = %A" qr.Q
printfn "R = %A" qr.R

let svdr = y.Svd(true)
printfn "S = %A" svdr.S
printfn "VT = %A" svdr.VT
printfn "U = %A" svdr.U
printfn "W = %A" svdr.W


open System
open FSharp.Data
open MathNet.Numerics.LinearRegression
open MathNet.Numerics.Fit

let xV =  [|14.;16.;27.;42.;39.;50.;83.|]
let yV = [|02.;05.;07.;09.;10.;13.;20.|]

let (b0, b1) = SimpleRegression.Fit(xV, yV)

[<EntryPoint>]
let main argv = 
    printfn "b1 = %A, b0 = %A\n" b1 b0
    0 // 整数の終了コードを返します
