
// '‚Ígeneric type parameter‚ð’è‹`‚·‚é‰‰ŽZŽq
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

  
