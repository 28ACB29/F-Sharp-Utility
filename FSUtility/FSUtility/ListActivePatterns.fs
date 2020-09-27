namespace FSUtility

open System

module ListActivePatterns =

    let private bindBool (fnctn:'a list -> bool) (value:'a list) =
        match value with
        | [] -> None
        | _ ->
            match fnctn value with
            | true -> Some()
            | false -> None

    let private bindException (fnctn:'a -> 'b) (value:'a):'b option =
        match value with
        | [] -> None
        | _ ->
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

    let (|Contains|_|) (value:'a) (source:'a list) = bindBool (List.contains value) source

    let (|ExactlyOne|_|) (source:'a list) = bindException List.exactlyOne source

    let (|Exists|_|) (predicate:'a -> bool) (source:'a list) = bindBool (List.exists predicate) source

    let (|Find|_|) (predicate:'a -> bool) (source:'a list) = bind (List.tryFind predicate) source

    let (|FindBack|_|) (predicate:'a -> bool) (source:'a list) = bind (List.tryFindBack predicate) source

    let (|FindIndex|_|) (predicate:'a -> bool) (source:'a list) = bind (List.tryFindIndex predicate) source

    let (|FindIndexBack|_|) (predicate:'a -> bool) (source:'a list) = bind (List.tryFindIndexBack predicate) source

    let (|ForAll|_|) (predicate:'a -> bool) (source:'a list) = bindBool (List.forall predicate) source

    let (|Item|_|) (index:int) (source:'a list) = bind (List.tryItem index) source

    let (|Last|_|) (source:'a list) = bind List.tryLast source

    let (|Pick|_|) (chooser:'a -> 'b option) (source:'a list) = bind (List.tryPick chooser) source

