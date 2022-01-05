module Series

let slices (str: string) (length: int) =
    if length < 1 || str.Trim() = "" then
        None
    else
        str
        |> Seq.windowed length
        |> Seq.map System.String.Concat
        |> Seq.toList
        |> (function
        | [] -> None
        | x -> Some x)

let slices2 (str: string) (length: int) =
    if length < 1 || length > str.Length then
        None
    else
        str
        |> Seq.windowed length
        |> Seq.map System.String.Concat
        |> Seq.toList
        |> Some


slices "35" 2 |> printfn "%A"
slices "9142" 2 |> printfn "%A"
slices "12345" 6 |> printfn "%A"
slices "12345" 0 |> printfn "%A"
slices "" 1 |> printfn "%A"
slices "" |> printfn "%A"
slices "" |> printfn "%A"
