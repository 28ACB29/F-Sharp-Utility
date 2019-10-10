namespace FSUtility

open System

module Collections =

    let Cons (head:'a) (tail:'a list) = head::tail

    let rec private tailCall (remainder:'a list) (differenceList) =
        match remainder with
        | [] -> differenceList
        | (head:'a)::(tail:'a list) -> tailCall (tail) (differenceList << Cons head)

    let DifferenceList (genericList:'a list):'a list -> 'a list =
        match genericList with
        | [] -> id
        | (head:'a)::(tail:'a list) -> tailCall (tail) (Cons head)

    let (|Empty|HeadTail|) (source:'a seq) =
        match Seq.isEmpty source with
        | true -> Empty
        | false -> HeadTail(Seq.head source, Seq.tail source)

    let (|ArrayFind|_|) (predicate:'a -> bool) (source:'a array) = Array.tryFind predicate source

    let (|ArrayFindBack|_|) (predicate:'a -> bool) (source:'a array) = Array.tryFindBack predicate source

    let (|ArrayFindIndex|_|) (predicate:'a -> bool) (source:'a array) = Array.tryFindIndex predicate source

    let (|ArrayFindIndexBack|_|) (predicate:'a -> bool) (source:'a array) = Array.tryFindIndexBack predicate source

    let (|ArrayHead|_|) (source:'a array) = Array.tryHead source

    let (|ArrayItem|_|) (index:int) (source:'a array) = Array.tryItem index source

    let (|ArrayLast|_|) (source:'a array) = Array.tryLast source

    let (|ArrayPick|_|) (chooser:'a -> 'b option) (source:'a array) = Array.tryPick chooser source

    let (|ListFind|_|) (predicate:'a -> bool) (source:'a list) = List.tryFind predicate source

    let (|ListFindBack|_|) (predicate:'a -> bool) (source:'a list) = List.tryFindBack predicate source

    let (|ListFindIndex|_|) (predicate:'a -> bool) (source:'a list) = List.tryFindIndex predicate source

    let (|ListFindIndexBack|_|) (predicate:'a -> bool) (source:'a list) = List.tryFindIndexBack predicate source

    let (|ListHead|_|) (source:'a list) = List.tryHead source

    let (|ListItem|_|) (index:int) (source:'a list) = List.tryItem index source

    let (|ListLast|_|) (source:'a list) = List.tryLast source

    let (|ListPick|_|) (chooser:'a -> 'b option) (source:'a list) = List.tryPick chooser source

    let (|SeqFind|_|) (predicate:'a -> bool) (source:'a seq) = Seq.tryFind predicate source

    let (|SeqFindBack|_|) (predicate:'a -> bool) (source:'a seq) = Seq.tryFindBack predicate source

    let (|SeqFindIndex|_|) (predicate:'a -> bool) (source:'a seq) = Seq.tryFindIndex predicate source

    let (|SeqFindIndexBack|_|) (predicate:'a -> bool) (source:'a seq) = Seq.tryFindIndexBack predicate source

    let (|SeqHead|_|) (source:'a seq) = Seq.tryHead source

    let (|SeqItem|_|) (index:int) (source:'a seq) = Seq.tryItem index source

    let (|SeqLast|_|) (source:'a seq) = Seq.tryLast source

    let (|SeqPick|_|) (chooser:'a -> 'b option) (source:'a seq) = Seq.tryPick chooser source
