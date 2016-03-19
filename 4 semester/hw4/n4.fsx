
//#4
type Op<'a> = 
    | Sum of ('a -> 'a -> 'a)
    | Sub of ('a -> 'a -> 'a)
    | Mul of ('a -> 'a -> 'a)
    | Div of ('a -> 'a -> 'a)

type Elem<'a> =
    | Monom of 'a * 'a //Coefficient and degree
    | Op of Op<'a>

type IField<'a> =
    abstract sum : 'a * 'a -> 'a
    abstract sub : 'a * 'a -> 'a
    abstract mult : 'a * 'a -> 'a
    abstract div : 'a * 'a -> 'a
    abstract zero : 'a
    abstract one : 'a

let normalizeGeneric (r : IField<'a>) lelems =
    let rec norm lelems acc =
        match lelems with
        | Monom(c, d) as m :: Op(f) :: t ->
            match f with
            | Sum(f) -> norm t <| m :: acc
            | Sub(f) -> 
                match t with
                | Monom(c', d') :: t' -> norm t' <| Monom(r.sub(r.zero, c'), d') :: m :: acc
                | _ -> None
            | Mul(f) ->
                match t with
                | Monom(c', d') :: t' -> norm (Monom(r.mult(c, c'), r.sum(d, d')) :: t') acc
                | _ -> None
            | Div(f) ->
                match t with
                | Monom(c', d') :: t' -> norm (Monom(r.div(c, c'), r.sub(d, d')) :: t') acc
                | _ -> None
        | Monom(c, d) as m :: [] -> Some(List.rev <| m :: acc)
        | [] -> Some(List.rev acc)
        | _ -> None
    norm lelems []

let derMonomialGeneric (r : IField<'a>) m =
    match m with 
    | Monom(c, d) when d = r.zero -> None
    | Monom(c, d) when c = r.zero -> None
    | Monom(c, d) -> Some(Monom(r.mult(c, d), r.sub(d, r.one)))
    | Op(f) as op -> None

let inline numeric () = 
    {new IField<'a> with
        member r.sum(a, b) = a + b
        member r.sub(a, b) = a - b
        member r.mult(a, b) = a * b
        member r.div(a, b) = a / b
        member r.zero = LanguagePrimitives.GenericZero<'a>
        member r.one = LanguagePrimitives.GenericOne<'a>}

let inline normalize lelems = normalizeGeneric (numeric()) lelems

let inline derMonomial m = derMonomialGeneric (numeric()) m

let inline derPolynomial ls = 
    ls 
    |> normalize
    |> Option.get
    |> List.map derMonomial
    |> List.filter Option.isSome
    |> List.fold (fun acc m -> m :: acc) []
    |> List.rev

//some examples
let t = [ Monom(1, 0); Op(Sum(+)); Monom(2, 1); Op(Sub(-)); Monom(3, 100) ]
let t' = [ Monom(1, 0); Op(Mul(*)); Monom(2, 1); Op(Mul(*)); Monom(3, 100) ]
let t'' = [ Monom(6.0, 1.0); Op(Div(/)); Monom(9.0, 100.0) ]
let t''' = [ Monom(666666666666666666666666666666666666I, -999999999999999999999999999999999I) ]