module Acronym

open System

let abbreviate (phrase: string) =
    phrase
        .ToUpper()
        .Split([| ' '; '-' |], StringSplitOptions.RemoveEmptyEntries)
    |> Array.map (Seq.filter Char.IsLetter >> Seq.head)
    |> String.Concat

let abbreviate2 (phrase: string) =
    (phrase.ToUpper()
     |> Seq.map (fun c ->
         if Char.IsLetter c || c = ''' then
             c
         else
             ' ')
     |> System.String.Concat)
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    |> Array.map (fun s -> s.[0])
    |> String.Concat


abbreviate2 "The Road _Not_ Taken" |> printfn "%s"

abbreviate "Something - I made up from thin air"
|> printfn "%s"

abbreviate "Halley's Comet" |> printfn "%s"
