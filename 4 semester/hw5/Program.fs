﻿// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System
open n1
open n2

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    
    // Some tests for example (exercise #2)
    let t' = new Tree<int>()
    let t = t' :> ITree<int>
    t.Add(16)
    t.Add(64)
    t.Add(32)
    t.Add(4)
    t.Add(2)
    t.Add(8)
    
    printf "count : %A\n\n" t.Count

    printf "16 ? %A\n" <| t.Contains(16)
    printf "4 ? %A\n" <| t.Contains(4)
    printf "8 ? %A\n" <| t.Contains(8)
    printf "1024 ? %A\n\n" <| t.Contains(1024)

    t.Add(512)
    printf "added   512 ? %A\n" <| t.Contains(512)
    t.Remove(512)
    printf "removed 512 ? %A\n\n" <| t.Contains(512)

    printf "tree : %A\n\n" t

    let printt = Seq.iter <| printf "%A "
    printt t
    printfn "\n"

    // Example for exercise #1
    let r = new Random(1)
    let n = new Network(5, r)
    printfn "\n\n%A\n" n
    n.Exec(10);

    0 // return an integer exit code
