
//#4
type Op<'a> = 
    | Sum of ('a -> 'a -> 'a)
    | Sub of ('a -> 'a -> 'a)
    | Mul of ('a -> 'a -> 'a)
    | Div of ('a -> 'a -> 'a)

type Eq<'a> =
    | Monom of 'a * 'a //Coefficient and degree
    | Op of Op<'a>

let normalize leq =
    let rec norm leq acc =
        match leq with
        | Monom(c, d) as m :: Op(f) :: t ->
            match f with
            | Sum(f) -> norm t <| m :: acc
            | Sub(f) -> 
                match t with
                | Monom(c', d') :: t' -> norm t' <| Monom(-c', d') :: m :: acc
                | _ -> None
            | Mul(f) ->
                match t with
                | Monom(c', d') :: t' -> norm (Monom(c * c', d + d') :: t') acc
                | _ -> None
            | Div(f) ->
                match t with
                | Monom(c', d') :: t' -> norm (Monom(c / c', d - d') :: t') acc
                | _ -> None
        | Monom(c, d) as m :: [] -> Some(List.rev <| m :: acc)
        | [] -> Some(List.rev acc)
        | _ -> None
    norm leq []

let derMonomial (neutralBySum, neutralByMul) m =
    match m with 
    | Monom(c, d) when d = neutralBySum -> None
    | Monom(c, d) when c = neutralBySum-> None
    | Monom(c, d) -> Some(Monom(c * d, d - neutralByMul))
    | Op(f) as op -> None

let derMonomialInt = derMonomial (0, 1)

let derPolynomialInt = 
    normalize
    >> Option.get
    >> List.map derMonomialInt
    >> List.filter Option.isSome
    >> List.fold (fun acc m -> m :: acc) []
    >> List.rev

//some examples
let t = [ Monom(1, 0); Op(Sum(+)); Monom(2, 1); Op(Sub(-)); Monom(3, 100) ]
let t' = [ Monom(1, 0); Op(Mul(*)); Monom(2, 1); Op(Mul(*)); Monom(3, 100) ]
let t'' = [ Monom(6, 1); Op(Div(/)); Monom(3, 100) ]