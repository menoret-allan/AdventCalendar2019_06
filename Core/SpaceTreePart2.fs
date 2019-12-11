namespace Core

open Parse

module SpaceTree =
    let rec findPath currents target (map:Map<string, seq<(string*string)>> ) dones count =
        let cleaned = currents |> Seq.filter (fun x -> dones |> Set.contains x |> not) |> Set.ofSeq
        if cleaned |> Seq.contains target then count
        elif cleaned |> Seq.isEmpty then -42
        else findPath (cleaned |> Seq.map (fun x -> map |> Map.tryFind x) |> Seq.choose id |> Seq.concat |> Seq.map (fun (f, s) -> s)) target map (dones |> Set.union cleaned) (count + 1)      

    let calculateOrbitsBetween current target input =
        let list = input |> parseInput |> Seq.ofList
        let combinaison = list |> Seq.map (fun (f,s) -> (s,f)) |> Seq.append list |> Seq.groupBy (fun (f, _) -> f) |> Map.ofSeq
        let result = findPath [current] target combinaison (Set.ofSeq []) -2
        result
