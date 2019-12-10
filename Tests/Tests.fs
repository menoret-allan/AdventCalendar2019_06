module Tests

open Xunit
open Core.Space
open FsUnit

[<Fact>]
let ``My test`` () =
    Assert.True(true)







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