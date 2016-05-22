    
////#1

let checkstring (pairs : (char*char) list) (s : string) = 
    let toCharList s = [for c in s -> c]

    let (op, cl) =
        let rec prepare_ pairs op cl = 
            match pairs with 
            | (o, c) :: t -> prepare_ t (o :: op) (c :: cl)
            | [] -> (op, cl)
        prepare_ pairs [] []
        
    let isOp c = List.contains c op

    let isCorrespond o c = List.contains (o, c) pairs

    let rec r_ lc stack =
        match lc with
        | [] when List.length stack = 0 -> true
        | [] -> false
        | h :: t when isOp h -> r_ t <| h :: stack
        | h :: t -> 
            match stack with
            | [] -> false
            | hs :: ts when isCorrespond hs h |> not -> false
            | hs :: ts -> r_ t ts

    r_ (toCharList s) []

let braces = [ ('(', ')'); ('{', '}'); ('[', ']') ]
let checkstringForBraces = checkstring braces

//#2
let func    x l = List.map (fun y -> y * x) l
let func'   x   = List.map (fun y -> y * x)
let func''  x   = List.map ((*) x)
let func'''     = List.map << (*) 