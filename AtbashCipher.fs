module AtbashCipher

open System

let alphabet =
    [ 'a' .. 'z' ]
    |> List.zip ([ 'a' .. 'z' ] |> List.rev)
    |> Map.ofList

let alphabetRev =
    [ 'a' .. 'z' ]
    |> List.rev
    |> List.zip [ 'a' .. 'z' ]
    |> Map.ofList

let find (map: Map<char, char>) c =
    map.TryFind c |> Option.defaultValue c |> string

let encode (str: string) =
    str.ToLower()
    |> Seq.filter Char.IsLetterOrDigit
    |> Seq.map (fun c -> find alphabet c)
    |> Seq.chunkBySize 5
    |> Seq.map String.Concat
    |> String.concat " "

let decode (str: string) =
    str.ToLower()
    |> Seq.filter Char.IsLetterOrDigit
    |> Seq.map (fun c -> find alphabetRev c)
    |> String.concat ""

// let encode2 c =
//     if Char.IsDigit c then c else char(int('z') + int('a') - int(c))

// let decode2 (code: string) = (encode code).Replace(" ", "")

encode "ab" |> ignore
encode "Testing,1 2 3, testing." |> ignore
// decode2 "vcvix rhn" |> ignore
