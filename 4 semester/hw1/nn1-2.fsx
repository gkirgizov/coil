
let rec fact x =
    match x with
    | 1 -> 1
    | x when x < 1 -> 1
    | _ -> x * fact (x - 1)

let rec fibb n =
    match n with
    | 0L -> 0L
    | 1L -> 1L
    | _ -> fibb (n - 1L) + fibb (n - 2L)
