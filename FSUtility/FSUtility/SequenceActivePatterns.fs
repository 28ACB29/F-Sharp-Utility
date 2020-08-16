namespace FSUtility

open System

module SequenceActivePatterns =

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

    let private bind (binder:'a seq -> 'b) (value:'a seq):'b option =
        match value with
        | null -> None
        | _ ->
            value
            |> binder
            |> Some

    let (|Contains|_|) (value:'a) (source:'a seq) = bind (Seq.contains value >> boolToOption) source

    let (|ExactlyOne|_|) (source:'a seq) = bind (exceptionToOption Seq.exactlyOne) source

    let (|Exists|_|) (predicate:'a -> bool) (source:'a seq) = bind (Seq.exists predicate >> boolToOption) source

    let (|Find|_|) (predicate:'a -> bool) (source:'a seq) = bind (Seq.tryFind predicate) source

    let (|FindBack|_|) (predicate:'a -> bool) (source:'a seq) = bind (Seq.tryFindBack predicate) source

    let (|FindIndex|_|) (predicate:'a -> bool) (source:'a seq) = bind (Seq.tryFindIndex predicate) source

    let (|FindIndexBack|_|) (predicate:'a -> bool) (source:'a seq) = bind (Seq.tryFindIndexBack predicate) source

    let (|ForAll|_|) (predicate:'a -> bool) (source:'a seq) = bind (Seq.forall predicate >> boolToOption) source

    let (|Head|_|) (source:'a seq) = bind Seq.tryHead source

    let (|IsEmpty|_|) (source:'a seq) = bind (Seq.isEmpty >> boolToOption) source

    let (|Item|_|) (index:int) (source:'a seq) = bind (Seq.tryItem index) source

    let (|Last|_|) (source:'a seq) = bind Seq.tryLast source

    let (|Pick|_|) (chooser:'a -> 'b option) (source:'a seq) = bind (Seq.tryPick chooser) source

    let (|Tail|_|) (source:'a seq) = bind (exceptionToOption Seq.tail) source

