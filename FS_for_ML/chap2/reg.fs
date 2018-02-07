#load "../../FsLab.Templates-basic/packages/FsLab/FsLab.fsx"
open System
open FSharp.Data
open MathNet.Numerics.LinearRegression
open MathNet.Numerics.Fit

let xV =  [|14.;16.;27.;42.;39.;50.;83.|]
let yV = [|02.;05.;07.;09.;10.;13.;20.|]

let (b0, b1) = SimpleRegression.Fit(xV, yV)

