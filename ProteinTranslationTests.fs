module ProteinTranslationTests =
    open Fuchu
    open ProteinTranslation


    let suite =
        testList
            "ProteinTranslation Suite"
            [ testList
                  "ProteinTranslation Translate tests"
                  [

                    testCase "Methionine RNA sequence"
                    <| fun _ -> Assert.Equal("", [ "Methionine" ], proteins "AUG")

                    testCase "Phenylalanine RNA sequence 1"
                    <| fun _ -> Assert.Equal("", [ "Phenylalanine" ], proteins "UUU")

                    testCase "Phenylalanine RNA sequence 2"
                    <| fun _ -> Assert.Equal("", [ "Phenylalanine" ], proteins "UUC")

                    testCase "Leucine RNA sequence 1"
                    <| fun _ -> Assert.Equal("", [ "Leucine" ], proteins "UUA")

                    testCase "Leucine RNA sequence 2"
                    <| fun _ -> Assert.Equal("", [ "Leucine" ], proteins "UUG")

                    testCase "Serine RNA sequence 1"
                    <| fun _ -> Assert.Equal("", [ "Serine" ], proteins "UCU")

                    testCase "Serine RNA sequence 2"
                    <| fun _ -> Assert.Equal("", [ "Serine" ], proteins "UCC")

                    testCase "Serine RNA sequence 3"
                    <| fun _ -> Assert.Equal("", [ "Serine" ], proteins "UCA")

                    testCase "Serine RNA sequence 4"
                    <| fun _ -> Assert.Equal("", [ "Serine" ], proteins "UCG")

                    testCase "Tyrosine RNA sequence 1"
                    <| fun _ -> Assert.Equal("", [ "Tyrosine" ], proteins "UAU")

                    testCase "Tyrosine RNA sequence 2"
                    <| fun _ -> Assert.Equal("", [ "Tyrosine" ], proteins "UAC")

                    testCase "Cysteine RNA sequence 1"
                    <| fun _ -> Assert.Equal("", [ "Cysteine" ], proteins "UGU")

                    testCase "Cysteine RNA sequence 2"
                    <| fun _ -> Assert.Equal("", [ "Cysteine" ], proteins "UGC")

                    testCase "Tryptophan RNA sequence"
                    <| fun _ -> Assert.Equal("", [ "Tryptophan" ], proteins "UGG")

                    testCase "STOP codon RNA sequence 1"
                    <| fun _ -> Assert.Equal("", [], proteins "UAA")

                    testCase "STOP codon RNA sequence 2"
                    <| fun _ -> Assert.Equal("", [], proteins "UAG")

                    testCase "STOP codon RNA sequence 3"
                    <| fun _ -> Assert.Equal("", [], proteins "UGA")

                    testCase "Translate RNA strand into correct protein list"
                    <| fun _ ->
                        Assert.Equal(
                            "",
                            [ "Methionine"
                              "Phenylalanine"
                              "Tryptophan" ],
                            proteins "AUGUUUUGG"
                        )

                    testCase "Translation stops if STOP codon at beginning of sequence"
                    <| fun _ -> Assert.Equal("", [], proteins "UAGUGG")

                    testCase "Translation stops if STOP codon at end of two-codon sequence"
                    <| fun _ -> Assert.Equal("", [ "Tryptophan" ], proteins "UGGUAG")

                    testCase "Translation stops if STOP codon at end of three-codon sequence"
                    <| fun _ -> Assert.Equal("", [ "Methionine"; "Phenylalanine" ], proteins "AUGUUUUAA")

                    testCase "Translation stops if STOP codon in middle of three-codon sequence"
                    <| fun _ -> Assert.Equal("", [ "Tryptophan" ], proteins "UGGUAGUGG")

                    testCase "Translation stops if STOP codon in middle of six-codon sequence"
                    <| fun _ ->
                        Assert.Equal("", [ "Tryptophan"; "Cysteine"; "Tyrosine" ], proteins "UGGUGUUAUUAAUGGUUU") ] ]

    [<EntryPoint>]
    let main _ = run suite
