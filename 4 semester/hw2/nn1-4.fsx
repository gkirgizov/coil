
let rec foldDigits x f acc =
        match x with
        | 0 -> acc
        | _ -> foldDigits (x / 10) f (f acc (x % 10))

let productOfDigits x = foldDigits x (*) 1

let find ls x =
    let rec find_ ls x i =
        match ls with
        | h :: t when x = h -> i
        | h :: t -> find_ t x (i + 1)
        | [] -> -1
    find_ ls x 0
    
let isPalindrom ls =
    let rec isPalindrom_ ls rls = 
        match ls with
        | [] -> true
        | h :: t -> 
            match rls with
            | hr :: tr when h = hr -> isPalindrom_ t tr
            | _ -> false
    isPalindrom_ ls (List.rev ls)

let isUnique ls =
    let rec isUnique_ ls accls =
        match ls with 
        | [] -> true
        | h :: t when List.contains h accls -> false
        | h :: t -> isUnique_ t (h :: accls)
    isUnique_ ls []
