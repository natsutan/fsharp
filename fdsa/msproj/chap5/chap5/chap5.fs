// F# の詳細については、http://fsharp.org を参照してください
// 詳細については、'F# チュートリアル' プロジェクトを参照してください。

// 'はgeneric type parameterを定義する演算子
type Stack<'T>() =
  class
    let mutable _stack : List<'T> = []
    member this.Push value =
      lock _stack (fun () ->
                   _stack <- value :: _stack)

    member this.Pop =
      lock _stack (fun () ->
                   match _stack with
                   | result :: remainder ->
                      _stack <- remainder
                      result
                   | [] -> failwith "Stack is Empty"
                   )

    member this.TryPop =
      lock _stack (fun () ->
                   match _stack with
                      | result :: remainder ->
                        _stack <- remainder
                        result |> Some
                      | [] -> None
                   )
  end

  

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // 整数の終了コードを返します
