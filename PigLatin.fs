module PigLatin

// https://exercism.org/tracks/fsharp/exercises/pig-latin/
open System.Text.RegularExpressions

let startWithVowel (str: string) : bool = Regex.IsMatch(str, "^(xr|yt|[aeiou])")

let yEdgeCase (str: string) : bool = str.Length = 2 && (str.EndsWith "y")

// chair 2(index of firstvowel) -> airch
let movePrefixToSuffix (index: int) (str: string) : string =
    let prefix = str.Substring(0, index)
    let rest = str.Substring index
    sprintf "%s%s" rest prefix

let movePrefixToSuffix2 index (str: string) =
    $"{str.Substring index}{str.Substring(0, index)}"

let piglatinize (str: string) : string = str + "ay"

let translate (input: string) =
    let rec inner (start: bool) (str: string) =
        if start && yEdgeCase str then
            str |> movePrefixToSuffix 1 |> piglatinize
        elif not start && (str.StartsWith "y") then
            str |> piglatinize
        elif str.StartsWith "qu" then
            str |> movePrefixToSuffix 2 |> piglatinize
        elif startWithVowel str then
            str |> piglatinize
        else
            inner false (str |> movePrefixToSuffix 1)

    input.Split " "
    |> Array.map (inner true)
    |> String.concat " "

printfn "%s" (translate "apple")
printfn "%s" (translate "ear")
printfn "%s" (translate "igloo")
printfn "%s" (translate "object")
printfn "%s" (translate "under")
printfn "%s" (translate "equal")
printfn "%s" (translate "pig")
printfn "%s" (translate "koala")
printfn "%s" (translate "xenon")
printfn "%s" (translate "qat")
printfn "%s" (translate "chair")
printfn "%s" (translate "queen")
printfn "%s" (translate "square") // hard
printfn "%s" (translate "therapy")
printfn "%s" (translate "thrush")
printfn "%s" (translate "school")
printfn "%s" (translate "yttria")
printfn "%s" (translate "xray")
printfn "%s" (translate "yellow")
printfn "%s" (translate "rhythm")
printfn "%s" (translate "my") // hard
printfn "%s" (translate "quick fast run")
