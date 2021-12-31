module PhoneNumberTests =
    open Fuchu
    open PhoneNumber


    let suite =
        testList
            "PhoneNumber Suite"
            [ testList
                  "PhoneNumber Clean tests"
                  [ testCase "Invalid if exchange code starts with 1 on valid 11-digit number"
                    <| fun _ -> Assert.Equal("", Error "exchange code cannot start with one", clean "1 (223) 156-7890")

                    testCase "Invalid if exchange code starts with 0 on valid 11-digit number"
                    <| fun _ -> Assert.Equal("", Error "exchange code cannot start with zero", clean "1 (223) 056-7890")

                    testCase "Invalid if area code starts with 1 on valid 11-digit number"
                    <| fun _ -> Assert.Equal("", Error "area code cannot start with one", clean "1 (123) 456-7890")

                    testCase "Invalid if area code starts with 0 on valid 11-digit number"
                    <| fun _ -> Assert.Equal("", Error "area code cannot start with zero", clean "1 (023) 456-7890")

                    testCase "Invalid if exchange code starts with 1"
                    <| fun _ -> Assert.Equal("", Error "exchange code cannot start with one", clean "(223) 156-7890")

                    testCase "Invalid if exchange code starts with 0"
                    <| fun _ -> Assert.Equal("", Error "exchange code cannot start with zero", clean "(223) 056-7890")

                    testCase "Invalid if area code starts with 1"
                    <| fun _ -> Assert.Equal("", Error "area code cannot start with one", clean "(123) 456-7890")

                    testCase "Invalid if area code starts with 0"
                    <| fun _ -> Assert.Equal("", Error "area code cannot start with zero", clean "(023) 456-7890")

                    testCase "Invalid with punctuations"
                    <| fun _ -> Assert.Equal("", Error "punctuations not permitted", clean "123-@:!-7890")

                    testCase "Invalid when it contains letters"
                    <| fun _ -> Assert.Equal("", Error "letters not permitted", clean "123-abc-7890")

                    testCase "Invalid when more than 11 digits"
                    <| fun _ -> Assert.Equal("", Error "more than 11 digits", clean "321234567890")

                    testCase "Valid when 11 digits and starting with 1 even with punctuation"
                    <| fun _ -> Assert.Equal("", Ok 2234567890UL, clean "+1 (223) 456-7890")

                    testCase "Valid when 11 digits and starting with 1"
                    <| fun _ -> Assert.Equal("", Ok 2234567890UL, clean "12234567890")

                    testCase "Invalid when 11 digits does not start with a 1"
                    <| fun _ -> Assert.Equal("", Error "11 digits must start with 1", clean "22234567890")

                    testCase "Invalid when 9 digits"
                    <| fun _ -> Assert.Equal("", Error "incorrect number of digits", clean "123456789")

                    testCase "Cleans numbers with multiple spaces"
                    <| fun _ -> Assert.Equal("", Ok 2234567890UL, clean "223 456   7890   ")

                    testCase "Cleans numbers with dots"
                    <| fun _ -> Assert.Equal("", Ok 2234567890UL, clean "223.456.7890")

                    testCase "Cleans the number"
                    <| fun _ -> Assert.Equal("", Ok 2234567890UL, clean "(223) 456-7890") ] ]

    [<EntryPoint>]
    let main _ = run suite
