module AtbashCipherTests =
    open Fuchu
    open AtbashCipher


    let suite =
        testList
            "AtbashCipher Suite"
            [ testList
                  "AtbashCipher Encode tests"
                  [

                    testCase "Encode yes"
                    <| fun _ -> Assert.Equal("", "bvh", encode "yes")

                    testCase "Encode no"
                    <| fun _ -> Assert.Equal("", "ml", encode "no")

                    testCase "Encode OMG"
                    <| fun _ -> Assert.Equal("", "lnt", encode "OMG")

                    testCase "Encode spaces"
                    <| fun _ -> Assert.Equal("", "lnt", encode "O M G")

                    testCase "Encode mindblowingly"
                    <| fun _ -> Assert.Equal("", "nrmwy oldrm tob", encode "mindblowingly")

                    testCase "Encode numbers"
                    <| fun _ -> Assert.Equal("", "gvhgr mt123 gvhgr mt", encode "Testing,1 2 3, testing.")

                    testCase "Encode deep thought"
                    <| fun _ -> Assert.Equal("", "gifgs rhurx grlm", encode "Truth is fiction.")

                    testCase "Encode all the letters"
                    <| fun _ ->
                        Assert.Equal(
                            "",
                            "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt",
                            encode "The quick brown fox jumps over the lazy dog."
                        )

                    testCase "Decode exercism"
                    <| fun _ -> Assert.Equal("", "exercism", decode "vcvix rhn")

                    testCase "Decode a sentence"
                    <| fun _ ->
                        Assert.Equal(
                            "",
                            "anobstacleisoftenasteppingstone",
                            decode "zmlyh gzxov rhlug vmzhg vkkrm thglm v"
                        )

                    testCase "Decode numbers"
                    <| fun _ -> Assert.Equal("", "testing123testing", decode "gvhgr mt123 gvhgr mt")

                    testCase "Decode all the letters"
                    <| fun _ ->
                        Assert.Equal(
                            "",
                            "thequickbrownfoxjumpsoverthelazydog",
                            decode "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt"
                        )

                    testCase "Decode with too many spaces"
                    <| fun _ -> Assert.Equal("", "exercism", decode "vc vix    r hn")

                    testCase "Decode with no spaces"
                    <| fun _ ->
                        Assert.Equal("", "anobstacleisoftenasteppingstone", decode "zmlyhgzxovrhlugvmzhgvkkrmthglmv") ] ]

    [<EntryPoint>]
    let main _ = run suite
