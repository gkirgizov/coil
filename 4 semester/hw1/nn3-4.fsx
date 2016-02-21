
// List.rev list
let revert list = 
    let rec revert_ ls rls =
        match ls with
        | [] -> rls
        | h :: t -> revert_ t (h :: rls)
    revert_ list []

let getPowersOfTwo n = 
    let rec nextPow ls n cur =
        let next = cur * 2
        match n with
        | 0u -> ls
        | _ -> nextPow (next :: ls) (n - 1u) next
    nextPow [] n 1
