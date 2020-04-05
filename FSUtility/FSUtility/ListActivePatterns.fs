namespace FSUtility

open System

module ListActivePatterns =

    let private BoolToOption (result:bool) =
        match result with
        | true -> Some()
        | false -> None

    let (|ListContains|_|) (value:'a) (source:'a list) =
        match source with
        | [] -> None
        | _ ->
            source
            |> List.contains value
            |> BoolToOption

    let (|ListExactlyOne|_|) (source:'a list) =
        match source with
        | [] -> None
        | _ ->
            try
                source
                |> List.exactlyOne
                |> Some
            with
                | _ -> None

    let (|ListExists|_|) (predicate:'a -> bool) (source:'a list) =
        match source with
        | [] -> None
        | _ ->
            source
            |> List.exists predicate
            |> BoolToOption

    let (|ListFind|_|) (predicate:'a -> bool) (source:'a list) =
        match source with
        | [] -> None
        | _ ->
            source
            |> List.tryFind predicate

    let (|ListFindBack|_|) (predicate:'a -> bool) (source:'a list) =
        match source with
        | [] -> None
        | _ ->
            source
            |> List.tryFindBack predicate

    let (|ListFindIndex|_|) (predicate:'a -> bool) (source:'a list) =
        match source with
        | [] -> None
        | _ ->
            source
            |> List.tryFindIndex predicate

    let (|ListFindIndexBack|_|) (predicate:'a -> bool) (source:'a list) =
        match source with
        | [] -> None
        | _ ->
            source
            |> List.tryFindIndexBack predicate

    let (|ListForAll|_|) (predicate:'a -> bool) (source:'a list) =
        match source with
        | [] -> None
        | _ ->
            source
            |> List.forall predicate
            |> BoolToOption

    let (|ListItem|_|) (index:int) (source:'a list) =
        match source with
        | [] -> None
        | _ ->
            source
            |> List.tryItem index

    let (|ListLast|_|) (source:'a list) =
        match source with
        | [] -> None
        | _ ->
            source
            |> List.tryLast

    let (|ListPick|_|) (chooser:'a -> 'b option) (source:'a list) =
        match source with
        | [] -> None
        | _ ->
            source
            |> List.tryPick chooser

