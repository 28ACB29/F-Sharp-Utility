namespace FSUtility

open System

module ListIndexed =

    let private cons (head:'a) (tail:'a list) = head::tail

    let private consBack (tail:'a list) (head:'a) = head::tail

    let choosei (chooser:int -> 'a -> 'b option) (genericList:'a list):'b list =
        let rec seive (i:int) (list:'a list) =
            match list with
            | [] -> []
            | (head:'a)::(tail:'a list) ->
                match chooser i head with
                | Some(value:'b) ->
                    tail
                    |> seive (i + 1)
                    |> cons value
                | None -> seive (i + 1) tail
        match genericList with
        | [] -> []
        | _ ->
            genericList
            |> seive 0

    let collecti (mapper:int -> 'a -> 'b list) (genericList:'a list):'b list =
        let rec tailCall (i:int) (differenceList:'b list -> 'b list) (list:'a list):'b list =
            match list with
            | [] -> differenceList []
            | (head:'a)::(tail:'a list) -> tailCall (i + 1) (List.append (differenceList (mapper i head))) tail
        match genericList with
        | [] -> []
        | _ ->
            genericList
            |> tailCall 0 (List.append [])

    let existsi (predicate:int -> 'a -> bool) (genericList:'a list):bool =
        let rec seive (i:int) (list:'a list):bool =
            match list with
            | [] -> false
            | (head:'a)::(tail:'a list) ->
                match predicate i head with
                | true -> true
                | false ->
                    tail
                    |> seive (i + 1)
        match genericList with
        | [] -> false
        | _ ->
            genericList
            |> seive 0

    let filteri (predicate:int -> 'a -> bool) (genericList:'a list):'a list =
        let rec seive (i:int) (differenceList:'a list -> 'a list) (list:'a list):'a list =
            match list with
            | [] -> differenceList []
            | (head:'a)::(tail:'a list) ->
                match predicate i head with
                | true ->
                    tail
                    |> seive (i + 1) (differenceList << cons head)
                | false ->
                    tail
                    |> seive (i + 1) differenceList
        match genericList with
        | [] -> []
        | _ ->
            genericList
            |> seive 0 id

    let foldi (folder:int -> 'a -> 'b -> 'a) (state:'a) (genericList:'b list):'a =
        let rec tailCall (i:int) (accumulator:'a) (list:'b list):'a =
            match list with
            | [] -> accumulator
            | (head:'b)::(tail:'b list) -> tailCall (i + 1) (folder i accumulator head) tail
        match genericList with
        | [] -> state
        | _ ->
            genericList
            |> tailCall 0 state

    let foldBacki (folder:int -> 'b -> 'a -> 'a) (genericList:'b list) (state:'a):'a =
        let rec future (i:int) (list:'b list) (accumulator:'a):'a =
            match list with
            | [] -> accumulator
            | (head:'b)::(tail:'b list) -> folder i head (future (i + 1) tail accumulator)
        match genericList with
        | [] -> state
        | _ -> future 0 genericList state

    let foralli (predicate:int -> 'a -> bool) (genericList:'a list):bool =
        let rec seive (i:int) (list:'a list):bool =
            match list with
            | [] -> true
            | (head:'a)::(tail:'a list) ->
                match predicate i head with
                | true ->
                    tail
                    |> seive (i + 1)
                | false -> false
        match genericList with
        | [] -> true
        | _ ->
            genericList
            |> seive 0

    let partitioni (predicate:int -> 'a -> bool) (genericList:'a list):'a list * 'a list =
        let diverter (i:int) (trueDifferenceList:'a list -> 'a list, falseDifferenceList:'a list -> 'a list) (element:'a):('a list -> 'a list) * ('a list -> 'a list) =
            match predicate i element with
            | true -> (trueDifferenceList << cons element, falseDifferenceList)
            | false -> (trueDifferenceList, falseDifferenceList << cons element)
        let rec tailCall (i:int) (accumulator:('a list -> 'a list) * ('a list -> 'a list)) (list:'a list):('a list -> 'a list) * ('a list -> 'a list) =
            match list with
            | [] -> accumulator
            | (head:'a)::(tail:'a list) -> tailCall (i + 1) (diverter i accumulator head) tail
        match genericList with
        | [] -> ([], [])
        | _ ->
            genericList
            |> tailCall 0 (id, id)
            |> (fun (trueDifferenceList:'a list -> 'a list, falseDifferenceList:'a list -> 'a list) -> (trueDifferenceList [], falseDifferenceList []))

    let reducei (reduction:int -> 'a -> 'a -> 'a) (genericList:'a list):'a =
        let rec tailCall (i:int) (accumulator:'a) (list:'a list):'a =
            match list with
            | [] -> accumulator
            | (head:'a)::(tail:'a list) -> tailCall (i + 1) (reduction i accumulator head) tail
        match genericList with
        | [] -> raise (new ArgumentException())
        | (head:'a)::(tail:'a list) ->
            tail
            |> tailCall 0 head

    let reduceBacki (reduction:int -> 'a -> 'a -> 'a) (genericList:'a list):'a =
        let rec future (i:int) (list:'a list) (accumulator:'a):'a =
            match list with
            | [] -> accumulator
            | (head:'a)::(tail:'a list) -> reduction i head (future (i + 1) tail accumulator)
        match genericList with
        | [] -> raise (new ArgumentException())
        | (head:'a)::(tail:'a list) -> future 0 tail head

    let scani (folder:int -> 'a -> 'b -> 'a) (state:'a) (genericList:'b list):'a list =
        let rec tailCall (i:int) (accumulator:'a) (differenceList:'a list -> 'a list) (list:'b list):'a list =
            match list with
            | [] -> differenceList []
            | (head:'b)::(tail:'b list) ->
                let newState:'a = folder i accumulator head
                tail
                |> tailCall (i + 1) newState (differenceList << cons newState)
        match genericList with
        | [] -> [state]
        | _ ->
            genericList
            |> tailCall 0 state (cons state)

    let scanBacki (folder:int -> 'b -> 'a -> 'a) (genericList:'b list) (state:'a):'a list =
        let rec future (i:int) (state:'a) (list:'b list) (accumulator:'a list):'a list =
            match list with
            | [] -> accumulator
            | (head:'b)::(tail:'b list) ->
                let newAccumulator:'a list = future (i + 1) state tail accumulator
                newAccumulator
                |> cons (folder i head newAccumulator.Head)
        match genericList with
        | [] -> [state]
        | _ -> future 0 state genericList [state]
