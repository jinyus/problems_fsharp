module TwoFer

let twoFer (input: string option) : string =
    input
    |> Option.defaultValue "you"
    |> sprintf "One for %s, one for me."


printfn $"{twoFer None}"
printfn $"""{twoFer (Some "Alice")}"""
printfn $"""{twoFer (Some "Bob")}"""
