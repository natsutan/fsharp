# QR decomposition of a matrix  
## 分解
一般的な線形回帰モデルの計算は、その行列の逆行列を探す必要がある。QRやSVD分解はそれを助ける。  

QR分解は、行列をQとRの違う行列に分解する。

$$
{\bf {X }} = {\bf {Q }} \begin{vmatrix}  {\bf {R} \\ 0 \\ \end{vmatrix}
$$  

参考
http://zellij.hatenablog.com/entry/20120524/p1  


```fsharp
let y = matrix [ [1.;2.;3.]  
                 [4.;5.;6.]
                 [7.;8.;9.]]
let qr = y.QR()  
printfn "Q = %A" qr.Q  
printfn "R = %A" qr.R  
```  
実行結果  
```
Q = DenseMatrix 3x3-Double  
-0.123091   0.904534  -0.408248  
-0.492366   0.301511   0.816497  
 -0.86164  -0.301511  -0.408248  

R = DenseMatrix 3x3-Double  
-8.12404  -9.60114     -11.0782  
       0  0.904534      1.80907
       0         0  -1.9984E-15
```

## SVD of a matrix  
```fsharp
let svdr = y.Svd(true)
printfn "S = %A" svdr.S
printfn "VT = %A" svdr.VT
printfn "U = %A" svdr.U
printfn "W = %A" svdr.W
```
SVDとQR分解によって、逆行列を求めずに線形回帰を実行できる。


