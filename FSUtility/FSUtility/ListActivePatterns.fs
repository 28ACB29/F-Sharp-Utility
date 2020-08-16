namespace FSUtility

open System

module ListActivePatterns =

    let private boolToOption (result:bool) =
        match result with
        | true -> Some()
        | false -> None

    let private exceptionToOption (fnctn:'a -> 'b) (value:'a):'b option =
            try
                value
                |> fnctn
                |> Some
            with
                | _ -> None

    let private bind (binder:'a list -> 'b) (value:'a list):'b option =
        match value with
        | [] -> None
        | _ ->
            value
            |> binder
            |> Some

    let (|Contains|_|) (value:'a) (source:'a list) = bind (List.contains value >> boolToOption) source

    let (|ExactlyOne|_|) (source:'a list) = bind (exceptionToOption List.exactlyOne) source

    let (|Exists|_|) (predicate:'a -> bool) (source:'a list) = bind (List.exists predicate >> boolToOption) source

    let (|Find|_|) (predicate:'a -> bool) (source:'a list) = bind (List.tryFind predicate) source

    let (|FindBack|_|) (predicate:'a -> bool) (source:'a list) = bind (List.tryFindBack predicate) source

    let (|FindIndex|_|) (predicate:'a -> bool) (source:'a list) = bind (List.tryFindIndex predicate) source

    let (|FindIndexBack|_|) (predicate:'a -> bool) (source:'a list) = bind (List.tryFindIndexBack predicate) source

    let (|ForAll|_|) (predicate:'a -> bool) (source:'a list) = bind (List.forall predicate >> boolToOption) source

    let (|Item|_|) (index:int) (source:'a list) = bind (List.tryItem index) source

    let (|Last|_|) (source:'a list) = bind List.tryLast source

    let (|Pick|_|) (chooser:'a -> 'b option) (source:'a list) = bind (List.tryPick chooser) source

