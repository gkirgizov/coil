module n3

open System.IO
open System.Runtime.Serialization.Formatters.Binary

let introtxt = "
This is a JASP (Just Another Simple Phonebook).
You may enter:
h - to print this intro
0 - to quit (IMHO it's not interesting)
1 - to add record (name and telephone)
2 - to find name by telephone
3 - to find telephone by name
4 - to save phonebook to file
5 - to load phonebook from file \n"

type record = string * string

let exe =
    printf "%s" introtxt
    let rec exe_ db =
        let printAndReadline intro =
            printf "%s, please >> " intro
            System.Console.ReadLine()

        let add () = 
            let name = printAndReadline "Input name for new record"
            let phone = printAndReadline "Input phone for new record"
            exe_ <| (name, phone) :: db

        let find1 name = List.filter ((=) name << fst) db
        let findByName () = 
            printAndReadline "Input name to search" |> find1 |> sprintf "%A" |> printf "%s \n"
            exe_ db
        
        let find2 phone = List.filter ((=) phone << snd) db
        let findByTelephone () = 
            printAndReadline "Input phone to search" |> find2 |> sprintf "%A" |> printf "%s \n"
            exe_ db

        let save () =
            let path = printAndReadline "Input path to file"
            let fsOut = new FileStream(path, FileMode.Create)
            let formatter = BinaryFormatter()
            formatter.Serialize(fsOut, box db)
            fsOut.Close()
            exe_ db
        
        let load () = 
            let path = printAndReadline "Input path to file"
            let fsIn = new FileStream(path, FileMode.Open)
            let formatter = BinaryFormatter()
            let db : (string * string) list = formatter.Deserialize(fsIn) |> unbox
            fsIn.Close()
            exe_ db

        let help () = 
            printf "%s" introtxt
            exe_ db
        
        printf ">> "
        let x = System.Console.ReadLine()
        match x with
        | "h" -> help()
        | "5" -> load()
        | "4" -> save()
        | "3" -> findByName()
        | "2" -> findByTelephone()
        | "1" -> add()
        | "0" -> 0
        | _ -> 
            printf "Error: wrong choice. 「(°ヘ°) \n"
            exe_ db
    exe_ []