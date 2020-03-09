namespace FSUtility

open System

module CollectionActivePatterns =

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

    let (|SeqContains|_|) (value:'a) (source:'a seq) =
        match source with
        | null -> None
        | _ ->
            source
            |> Seq.contains value
            |> BoolToOption

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

