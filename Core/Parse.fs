namespace Core

open System

module Parse =
    let parseRelation (relation:string) =
        let result = relation.Split ')'
        (result |> Seq.head, result |> Seq.last)

    let parseInput (input:string) =
        input.Split([|"\r\n";"\n"|], StringSplitOptions.RemoveEmptyEntries) |> Seq.map parseRelation |> Seq.toList
