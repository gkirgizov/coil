//#1
let getMaxSumOfPair ls =
    let rec getMaxSumOfPair_ ls max maxi i =
        match ls with
        | [] -> maxi
        | h :: t ->
            match t with
            | ht :: tt when ht + h > max -> getMaxSumOfPair_ t (ht + h) (i + 1) (i + 1)
            | ht :: tt -> getMaxSumOfPair_ t max maxi (i + 1)
            | _ -> maxi
    getMaxSumOfPair_ ls 0 0 0

//#2
let nof = List.filter (fun x -> x % 2 = 0) >> List.length

//let nof' = List.map (fun x -> (x + 1) % 2) >> List.sum 
//there is no List.sum in the list of allowed functions in the task, so ...
let nof' = List.map (fun x -> (x + 1) % 2) >> List.fold (fun acc x -> acc + x) 0

let nof'' = List.fold (fun acc x -> acc + (x + 1) % 2) 0