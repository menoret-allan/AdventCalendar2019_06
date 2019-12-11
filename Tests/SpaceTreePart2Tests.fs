module SpaceTreeTests

open Xunit
open Core.SpaceTree
open FsUnit


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
K)L
K)YOU
I)SAN"""
    input |> calculateOrbitsBetween "YOU" "SAN" |> should equal 4


[<Fact>]
let ``Calculate total orbits direct and indirect with unordered input`` () =
    let input = """G)H
B)C
J)K
C)D
D)E
E)F
B)G
D)I
COM)B
E)J
K)L
K)YOU
I)SAN"""
    input |> calculateOrbitsBetween "YOU" "SAN" |> should equal 4

