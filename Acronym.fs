module Acronym

open System

let abbreviate (phrase: string) =
    (phrase.ToUpper()
     |> Seq.map (fun c ->
         if Char.IsLetter c || c = ''' then
             c
         else
             ' ')
     |> System.String.Concat)
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    |> Array.map (fun s -> s.[0])
    |> System.String.Concat


abbreviate "The Road _Not_ Taken"
abbreviate "Something - I made up from thin air"
abbreviate "Halley's Comet"
