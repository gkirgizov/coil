    
//#1
let checkstring checkingPairs (s : string) = 
    let checkchar (c : char) (openchar, closechar) = 
        match c with
        | сс when c = openchar -> (+) 1
        | сс when c = closechar -> (+) -1
        | _ -> fun x -> x
    
    let checkchars = List.map << checkchar
    let invoke lx lf = List.map (fun (f, x) -> f x) <| List.zip lf lx
    let checkPairs lpairs lacc c = invoke lacc <| checkchars c lpairs

    let rec checkstring_ s lacc =
        match s with
        | _ when List.exists ((>) 0) lacc -> false
        | [] when List.sum lacc = 0 -> true
        | [] -> false
        | h :: t -> checkstring_ t <| checkPairs checkingPairs lacc h

    let toCharList s = [for c in s -> c]
    checkstring_ (toCharList s) [for i in 1 .. List.length checkingPairs -> 0]

let braces = [ ('(', ')'); ('{', '}'); ('[', ']') ]
let checkstringForBraces = checkstring braces

//#2
let func    x l = List.map (fun y -> y * x) l
let func'   x   = List.map (fun y -> y * x)
let func''  x   = List.map ((*) x)
let func'''     = List.map << (*) 