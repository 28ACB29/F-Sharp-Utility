namespace FSUtility

open System

module CollectionActivePatterns =

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

    let private arrayBind (binder:'a array -> 'b) (value:'a array):'b option =
        match value with
        | null -> None
        | _ ->
            value
            |> binder
            |> Some

    let private listBind (binder:'a list -> 'b) (value:'a list):'b option =
        match value with
        | [] -> None
        | _ ->
            value
            |> binder
            |> Some

    let private seqBind (binder:'a seq -> 'b) (value:'a seq):'b option =
        match value with
        | null -> None
        | _ ->
            value
            |> binder
            |> Some

    let (|ArrayContains|_|) (value:'a) (source:'a array) = arrayBind (Array.contains value >> boolToOption) source

    let (|ArrayExactlyOne|_|) (source:'a array) = arrayBind (exceptionToOption Array.exactlyOne) source

    let (|ArrayExists|_|) (predicate:'a -> bool) (source:'a array) = arrayBind (Array.exists predicate >> boolToOption) source

    let (|ArrayFind|_|) (predicate:'a -> bool) (source:'a array) = arrayBind (Array.tryFind predicate) source

    let (|ArrayFindBack|_|) (predicate:'a -> bool) (source:'a array) = arrayBind (Array.tryFindBack predicate) source

    let (|ArrayFindIndex|_|) (predicate:'a -> bool) (source:'a array) = arrayBind (Array.tryFindIndex predicate) source

    let (|ArrayFindIndexBack|_|) (predicate:'a -> bool) (source:'a array) = arrayBind (Array.tryFindIndexBack predicate) source

    let (|ArrayForAll|_|) (predicate:'a -> bool) (source:'a array) = arrayBind (Array.forall predicate >> boolToOption) source

    let (|ArrayHead|_|) (source:'a array) = arrayBind Array.tryHead source

    let (|ArrayItem|_|) (index:int) (source:'a array) = arrayBind (Array.tryItem index) source

    let (|ArrayLast|_|) (source:'a array) = arrayBind Array.tryLast source

    let (|ArrayPick|_|) (chooser:'a -> 'b option) (source:'a array) = arrayBind (Array.tryPick chooser) source

    let (|ArrayTail|_|) (source:'a array) = arrayBind (exceptionToOption Array.tail) source

    let (|ListContains|_|) (value:'a) (source:'a list) = listBind (List.contains value >> boolToOption) source

    let (|ListExactlyOne|_|) (source:'a list) = listBind (exceptionToOption List.exactlyOne) source

    let (|ListExists|_|) (predicate:'a -> bool) (source:'a list) = listBind (List.exists predicate >> boolToOption) source

    let (|ListFind|_|) (predicate:'a -> bool) (source:'a list) = listBind (List.tryFind predicate) source

    let (|ListFindBack|_|) (predicate:'a -> bool) (source:'a list) = listBind (List.tryFindBack predicate) source

    let (|ListFindIndex|_|) (predicate:'a -> bool) (source:'a list) = listBind (List.tryFindIndex predicate) source

    let (|ListFindIndexBack|_|) (predicate:'a -> bool) (source:'a list) = listBind (List.tryFindIndexBack predicate) source

    let (|ListForAll|_|) (predicate:'a -> bool) (source:'a list) = listBind (List.forall predicate >> boolToOption) source

    let (|ListItem|_|) (index:int) (source:'a list) = listBind (List.tryItem index) source

    let (|ListLast|_|) (source:'a list) = listBind List.tryLast source

    let (|ListPick|_|) (chooser:'a -> 'b option) (source:'a list) = listBind (List.tryPick chooser) source

    let (|SeqContains|_|) (value:'a) (source:'a seq) = seqBind (Seq.contains value >> boolToOption) source

    let (|SeqExactlyOne|_|) (source:'a seq) = seqBind (exceptionToOption Seq.exactlyOne) source

    let (|SeqExists|_|) (predicate:'a -> bool) (source:'a seq) = seqBind (Seq.exists predicate >> boolToOption) source

    let (|SeqFind|_|) (predicate:'a -> bool) (source:'a seq) = seqBind (Seq.tryFind predicate) source

    let (|SeqFindBack|_|) (predicate:'a -> bool) (source:'a seq) = seqBind (Seq.tryFindBack predicate) source

    let (|SeqFindIndex|_|) (predicate:'a -> bool) (source:'a seq) = seqBind (Seq.tryFindIndex predicate) source

    let (|SeqFindIndexBack|_|) (predicate:'a -> bool) (source:'a seq) = seqBind (Seq.tryFindIndexBack predicate) source

    let (|SeqForAll|_|) (predicate:'a -> bool) (source:'a seq) = seqBind (Seq.forall predicate >> boolToOption) source

    let (|SeqHead|_|) (source:'a seq) = seqBind Seq.tryHead source

    let (|SeqIsEmpty|_|) (source:'a seq) = seqBind (Seq.isEmpty >> boolToOption) source

    let (|SeqItem|_|) (index:int) (source:'a seq) = seqBind (Seq.tryItem index) source

    let (|SeqLast|_|) (source:'a seq) = seqBind Seq.tryLast source

    let (|SeqPick|_|) (chooser:'a -> 'b option) (source:'a seq) = seqBind (Seq.tryPick chooser) source

    let (|SeqTail|_|) (source:'a seq) = seqBind (exceptionToOption Seq.tail) source

