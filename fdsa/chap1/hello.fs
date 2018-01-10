
printfn "Hello World"

let square n = n * n

square 4

// tapple
let t = ("cats", "dogs", System.Math.PI, 42, "C", "Java")

// array
let GuardiansOfGalaxy = [| "Peter Quill"; "Gamora"; "Drax"; "Groot"; "Rocket"; "Ronan"; "Yondu Udonta"; "Nebula"; "Korath"; "Corpsman Dey";"Nova Prime";"The Collector";"Meredith Quill" |]

GuardiansOfGalaxy.[4]

//range
let OneToHundred = [|1..100|]

//slice
OneToHundred.[0..2]

//patrially
let add x y = x + y

add 10 4

let add10 = add 10

add10 15

//compsiton
let inc n = n + 1
let div n = n / 2

let InvokeTri n (f:int->int) = f(f(f(n)))
let InvokeTrif n (f:float->float) = f(f(f(n)))

InvokeTri 10 inc
InvokeTri 80 div
InvokeTrif 2.0 (fun n -> n **3.0)

//array
let nums = [|0..99|]

let squares =
    nums |> Array.map (fun n -> n * n)

//fold
let sum = Array.fold(fun acc n -> acc + n) 0 squares

//fillter
let castNames = [| "Hofstadter"; "Cooper"; "Wolowitz"; "Koothrappali"; "Fowler"; "Rostenkowski";  |]

let longNames = Array.filter (fun (name: string) -> name.Length > 6) castNames


//zip
let firstNames = [| "Leonard"; "Sheldon"; "Howard"; "Penny"; "Raj"; "Bernadette"; "Amy" |]
let lastNames = [| "Hofstadter"; "Cooper"; "Wolowitz"; ""; "Koothrappali"; "Rostenkowski"; "Fowler" |]

let fullNames = Array.zip(firstNames) lastNames

