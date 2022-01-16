module ArmstrongNumbers

open System

let toDigits (n: int) =
    [ for x in 0 .. int <| Math.Log(n, 10) do
          yield (n / (pown 10 x)) % 10 ]

let isArmstrongNumber (number: int) : bool =
    let digits = toDigits number
    let length = digits.Length

    digits
    |> List.sumBy (fun i -> pown i length)
    |> (=) number
