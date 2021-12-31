module Tests =
    open Fuchu
    open KindergartenGarden


    let suite =
        testList
            "Test Suite"
            [ testList
                  "Basic tests"
                  [ testCase "Alice"
                    <| fun _ ->
                        Assert.Equal(
                            "",
                            [ Plant.Clover
                              Plant.Grass
                              Plant.Radishes
                              Plant.Clover ],
                            plants "VVCG\nVVRC" "Bob"
                        )

                    testCase "Bob"
                    <| fun _ ->
                        Assert.Equal(
                            "",
                            [ Plant.Radishes
                              Plant.Clover
                              Plant.Grass
                              Plant.Grass ],
                            plants "RC\nGG" "Alice"
                        )

                    ] ]

    [<EntryPoint>]
    let main _ = run suite
