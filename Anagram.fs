module Anagram
// https://exercism.org/tracks/fsharp/exercises/anagram

let stringToMap (str: string) =
    str.ToLower().ToCharArray()
    |> Array.countBy id
    |> Map.ofArray

let findAnagrams (sources: string list) (target: string) =
    sources
    |> List.filter (fun s -> s.ToLower() <> target.ToLower())
    |> List.filter (fun s -> stringToMap s = stringToMap target)
