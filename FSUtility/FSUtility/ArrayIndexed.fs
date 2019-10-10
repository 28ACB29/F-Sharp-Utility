namespace FSUtility

open System

module ArrayIndexed =

    let private removeIndex (indexed:(int * 'a) array):'a array = Array.map (fun (i:int, element:'a) -> element) indexed

    let choosei (chooser:int -> 'a -> 'b option) (genericArray:'a array):'b array =
        genericArray
        |> Array.indexed
        |> Array.choose (fun (i:int, element:'a) -> chooser i element)

    let collecti (mapper:int -> 'a -> 'b array) (genericArray:'a array):'b array =
        genericArray
        |> Array.indexed
        |> Array.collect (fun (i:int, element:'a) -> mapper i element)

    let existsi (predicate:int -> 'a -> bool) (genericArray:'a array):bool =
        let rec seive (i:int):bool =
            match i < genericArray.Length with
            | true ->
                match predicate i genericArray.[i] with
                | true -> true
                | false -> seive (i + 1)
            | false -> false
        match genericArray with
        | [||] -> false
        | _ -> seive 0

    let filteri (predicate:int -> 'a -> bool) (genericArray:'a array):'a array =
        genericArray
        |> Array.indexed
        |> Array.filter (fun (i:int, element:'a) -> predicate i element)
        |> removeIndex

    let foldi (folder:int -> 'a -> 'b -> 'a) (state:'a) (genericArray:'b array):'a =
        let rec tailCall (i:int) (accumulator:'a):'a =
            match i < genericArray.Length with
            | true -> tailCall (i + 1) (folder i accumulator genericArray.[i])
            | false -> accumulator
        match genericArray with
        | [||] -> state
        | _ -> tailCall 0 state

    let foldBacki (folder:int -> 'b -> 'a -> 'a) (genericArray:'b array) (state:'a):'a =
        let rec tailCall (i:int) (accumulator:'a):'a =
            match i > -1 with
            | true -> tailCall (i - 1) (folder i genericArray.[i] accumulator)
            | false -> accumulator
        match genericArray with
        | [||] -> state
        | _ -> tailCall (genericArray.Length - 1) state

    let foralli (predicate:int -> 'a -> bool) (genericArray:'a array):bool =
        let rec seive (i:int):bool =
            match i < genericArray.Length with
            | true ->
                match predicate i genericArray.[i] with
                | true -> seive (i + 1)
                | false -> false
            | false -> true
        match genericArray with
        | [||] -> true
        | _ -> seive 0

    let partitioni (predicate:int -> 'a -> bool) (genericArray:'a array):'a array * 'a array =
        genericArray
        |> Array.indexed
        |> Array.partition (fun (i:int, element:'a) -> predicate i element)
        |> (fun (trueIndexedArray:(int * 'a) array, falseIndexedArray:(int * 'a) array) -> (removeIndex trueIndexedArray, removeIndex falseIndexedArray))

    let reducei (reduction:int -> 'a -> 'a -> 'a) (genericArray:'a array):'a =
        let rec tailCall (i:int) (accumulator:'a):'a =
            match i < genericArray.Length with
            | true -> tailCall (i + 1) (reduction i accumulator genericArray.[i])
            | false -> accumulator
        match genericArray with
        | [||] -> raise (new ArgumentException())
        | _ -> tailCall 0 genericArray.[0]

    let reduceBacki (reduction:int -> 'a -> 'a -> 'a) (genericArray:'a array):'a =
        let rec tailCall (i:int) (accumulator:'a):'a =
            match i > -1 with
            | true -> tailCall (i - 1) (reduction i genericArray.[i] accumulator)
            | false -> accumulator
        match genericArray with
        | [||] -> raise (new ArgumentException())
        | _ -> tailCall (genericArray.Length - 1) genericArray.[(genericArray.Length - 1)]

    let scani (folder:int -> 'a -> 'b -> 'a) (state:'a) (genericArray:'b array):'a array =
       genericArray
       |> Array.indexed
       |> Array.scan (fun (accumulator:'a) (i:int, element:'b) -> folder i accumulator element) state

    let scanBacki (folder:int -> 'b -> 'a -> 'a) (genericArray:'b array) (state:'a):'a array =
       genericArray
       |> Array.indexed
       |> (fun (array:(int * 'b) array) -> Array.scanBack (fun (i:int, element:'b) (accumulator:'a) -> folder i element accumulator) array state)


