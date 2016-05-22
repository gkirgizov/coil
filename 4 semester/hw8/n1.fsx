open System.Threading

let createThreads (a : int []) nblocks (res : int ref) = [
    let block = (Seq.length a) / nblocks
    for i in 1 .. nblocks -> new Thread( ThreadStart( fun _ ->
                                    let l = (i - 1) * block
                                    let u = l + block - 1
                                    for j in l .. u do
                                        res := !res + a.[j] )
    )]

let start (threads : Thread list) = List.map (fun (thread : Thread) -> thread.Start()) threads
let join (threads : Thread list) = List.map (fun (thread : Thread) -> thread.Join()) threads

let arr = Array.init(1000000) (fun i -> 1)
let r = ref 0

let t = createThreads arr 100 r
printfn "Starting"
t |> start
printfn "Started"
t |> join
printfn "Joined"

printfn "Done: result is %d" !r