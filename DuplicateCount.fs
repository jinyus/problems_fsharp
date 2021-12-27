namespace Codewars

module Duplicates =
    let incrementOption (o: option<int>) =
        match o with
        | Some value -> Some(value + 1)
        | None -> Some 1

    let incrementMap (map: Map<char, int>) (key: char) =
        map |> Map.change key (fun o -> incrementOption o)

    let incrementOption2 (o: option<int>) =
        match o with
        | Some value -> value + 1
        | None -> 1

    let incrementMap2 (map: Map<char, int>) (key: char) =
        map
        |> Map.add key (map.TryFind key |> incrementOption2)

    let incrementMap3 (map: Map<char, int>) (key: char) =
        map
        |> Map.add
            key
            (map.TryFind key
             |> Option.map ((+) 1)
             |> Option.defaultValue 1)

    let duplicateCount (text: string) : int =
        text.ToLower().ToCharArray()
        |> Array.fold incrementMap3 Map.empty<char, int>
        |> Map.filter (fun _ value -> value > 1)
        |> Map.count

    let duplicateCount2 (text: string) : int =
        text.ToLower()
        |> Seq.countBy id
        |> Seq.filter (fun (_, count) -> count > 1)
        |> Seq.length

    let duplicateCount3 (text: string) : int =
        text.ToLower()
        |> Seq.countBy id
        |> Seq.filter (snd >> (<) 1)
        |> Seq.length

    let duplicateCount4 (text: string) =
        text.ToLower().ToCharArray()
        |> Array.groupBy id
        |> Array.filter (fun (_, x) -> x.Length > 1)
        |> Array.length
