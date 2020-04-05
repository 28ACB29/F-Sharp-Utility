namespace FSUtility

open System

module SequenceActivePatterns =

    let private BoolToOption (result:bool) =
        match result with
        | true -> Some()
        | false -> None

    let (|SeqExactlyOne|_|) (source:'a seq) =
        match source with
        | null -> None
        | _ ->
            try
                source
                |> Seq.exactlyOne
                |> Some
            with
                | _ -> None

    let (|SeqExists|_|) (predicate:'a -> bool) (source:'a seq) =
        match source with
        | null -> None
        | _ ->
            source
            |> Seq.exists predicate
            |> BoolToOption

    let (|SeqFind|_|) (predicate:'a -> bool) (source:'a seq) =
        match source with
        | null -> None
        | _ ->
            source
            |> Seq.tryFind predicate

    let (|SeqFindBack|_|) (predicate:'a -> bool) (source:'a seq) =
        match source with
        | null -> None
        | _ ->
            source
            |> Seq.tryFindBack predicate

    let (|SeqFindIndex|_|) (predicate:'a -> bool) (source:'a seq) =
        match source with
        | null -> None
        | _ ->
            source
            |> Seq.tryFindIndex predicate

    let (|SeqFindIndexBack|_|) (predicate:'a -> bool) (source:'a seq) =
        match source with
        | null -> None
        | _ ->
            source
            |> Seq.tryFindIndexBack predicate

    let (|SeqForAll|_|) (predicate:'a -> bool) (source:'a seq) =
        match source with
        | null -> None
        | _ ->
            source
            |> Seq.forall predicate
            |> BoolToOption

    let (|SeqHead|_|) (source:'a seq) =
        match source with
        | null -> None
        | _ ->
            source
            |> Seq.tryHead

    let (|SeqIsEmpty|_|) (source:'a seq) =
        match source with
        | null -> None
        | _ ->
            source
            |> Seq.isEmpty
            |> BoolToOption

    let (|SeqItem|_|) (index:int) (source:'a seq) =
        match source with
        | null -> None
        | _ ->
            source
            |> Seq.tryItem index

    let (|SeqLast|_|) (source:'a seq) =
        match source with
        | null -> None
        | _ ->
            source
            |> Seq.tryLast

    let (|SeqPick|_|) (chooser:'a -> 'b option) (source:'a seq) =
        match source with
        | null -> None
        | _ ->
            source
            |> Seq.tryPick chooser

    let (|SeqTail|_|) (source:'a seq) =
        match source with
        | null -> None
        | _ ->
            try
                source
                |> Seq.tail
                |> Some
            with
                | _ -> None

