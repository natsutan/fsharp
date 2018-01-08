Introducing Functional Programming
---

# starting with number and strings
シンプルな型

| type         | description           | Sample         | Long name      |
| *----        | ----                  | ----           | ----           |
| bool         | true/false            | true, false    | System.Boolean |
| Int/int32    | 32bit整数             | 0, 19, 0x123   | System.Int32   |
| float/double | 64bit浮動小数点演算数 | 0.3, 1.3e4     | System.Double  |
| string       | ユニコード文字列      | "abc", @"\a\n" | System.String  |
| unit         | 一つの値しかとらない  | ()             | System.Unit    |


引数と戻り値に型の制約をつける。
```fsharp
let squareAndAdd a b = a * a + b
//> val squareAndAdd : a:int -> b:int -> int

let squareAndAdd (a:float) b = a * a + b

//> val squareAndAdd : a:float -> b:float -> float
let squareAndAdd a b :float = a * a + b

//> val squareAndAdd : a:float -> b:float -> float
```

条件分岐の例

```fsharp
//条件分岐
let round x =
  if x >= 100 then 100
  elif x < 0 then 0
  else x

let round x =
  match x with
    | _ when x >= 100 -> 100
    | _ when x < 0 -> 0
    | _ -> x
    
```

再帰
```fsharp
let rec frac n =
  if n <= 1 then 1
  else n * frac (n - 1)
```

相互再帰はandでつなぐ
```fsharp
let rec even n = (n = 0u) || odd(n - 1u)
and odd n = (n <> 0u) && even(n - 1u)
```


