namespace FSUtility

open System

module SequenceIndexed =

    let private removeIndex (indexed:(int * 'a) seq):'a seq = Seq.map (fun (i:int, element:'a) -> element) indexed

    let choosei (chooser:int -> 'a -> 'b option) (genericSeq:'a seq):'b seq =
        genericSeq
        |> Seq.indexed
        |> Seq.choose (fun (i:int, element:'a) -> chooser i element)

    let collecti (mapper:int -> 'a -> 'b seq) (genericSeq:'a seq):'b seq =
        genericSeq
        |> Seq.indexed
        |> Seq.collect (fun (i:int, element:'a) -> mapper i element)

    let existsi (predicate:int -> 'a -> bool) (genericSeq:'a seq):bool =
        genericSeq
        |> Seq.indexed
        |> Seq.exists (fun (i:int, element:'a) -> predicate i element)

    let filteri (predicate:int -> 'a -> bool) (genericSeq:'a seq):'a seq =
        genericSeq
        |> Seq.indexed
        |> Seq.filter (fun (i:int, element:'a) -> predicate i element)
        |> removeIndex

    let foldi (folder:int -> 'a -> 'b -> 'a) (state:'a) (genericSeq:'b seq):'a =
        genericSeq
        |> Seq.indexed
        |> Seq.fold (fun (accumulator:'a) (i:int, element:'b) -> folder i accumulator element) state

    let foldBacki (folder:int -> 'b -> 'a -> 'a) (genericSeq:'b seq) (state:'a):'a =
        genericSeq
        |> Seq.indexed
        |> (fun (source:(int * 'b) seq) -> Seq.foldBack (fun (i:int, element:'b) (accumulator:'a) -> folder i element accumulator) source state)

    let foralli (predicate:int -> 'a -> bool) (genericSeq:'a seq):bool =
        genericSeq
        |> Seq.indexed
        |> Seq.forall (fun (i:int, element:'a) -> predicate i element)

    let partitioni (predicate:int -> 'a -> bool) (genericSeq:'a seq):'a seq seq =
        genericSeq
        |> Seq.indexed
        |> Seq.groupBy (fun (i:int, element:'a) -> predicate i element)
        |> Seq.map (fun (_, indexedSequence:(int * 'a) seq) -> removeIndex indexedSequence)

    let reducei (reduction:int -> 'a -> 'a -> 'a) (genericSeq:'a seq):'a =
        match genericSeq |> Seq.isEmpty with
        | true -> raise (new ArgumentException())
        | false ->
            genericSeq
            |> Seq.tail
            |> Seq.indexed
            |> Seq.fold (fun (accumulator:'a) (i:int, element:'a) -> reduction i accumulator element) (genericSeq |> Seq.head)

    let reduceBacki (reduction:int -> 'a -> 'a -> 'a) (genericSeq:'a seq):'a =
        let rec tailCall (i:int) (accumulator:'a):'a =
            match i > -1 with
            | true -> tailCall (i - 1) (reduction i (Seq.item i genericSeq) accumulator)
            | false -> accumulator
        match genericSeq |> Seq.isEmpty with
        | true -> raise (new ArgumentException())
        | false ->
            genericSeq
            |> Seq.tail
            |> Seq.indexed
            |> (fun (source:(int * 'a) seq) -> Seq.foldBack (fun (i:int, element:'a) (accumulator:'a) -> reduction i element accumulator) source (genericSeq |> Seq.head))

    let scani (folder:int -> 'a -> 'b -> 'a) (state:'a) (genericSeq:'b seq):'a seq =
       genericSeq
       |> Seq.indexed
       |> Seq.scan (fun (accumulator:'a) (i:int, element:'b) -> folder i accumulator element) state

    let scanBacki (folder:int -> 'b -> 'a -> 'a) (genericSeq:'b seq) (state:'a):'a seq =
       genericSeq
       |> Seq.indexed
       |> (fun (seq:(int * 'b) seq) -> Seq.scanBack (fun (i:int, element:'b) (accumulator:'a) -> folder i element accumulator) seq state)

