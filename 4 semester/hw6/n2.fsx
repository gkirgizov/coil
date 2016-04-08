
let parse s = 
    let v = ref 0
    match System.Int32.TryParse(s, v) with
    | true -> Some !v
    | false -> None

type StringExpressionBuilder() =
    member self.Bind(s, f) =
        match parse s with 
        | Some v -> f v
        | None -> None
      
    member self.Return(v) = Some v
    
// Как я понимаю, для удовлетворения 1 закона 
// Bind и Return должны удовлетворять сигнатурам:
// Bind : M<'T> * ('T -> M<'T>) -> M<'T>
// Return : 'T -> M<'T>
//
// Тогда, например, 2 варианта:
// v.1
// Bind : string option * (string -> string option) -> string option
// Return : string -> string option
// v.2
// Bind : string * (int -> string) -> string
// Return : int -> string

type CorrectStringExpressionBuilderV2() =
    member self.Bind(s, f) =
        match parse s with 
        | Some v -> f v
        | None -> ""
      
    member self.Return(v) = v.ToString()

let strexpr = CorrectStringExpressionBuilderV2()

let t1 = strexpr {
    let! x = "1"
    let! y = "77"
    let z = x + y
    return z
}

//tests for law 1

let t3 = strexpr {
    let originalUnwr = 11

    let wrapped = strexpr { return originalUnwr }
    let! unwrapped = wrapped
    
    printfn "If originalUnwr <> unwrapped then 1 law is violated"
    printfn "originalUnwr : %A" originalUnwr
    printfn "unwrapped  : %A" unwrapped

    return originalUnwr
}

let t4 = strexpr {
    let originalWrapped = strexpr { return 11 }
    
    let newWrapped = strexpr {
        let! unwrapped = originalWrapped
        return unwrapped
    }

    printfn "If origWrapped <> newWrapped then 2 law is violated"
    printfn "originalWrapped : %A" originalWrapped
    printfn "newWrapped  : %A" newWrapped
    
    return originalWrapped
}