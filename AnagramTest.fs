module PhoneNumberTests =
    open Fuchu
    open Anagram


    let suite =
        testList
            "PhoneNumber Suite"
            [ testList
                  "PhoneNumber Clean tests"
                  [ testCase "No matches"
                    <| fun _ -> Assert.Equal("", [], findAnagrams [ "hello"; "world"; "zombies"; "pants" ] "diaper")

                    testCase "Detects two anagrams"
                    <| fun _ ->
                        Assert.Equal("", [ "lemons"; "melons" ], findAnagrams [ "lemons"; "cherry"; "melons" ] "solemn")

                    testCase "Does not detect anagram subsets"
                    <| fun _ -> Assert.Equal("", [], findAnagrams [ "dog"; "goody" ] "good")

                    testCase "Detects anagram"
                    <| fun _ ->
                        Assert.Equal(
                            "",
                            [ "inlets" ],
                            findAnagrams
                                [ "enlists"
                                  "google"
                                  "inlets"
                                  "banana" ]
                                "listen"
                        )

                    testCase "Detects three anagrams"
                    <| fun _ ->
                        Assert.Equal(
                            "",
                            [ "gallery"; "regally"; "largely" ],
                            findAnagrams
                                [ "gallery"
                                  "ballerina"
                                  "regally"
                                  "clergy"
                                  "largely"
                                  "leading" ]
                                "allergy"
                        )

                    testCase "Detects multiple anagrams with different case"
                    <| fun _ -> Assert.Equal("", [ "Eons"; "ONES" ], findAnagrams [ "Eons"; "ONES" ] "nose")

                    testCase "Does not detect non-anagrams with identical checksum"
                    <| fun _ -> Assert.Equal("", [], findAnagrams [ "last" ] "mass")

                    testCase "Detects anagrams case-insensitively"
                    <| fun _ ->
                        Assert.Equal(
                            "",
                            [ "Carthorse" ],
                            findAnagrams
                                [ "cashregister"
                                  "Carthorse"
                                  "radishes" ]
                                "Orchestra"
                        )

                    testCase "Detects anagrams using case-insensitive subject"
                    <| fun _ ->
                        Assert.Equal(
                            "",
                            [ "carthorse" ],
                            findAnagrams
                                [ "cashregister"
                                  "carthorse"
                                  "radishes" ]
                                "Orchestra"
                        )

                    testCase "Detects anagrams using case-insensitive possible matches"
                    <| fun _ ->
                        Assert.Equal(
                            "",
                            [ "Carthorse" ],
                            findAnagrams
                                [ "cashregister"
                                  "Carthorse"
                                  "radishes" ]
                                "orchestra"
                        )

                    testCase "Does not detect an anagram if the original word is repeated"
                    <| fun _ -> Assert.Equal("", [], findAnagrams [ "go Go GO" ] "go")

                    testCase "Anagrams must use all letters exactly once"
                    <| fun _ -> Assert.Equal("", [], findAnagrams [ "patter" ] "tapper")

                    testCase "Words are not anagrams of themselves (case-insensitive)"
                    <| fun _ -> Assert.Equal("", [], findAnagrams [ "BANANA"; "Banana"; "banana" ] "BANANA")

                    testCase "Words other than themselves can be anagrams"
                    <| fun _ -> Assert.Equal("", [ "Silent" ], findAnagrams [ "Listen"; "Silent"; "LISTEN" ] "LISTEN") ] ]

    [<EntryPoint>]
    let main _ = run suite
