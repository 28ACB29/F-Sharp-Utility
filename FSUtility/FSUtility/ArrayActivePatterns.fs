namespace FSUtility

open System

module ArrayActivePatterns =

    let private bindBool (fnctn:'a array -> bool) (value:'a array) =
        match value with
        | null -> None
        | _ ->
            match fnctn value with
            | true -> Some()
            | false -> None

    let private bindException (fnctn:'a array -> 'b) (value:'a array):'b option =
        match value with
        | null -> None
        | _ ->
            try
                value
                |> fnctn
                |> Some
            with
                | _ -> None

    let private bind (binder:'a array -> 'b) (value:'a array):'b option =
        match value with
        | null -> None
        | _ ->
            value
            |> binder
            |> Some

    let (|Contains|_|) (value:'a) (source:'a array) = bindBool (Array.contains value) source

    let (|ExactlyOne|_|) (source:'a array) = bindException Array.exactlyOne source

    let (|Exists|_|) (predicate:'a -> bool) (source:'a array) = bindBool (Array.exists predicate) source

    let (|Find|_|) (predicate:'a -> bool) (source:'a array) = bind (Array.tryFind predicate) source

    let (|FindBack|_|) (predicate:'a -> bool) (source:'a array) = bind (Array.tryFindBack predicate) source

    let (|FindIndex|_|) (predicate:'a -> bool) (source:'a array) = bind (Array.tryFindIndex predicate) source

    let (|FindIndexBack|_|) (predicate:'a -> bool) (source:'a array) = bind (Array.tryFindIndexBack predicate) source

    let (|ForAll|_|) (predicate:'a -> bool) (source:'a array) = bindBool (Array.forall predicate) source

    let (|Head|_|) (source:'a array) = bind Array.tryHead source

    let (|Item|_|) (index:int) (source:'a array) = bind (Array.tryItem index) source

    let (|Last|_|) (source:'a array) = bind Array.tryLast source

    let (|Pick|_|) (chooser:'a -> 'b option) (source:'a array) = bind (Array.tryPick chooser) source

    let (|Tail|_|) (source:'a array) = bindException Array.tail source

