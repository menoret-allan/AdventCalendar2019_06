module Tests

open Xunit
open Core.Space
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




// ACCEPTANCE TESTS

[<Fact>]
let ``Calculate total orbits direct and indirect`` () =
    let input = """COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L"""
    input |> calculateOrbits |> should equal 42


[<Fact>]
let ``Calculate total orbits direct and indirect with unordered input`` () =
    let input = """D)I
B)C
C)D
E)F
B)G
G)H
COM)B
E)J
J)K
D)E
K)L"""
    input |> calculateOrbits |> should equal 42

