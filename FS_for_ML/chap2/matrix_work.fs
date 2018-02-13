#load "../../FsLab.Templates-basic/packages/FsLab/FsLab.fsx"

open System
open System.IO
open MathNet.Numerics
open MathNet.Numerics.LinearAlgebra
open MathNet.Numerics.LinearAlgebra.Double
open MathNet.Numerics.LinearRegression

let Q = matrix [ [0.8;-0.099]
                 [0.6; 0.132]
                 [0. ; 0.986]]

let Qt = Q.Transpose()

let b = matrix [[10.;8.;6.]]

let Qtb = Qt * b.Transpose()

let x1 = 5.982 / 6.08

let x0 = (12.8 - (x1 * 2.)) / 10.
