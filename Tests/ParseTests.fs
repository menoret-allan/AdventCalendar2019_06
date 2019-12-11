module ParseTests

open Xunit
open Core.Parse
open FsUnit

[<Fact>]
let ``Parse Relation 1`` () = 
    "COM)B" |> parseRelation |> should equal ("COM", "B")

[<Fact>]
let ``Parse input`` () = 
    let result = parseInput """COM)B
B)C
C)D
D)E
E)F
B)G
G)H"""
    result |> Seq.toList |> should equivalent [("COM", "B");("B", "C");("C", "D");("D", "E");("E", "F");("B", "G");("G", "H")]
