module AtbashCipher

open System

let alphabet =
    [ 'a' .. 'z' ]
    |> List.mapi (fun i c -> (c, i + 1))
    |> Map.ofList

let alphabetPos =
    [ 'a' .. 'z' ]
    |> List.mapi (fun i c -> (i + 1, c))
    |> Map.ofList

let alphabetRev =
    [ 'a' .. 'z' ]
    |> List.mapi (fun i c -> (c, 26 - i))
    |> Map.ofList

let alphabetRevPos =
    [ 'a' .. 'z' ]
    |> List.mapi (fun i c -> (26 - i, c))
    |> Map.ofList

// let encode2 c =
//     if Char.IsDigit c then c else char(int('z') + int('a') - int(c))


let encode (str: string) =
    str.ToLower()
    |> Seq.filter Char.IsLetterOrDigit
    |> Seq.map (fun c ->
        if Char.IsDigit c then
            c
        else
            alphabetRevPos.[alphabet.[c]])
    |> Seq.mapi (fun i c ->
        if i % 5 = 0 && i > 0 then
            " " + (string c)
        else
            string c)
    |> System.String.Concat

let decode (str: string) =
    str.ToLower()
    |> Seq.filter Char.IsLetterOrDigit
    |> Seq.map (fun c ->
        if Char.IsDigit c then
            c
        else
            alphabetPos.[alphabetRev.[c]])
    |> System.String.Concat


encode "ab" |> ignore
encode "Testing,1 2 3, testing." |> ignore
