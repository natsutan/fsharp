//chap3

let squareAndAdd a b = a * a + b
//> val squareAndAdd : a:int -> b:int -> int

let squareAndAdd (a:float) b = a * a + b

//> val squareAndAdd : a:float -> b:float -> float
let squareAndAdd a b :float = a * a + b

//> val squareAndAdd : a:float -> b:float -> float

//ğŒ•ªŠò
let round x =
  if x >= 100 then 100
  elif x < 0 then 0
  else x

let round x =
  match x with
    | _ when x >= 100 -> 100
    | _ when x < 0 -> 0
    | _ -> x
    
//Ä‹A
let rec frac n =
  if n <= 1 then 1
  else n * frac (n - 1)

//‘ŠŒİÄ‹A
  
