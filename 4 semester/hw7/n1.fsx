open System
open System.IO
open System.Net
open System.Text.RegularExpressions

let getRaw url = 
    let req = WebRequest.Create(Uri(url)) 
    use resp = req.GetResponse() 
    use stream = resp.GetResponseStream() 
    use reader = new IO.StreamReader(stream)
    reader.ReadToEnd()

let find pattern input =
   let ms = Regex.Matches(input,pattern)
   [for m in ms -> m.Groups.[1].Value]

let findLinks html =
    let pattern = "<a href=\"(http://.*?)\""
    find pattern html 
    |> List.filter (fun url -> Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))

let fetchUrlAsync(url) =
    async {
        let req = WebRequest.Create(Uri(url))
        let! resp = req.AsyncGetResponse()
        let stream = resp.GetResponseStream()
        let reader = new IO.StreamReader(stream)
        printfn "%s : %d characters" url <| reader.ReadToEnd().Length
    }

let countDataAsync url = 
    url
    |> getRaw
    |> findLinks
    |> Seq.map fetchUrlAsync
    |> Async.Parallel
    |> Async.Ignore
    |> Async.RunSynchronously