module PhoneNumber

// https://exercism.org/tracks/fsharp/exercises/phone-number

let validateLength (numbers: char []) =
    if numbers.Length = 10 || numbers.Length = 11 then
        Ok numbers
    else
        Error(
            if numbers.Length < 10 then
                "incorrect number of digits"
            else
                "more than 11 digits"
        )

let checkForLetters (numbers: char []) =
    let rec inner (nums: char []) =
        match Array.tryHead nums with
        | Some head ->
            if System.Char.IsLetter(head) then
                Error "letters not permitted"
            elif System.Char.IsPunctuation(head) then
                Error "punctuations not permitted"
            else
                inner (Array.tail nums)
        | None -> Ok numbers

    inner numbers

let validateIntlCode (numbers: char []) =
    if numbers.Length = 10 then
        Ok numbers
    elif not (Array.head numbers = '1') then
        Error "11 digits must start with 1"
    else
        Ok(Array.tail numbers)

let validateNumber (numbers: char []) =
    match numbers |> Array.toList with
    | '0' :: _ -> Error "area code cannot start with zero"
    | '1' :: _ -> Error "area code cannot start with one"
    | _ :: _ :: _ :: '0' :: _ -> Error "exchange code cannot start with zero"
    | _ :: _ :: _ :: '1' :: _ -> Error "exchange code cannot start with one"
    | _ -> Ok numbers

let isNotAllowedChar (c: char) : bool =
    [ ' '; '.'; '-'; '('; ')'; '+' ]
    |> List.exists ((=) c)
    |> not

let clean (input: string) : Result<uint64, string> =
    input.ToCharArray()
    |> Array.filter isNotAllowedChar
    |> validateLength
    |> Result.bind checkForLetters
    |> Result.bind validateIntlCode
    |> Result.bind validateNumber
    |> Result.bind (fun nums -> nums |> System.String |> string |> uint64 |> Ok)

// clean "(223) 056-7890"
// clean "321234567890"
// clean "123-abc-7890"
// clean "123-@:!-7890"
// clean "1 (223) 156-7890"
// clean "1 (223) 056-7890"
// clean "1 (123) 456-7890"
// clean "1 (023) 456-7890"
// clean "(223) 056-7890"
// clean "(123) 456-7890"
// clean "(023) 456-7890"
// clean "+1 (223) 456-7890"
