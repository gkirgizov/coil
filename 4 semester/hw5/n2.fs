module n2

open System
open System.Collections
open System.Collections.Generic

type ITree<'T when 'T : comparison> =
    inherit IEnumerable<'T>
    abstract Count : int
    abstract Contains : 'T -> bool
    abstract Add : 'T -> unit
    abstract Remove : 'T -> unit

type Tree'<'T> = 
    | Leaf of 'T
    | Tree' of 'T * Tree'<'T> * Tree'<'T>

type ITreeEnumerator<'T>(tr) =
    let dfs tr =
        let rec dfs_ stack acc =
            match stack with
            | [] -> acc |> List.rev
            | Leaf(None) :: t -> dfs_ t acc
            | Leaf(Some(v)) :: t -> dfs_ t (v :: acc)
            | Tree'(Some(v), l, r) :: t -> dfs_ (l :: (r :: t)) (v :: acc)
            | _ -> failwith "unexpected case in dfs func"
        dfs_ [tr] []
    
    let dfsStack = dfs tr
    let mutable isStart = true
    let mutable currentStack = dfsStack
    
    interface IEnumerator<'T> with
        member self.Current = List.head currentStack

    interface IEnumerator with
        member self.Current = List.head currentStack |> box

        member self.Reset() = currentStack <- dfsStack

        member self.MoveNext() = 
            match currentStack with
            | [] -> false
            | _ when isStart ->
                isStart <- false
                true
            | h :: [] -> false
            | h :: t ->
                currentStack <- t
                true

    interface IDisposable with
        member self.Dispose() = ()

type Tree<'T when 'T : comparison>() = 
    let mutable t = Leaf(None)
    let mutable count = 0

    interface IEnumerable<'T> with
        member self.GetEnumerator() = 
            new ITreeEnumerator<'T>(t) :> IEnumerator<'T>

    interface IEnumerable with
        member self.GetEnumerator() = 
            new ITreeEnumerator<'T>(t) :> IEnumerator

    interface ITree<'T> with
        member self.Count = count

        member self.Contains(value) = 
            let rec contains tr =
                match tr with 
                | Tree'(Some(v), l, r) when value < v -> contains l
                | Tree'(Some(v), l, r) when value > v -> contains r
                | Tree'(Some(v), l, r) when value = v -> true
                | Leaf(Some(v)) when value = v -> true
                | _ -> false
            contains t
        
        member self.Add(value) =
            let rec add tr cont =
                match tr with
                | Leaf(None) -> 
                    count <- count + 1
                    cont <| Leaf(Some(value))
                | Leaf(Some(v)) when value < v -> 
                    count <- count + 1
                    cont <| Tree'(Some(v), Leaf(Some(value)), Leaf(None))
                | Leaf(Some(v)) when value > v -> 
                    count <- count + 1
                    cont <| Tree'(Some(v), Leaf(None), Leaf(Some(value)))
                | Tree'(Some(v), l, r) when value < v ->
                    add l <| fun left -> cont <| Tree'(Some(v), left, r)
                | Tree'(Some(v), l, r) when value > v ->
                    add r <| fun right -> cont <| Tree'(Some(v), l, right)
                | _ -> cont tr
            t <- add t <| fun x -> x

        //TODO cont
        member self.Remove(value) =
            let rec lastLeft tr cont =
                match tr with
                | Leaf(Some(v)) -> v, cont <| Leaf(None)
                | Tree'(Some(v), Leaf(None), r) -> v, cont r
                | Tree'(Some(v), l, r) -> 
                    lastLeft l <| fun left -> cont <| Tree'(Some(v), left, r)
                | _ -> failwith "unexpected case in lastLeft func in Tree.Remove"
                
            let rec remove tr cont =
                match tr with
                | Tree'(Some(v), l, r) when value < v -> 
                    remove l <| fun left -> cont <| Tree'(Some(v), left, r)
                | Tree'(Some(v), l, r) when value > v ->
                    remove r <| fun right-> cont <| Tree'(Some(v), l, right)
                | Tree'(Some(v), l, r) when value = v ->
                    count <- count - 1
                    match r with
                    | Leaf(None) -> cont l
                    | _ when l = Leaf(None) -> cont r
                    | _ -> 
                        let (newV, newR) = lastLeft r <| fun x -> x
                        cont <| Tree'(Some(newV), l, newR)
                | Leaf(Some(v)) when value = v -> 
                    count <- count - 1
                    cont <| Leaf(None)
                | _ -> cont tr
            t <- remove t <| fun x -> x
