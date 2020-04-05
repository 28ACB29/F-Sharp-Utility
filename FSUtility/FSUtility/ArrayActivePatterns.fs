namespace FSUtility

open System

module ArrayActivePatterns =

    let private BoolToOption (result:bool) =
        match result with
        | true -> Some()
        | false -> None

    let (|ArrayContains|_|) (value:'a) (source:'a array) =
        match source with
        | null -> None
        | _ ->
            source
            |> Array.contains value
            |> BoolToOption

    let (|ArrayExactlyOne|_|) (source:'a array) =
        match source with
        | null -> None
        | _ ->
            try
                source
                |> Array.exactlyOne
                |> Some
            with
                | _ -> None

    let (|ArrayExists|_|) (predicate:'a -> bool) (source:'a array) =
        match source with
        | null -> None
        | _ ->
            source
            |> Array.exists predicate
            |> BoolToOption

    let (|ArrayFind|_|) (predicate:'a -> bool) (source:'a array) =
        match source with
        | null -> None
        | _ ->
            source
            |> Array.tryFind predicate

    let (|ArrayFindBack|_|) (predicate:'a -> bool) (source:'a array) =
        match source with
        | null -> None
        | _ ->
            source
            |> Array.tryFindBack predicate

    let (|ArrayFindIndex|_|) (predicate:'a -> bool) (source:'a array) =
        match source with
        | null -> None
        | _ ->
            source
            |> Array.tryFindIndex predicate

    let (|ArrayFindIndexBack|_|) (predicate:'a -> bool) (source:'a array) =
        match source with
        | null -> None
        | _ ->
            source
            |> Array.tryFindIndexBack predicate

    let (|ArrayForAll|_|) (predicate:'a -> bool) (source:'a array) =
        match source with
        | null -> None
        | _ ->
            source
            |> Array.forall predicate
            |> BoolToOption

    let (|ArrayHead|_|) (source:'a array) =
        match source with
        | null -> None
        | _ ->
            source
            |> Array.tryHead

    let (|ArrayItem|_|) (index:int) (source:'a array) =
        match source with
        | null -> None
        | _ ->
            source
            |> Array.tryItem index

    let (|ArrayLast|_|) (source:'a array) =
        match source with
        | null -> None
        | _ ->
            source
            |> Array.tryLast

    let (|ArrayPick|_|) (chooser:'a -> 'b option) (source:'a array) =
        match source with
        | null -> None
        | _ ->
            source
            |> Array.tryPick chooser

    let (|ArrayTail|_|) (source:'a array) =
        match source with
        | null -> None
        | _ ->
            try
                source
                |> Array.tail
                |> Some
            with
                | _ -> None

