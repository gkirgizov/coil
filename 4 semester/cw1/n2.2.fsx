open System

let isPalindrom ls =
    let rec isPalindrom_ ls rls = 
        match ls with
        | [] -> true
        | h :: t -> 
            match rls with
            | hr :: tr when h = hr -> isPalindrom_ t tr
            | _ -> false
    isPalindrom_ ls (List.rev ls)

let isNumberPalindrom x =
    let toList s = [for c in s -> c]
    x.ToString() |> toList |> isPalindrom

let findFirst ls =
    let rec find_ ls =
        match ls with
        | h :: t when isNumberPalindrom h -> h
        | h :: t -> find_ t
        | _ -> failwith "Error: there is no palindromes, sorry."
    find_ ls

let numbers = [for i in 100 .. 999 do
                    for j in 100 .. 999 -> i * j]

let maxPalindrome = numbers |> List.sortDescending |> findFirst