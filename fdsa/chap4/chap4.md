Are We there wet
-------
##  Diving deep into enumerations and sequences

シーケンス<seq 'T>と'T seqは、generic type 'T のIEnumerable<'T>である。

.NET frameworkクラスライブラリでは, IEnumerable<'T>は、コレクションをイテレートするenumratorをさらすインターフェイスを定義している。
インターフェイスあh、型との関係を提供し、 attributesとmethodの集まりである。
実際のインターフェイスの実装は、それを実装するクラスの中にある。

seq<'T>は別名で、ほかの.NETの IEnumerable<とコンパチブルである。
新しいシーケンスは簡単に定義できる。
```
let countToTen = seq { 1..10 }
```
評価はデフォルトで遅延である。

```
let intExp = 
  seq { 
    for i in 0..999 do
      yield i
  }
```  

```
let intExp = 
  seq { 
      for i in 0..999 -> i
  }
```
yeildは->で置き換えられる。 要素ではなくシーケンスをyeildしたいときは、yeild!を使う。  

Seq.initは、最初のパラメーターにシーケンスの個数、次にジェネレータを記述することでシーケンスを生成する。
```
let integers = Seq.init 1000 (fun i -> i + 1)  
val integers : seq<int>
```

Seq.initInfinite は無限シーケンスを生成する。  

Seq.iterはシーケンスのイテレータを生成する。
```
seq { 0..9 } |> Seq.iter (printfn "%i")
```  

To fold or not to fold, this is a very functional question.   
foldの動作は、Seqモジュールが提供する別のサービスです。foldメソッドは、入力としてシーケンス、二つの引数をとる関数、signatureに出てくる初期値をとる。

```
Seq.fold : ('State -> 'T -> 'State) -> 'State -> seq<'T> -> 'State 
```  
'State -> 'T -> 'Stateは、シーケンスからそれぞれの要素の状態を更新する関数を表す。
このStateは初期値を表し、seq<'T>は入力のシーケンスを示す。

```
seq { 1 .. 100 } |> Seq.fold (fun x y -> x + y) 0;;
```

