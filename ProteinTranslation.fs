module ProteinTranslation

open System

type Protein =
    | Methionine
    | Phenylalanine
    | Leucine
    | Serine
    | Tyrosine
    | Cysteine
    | Tryptophan

let condonToProtein (c: string) =
    match c with
    | "AUG" -> Some Methionine
    | "UUU"
    | "UUC" -> Some Phenylalanine
    | "UUA"
    | "UUG" -> Some Leucine
    | "UCU"
    | "UCC"
    | "UCA"
    | "UCG" -> Some Serine
    | "UAU"
    | "UAC" -> Some Tyrosine
    | "UGU"
    | "UGC" -> Some Cysteine
    | "UGG" -> Some Tryptophan
    | "UAA"
    | "UAG"
    | "UGA" -> None
    | _ -> None

let proteins (rna: string) =
    rna
    |> Seq.chunkBySize 3
    |> Seq.map (String.Concat >> condonToProtein)
    |> Seq.takeWhile Option.isSome
    |> Seq.map (Option.get >> string)
    |> Seq.toList


// proteins "AUG"
