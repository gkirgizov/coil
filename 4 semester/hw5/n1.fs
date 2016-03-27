module n1

open System
open System.Collections

type OS =
    | Windows
    | Linux
    | Solaris
    | OSX
    with
    member self.Vulnerability =
        match self with
        | Windows -> 0.7
        | Linux -> 0.4
        | Solaris -> 0.3
        | OSX -> 0.4
        
    override self.ToString() =
        match self with
        | Windows -> "Windows"
        | Linux -> "Linux"
        | Solaris -> "Solaris"
        | OSX -> "OSX"

type Computer(os : OS, isInfected_, r : System.Random) = 
    member val IsInfected = isInfected_ with get, set
        
    override self.ToString() = 
        os.ToString() + ", infected : " + self.IsInfected.ToString()

    member self.OS = os

type Network(comps_, links_, ?r_) =
    let r = if r_.IsSome then Option.get r_ else new Random()
    let comps : Computer list = comps_
    let links : bool list list = links_
    
    let neighbours cl =
        let rec neighbours_ cl i acc =
            let i' = i + 1
            match cl with 
            | h :: t when h -> neighbours_ t i' <| i' :: acc
            | h :: t -> neighbours_ t i' acc
            | [] -> List.rev acc
        neighbours_ cl 0 [] 

    new(numComp, ?r_) =
        let r = if r_.IsSome then Option.get r_ else new Random()
        let randomOS () =
            match r.Next(4) with
            | 0 -> Windows
            | 1 -> Linux
            | 2 -> Solaris
            | 3 -> OSX
            | _ -> Linux
        let cl = [for i in 0 .. numComp - 1 -> 
                    Computer(randomOS(), System.Convert.ToBoolean(r.Next(2)), r)]
        let ll = [for k in 0 .. numComp - 1 ->
                    [for j in 0 .. numComp - 1 -> System.Convert.ToBoolean(r.Next(2))]]
        Network(cl, ll, r)

    override self.ToString() =
        let neighboursToStr l =
            let rec n_ l acc =
                match l with 
                | h :: t -> n_ t <| acc + h.ToString() + " "
                | [] -> acc
            n_ l ""

        let rec print (comps, links) i acc =
            match comps with 
            | [] -> acc
            | h :: t -> 
                print (t, List.tail links) (i + 1) 
                    <| acc + i.ToString() + " : " + h.ToString() + 
                        ", out links to : " + neighboursToStr (neighbours links.Head) + "\n"

        print (comps, links) 1 ""

    member self.TryToInfect(comp : Computer) =
        match r.NextDouble() * comp.OS.Vulnerability with
        | a when a > 0.5 -> comp.IsInfected <- true
        | _ -> ()

    member self.IsNetworkDoomed =
        let rec check (cl : Computer list) =
            match cl with 
            | h :: t when not h.IsInfected -> false
            | h :: t -> check t
            | [] -> true
        check comps

    member self.ExecStep() = 
        let send =
            let rec send_ (cl : Computer list) ll adressees =
                match cl with
                | h :: t when h.IsInfected -> 
                    ll |> List.head |> neighbours |> (@) adressees |> send_ t ll.Tail
                | h :: t -> send_ t ll.Tail adressees
                | [] -> adressees
            send_ comps links []
        
        let rec receive cl =
            match cl with 
            | h :: t -> 
                self.TryToInfect comps.[h - 1]
                receive t
            | [] -> ()

        send |> receive

    member self.Exec(numSteps) =
        let rec exec i =
            self.ExecStep()
            printfn "iteration %d\n\n%A" (numSteps - i + 1) self
            match i with
            | _ when self.IsNetworkDoomed -> ()
            | 0 -> ()
            | _ -> exec <| i - 1
        exec numSteps