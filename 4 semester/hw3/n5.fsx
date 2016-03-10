//#5
let gen =
    let isPrime n = 
        let rec check i =
            (i > n/2) || (n % i <> 0 && check (i+1))
        check 2
    
    let numbers = Seq.initInfinite(fun i -> i + 2)
    seq { for n in numbers do if isPrime n then yield n }

//test : first 100 primes
let first100primes = gen |> Seq.take 100 |> Seq.toList;;