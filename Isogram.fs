module Isogram

open System

let isIsogram (str: string) =
    str.ToLower()
    |> Seq.filter Char.IsLetter
    |> Seq.countBy id
    |> Seq.filter (snd >> (<) 1)
    |> Seq.length = 0


// slower - 2 passes
let isIsogram2 (str: string) =
    let str = String.filter System.Char.IsLetter str

    str.ToLower()
    |> Seq.distinct
    |> Seq.length
    |> (=) str.Length

let isIsogram3 str =
    str
    |> Seq.filter Char.IsLetter
    |> Seq.countBy Char.ToLower
    |> Seq.forall (fun count -> snd count = 1)
// |> Seq.forall (snd >> (=) 1)
//
