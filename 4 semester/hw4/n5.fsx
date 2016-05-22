
//#5
type Tree<'a> = 
    | Leaf of 'a
    | Tree of 'a * Tree<'a> * Tree<'a>

//without tail recursion
let rec badmap f tr =
    match tr with
    | Leaf(data) -> Leaf(f data)
    | Tree(data, l, r) -> Tree(f data, badmap f l, badmap f r)

//tail recursion
let map f tr =
    let rec map_ tr cont =
        match tr with
        | Leaf(data) -> cont <| Leaf(f data)
        | Tree(data, l, r) -> 
            map_ l (fun left ->
             map_ r (fun right -> 
              cont <| Tree(f data, left, right)))
    map_ tr <| fun tr -> tr

// test
let tr = Tree(5, Tree(3, Leaf(1), Leaf(2)), Leaf(6))
let multTreeBy2 = map <| (*) 2