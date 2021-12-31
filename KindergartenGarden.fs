module KindergartenGarden

// https://exercism.org/tracks/fsharp/exercises/kindergarten-garden

let names =
    [ "Alice"
      "Bob"
      "Charlie"
      "David"
      "Eve"
      "Fred"
      "Ginny"
      "Harriet"
      "Ileana"
      "Joseph"
      "Kincaid"
      "Larry" ]
    |> List.mapi (fun i s -> (s, i * 2))
    |> Map.ofList

type Plant =
    | Radishes
    | Clover
    | Grass
    | Violets


let charToPlant (c: char) : Plant =
    match c with
    | 'R' -> Radishes
    | 'C' -> Clover
    | 'G' -> Grass
    | 'V' -> Violets
    | _ -> failwith "impossible"


let plants (diagram: string) (student: string) =
    diagram.Split "\n"
    |> Array.map (fun s -> s.Substring(names.[student], 2))
    |> String.concat ""
    |> Seq.map charToPlant
    |> Seq.toList


plants "VVCG\nVVRC" "Bob" |> ignore
plants "RC\nGG" "Alice" |> ignore
