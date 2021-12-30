module PigLatin

open System.Text.RegularExpressions
// https://exercism.org/tracks/fsharp/exercises/pig-latin/

let vowels = "aeiou"

let startWithVowel (str: string) : bool =
    Regex.IsMatch(str, "^(xr|yt|[aeiou]|qu)")

let indexOfFirstVowel (str: string) : int option =
    let rec inner i =
        if (vowels.Contains(str.[i])) then
            Some(i)
        elif i = str.Length then
            None
        else
            inner (i + 1)

    inner 0

// chair 2(index of firstvowel) -> airch
let movePrefixToSuffix (index: int) (str: string) : string =
    let prefix = str.Substring(0, index)
    let rest = str.Substring index
    sprintf "%s%s" rest prefix

let piglatinize (str: string) : string = str + "ay"

let translate input =
    let rec inner (str: string) =
        printfn "processing %s" str

        if startWithVowel str then
            piglatinize str
        else
            inner (str |> movePrefixToSuffix 1)

    inner input

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
