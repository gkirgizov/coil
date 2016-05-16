//#3
type Tree<'a> = 
    | Leaf of 'a
    | Tree of 'a * Tree<'a> * Tree<'a>
         
let height (tr : Tree<'a>) = 
    let rec height_ stack h max =
        match stack with
        | [] -> max
        | h_tr :: t_tr -> 
            let h_inc = h + 1
            match h_tr with 
            | Leaf(_) when h_inc > max -> height_ t_tr h h_inc
            | Leaf(_) -> height_ t_tr h max
            | Tree(_, l, r) -> height_ (l :: r :: t_tr) h_inc max
    height_ [tr] 0 0

//#4
let dfs tr =
    let rec dfs_ stack acc =
        match stack with
        | [] -> acc
        | h :: t -> 
            match h with 
            | Leaf(data) -> dfs_ t (data :: acc)
            | Tree(data, l, r) -> dfs_ (l :: (r :: t)) (data :: acc)
    dfs_ [tr] []

type ArithNode<'a> = 
    | X of 'a               // Operand
    | F of ('a -> 'a -> 'a) // Operator

let calc rpn =
    let rec calc_ rpn acc =
        match rpn with 
        | X(x) :: t -> calc_ t (x :: acc)
        | F(f) :: t -> 
            match acc with
            | y :: x :: t_acc -> calc_ t (((f) x y) :: t_acc)
            | _ -> None
        | [] -> 
            match acc with
            | [h] -> Some(h)
            | _ -> None
    calc_ rpn []

let calc_ar_tree tr = dfs tr |> calc;;

//test : 3 4 2 * 1 5 - 2 3 - / + + = 15
//let rpn = [X(3.0); X(4.0); X(2.0); F(*); X(1.0); X(5.0); F(-); X(2.0); X(3.0); F(-); F(/); F(+); F(+)]