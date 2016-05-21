open System

type RoundingBuilder(precision : int) =
    member self.Bind(x : float, f) = f <| Math.Round(x, precision)
    member self.Return(x : float) = Math.Round(x, precision)

let rounding u = new RoundingBuilder(u)

// test 1
let t1 = rounding 3 {
    let! a = 2.0 / 12.0
    let! b = 3.5
    return a / b
}

let t2 = rounding 3 {
    let! a = 1.0 / 3000.0
    return a * 1000.0
}