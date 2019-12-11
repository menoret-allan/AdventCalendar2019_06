namespace Core

open System
open Parse

module Space =
    type OrbitSystem = {name:string; distance:int; subsystems:OrbitSystem list}

    //let parseRelation (relation:string) =
    //    let result = relation.Split ')'
    //    (result |> Seq.head, result |> Seq.last)

    //let parseInput (input:string) =
    //    input.Split([|"\r\n";"\n"|], StringSplitOptions.RemoveEmptyEntries) |> Seq.map parseRelation |> Seq.toList

    let rec addRelation a b (tree:OrbitSystem) =
        if (tree.name = a) then {name = tree.name; distance=tree.distance;subsystems=({name=b;distance=tree.distance+1;subsystems=[]}::tree.subsystems)}
        else {name = tree.name; distance=tree.distance; subsystems=(tree.subsystems |> Seq.map(addRelation a b) |> Seq.toList)}

    let rec buildTreeRec (orbits:list<string * string>) (tree:OrbitSystem) (dones:list<string>) =
        match orbits with
        | [] -> tree
        | (A, B)::rest when dones |> List.contains A -> buildTreeRec rest (addRelation A B tree) (B::dones)
        | elem::rest -> buildTreeRec (rest @ [elem]) tree dones

    let buildTree (orbits:list<string * string>) =
        buildTreeRec orbits {name="COM"; distance=0;subsystems=[]} ["COM"]

    let rec count (tree:OrbitSystem) =
        tree.subsystems |> List.fold (fun acc subSystem -> acc + (count subSystem)) tree.distance

    let calculateOrbits input =
        let tree = input |> parseInput |> buildTree
        tree |> count
