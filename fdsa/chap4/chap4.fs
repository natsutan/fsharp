
let countToTen = seq { 1..10 }

let intExp = 
  seq { 
    for i in 0..999 do
      yield i
  }
  
let intExp = 
  seq { 
      for i in 0..999 -> i
  }


seq { 0..9 } |> Seq.iter (printfn "%i")

let f x y = (double)(x + y)
