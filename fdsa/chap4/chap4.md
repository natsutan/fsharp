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

