Introducing Functional Programming
---

# starting with number and strings
�V���v���Ȍ^

| type         | description           | Sample         | Long name      |
| *----        | ----                  | ----           | ----           |
| bool         | true/false            | true, false    | System.Boolean |
| Int/int32    | 32bit����             | 0, 19, 0x123   | System.Int32   |
| float/double | 64bit���������_���Z�� | 0.3, 1.3e4     | System.Double  |
| string       | ���j�R�[�h������      | "abc", @"\a\n" | System.String  |
| unit         | ��̒l�����Ƃ�Ȃ�  | ()             | System.Unit    |


�����Ɩ߂�l�Ɍ^�̐��������B
```fsharp
let squareAndAdd a b = a * a + b
//> val squareAndAdd : a:int -> b:int -> int

let squareAndAdd (a:float) b = a * a + b

//> val squareAndAdd : a:float -> b:float -> float
let squareAndAdd a b :float = a * a + b

//> val squareAndAdd : a:float -> b:float -> float
```

��������̗�

```fsharp
//��������
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

�ċA
```fsharp
let rec frac n =
  if n <= 1 then 1
  else n * frac (n - 1)
```

���ݍċA��and�łȂ�
```fsharp
let rec even n = (n = 0u) || odd(n - 1u)
and odd n = (n <> 0u) && even(n - 1u)
```


