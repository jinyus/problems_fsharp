module Tests =
    open Fuchu
    open Codewars.Duplicates


    let suite =

        let lowercase, uppercase =
            "abcdefghijklmnopqrstuvwxyz", "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

        testList
            "Test Suite"
            [ testList
                  "Basic tests"
                  [ testCase "Basic test"
                    <| fun _ -> Assert.Equal("", 0, duplicateCount "")
                    testCase "Basic test"
                    <| fun _ -> Assert.Equal("abcde", 0, duplicateCount "abcde")
                    testCase "Basic test"
                    <| fun _ -> Assert.Equal("abcdeaa", 1, duplicateCount "abcdeaa")
                    testCase "Basic test"
                    <| fun _ -> Assert.Equal("abcdeaB", 2, duplicateCount "abcdeaB")
                    testCase "Basic test"
                    <| fun _ -> Assert.Equal("Indivisibilities", 2, duplicateCount ("Indivisibilities"))
                    testCase "Basic test"
                    <| fun _ -> Assert.Equal(lowercase, 0, duplicateCount lowercase)
                    testCase "Basic test"
                    <| fun _ -> Assert.Equal(lowercase + "aaAb", 2, duplicateCount (lowercase + "aaAb"))
                    testCase "Basic test"
                    <| fun _ -> Assert.Equal(lowercase + lowercase, 26, duplicateCount (lowercase + lowercase))
                    testCase "Basic test"
                    <| fun _ -> Assert.Equal(lowercase + uppercase, 26, duplicateCount (lowercase + uppercase)) ] ]

    [<EntryPoint>]
    let main _ = run suite
