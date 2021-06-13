namespace FSUtility

open System

module OptionNullable =

    let private roundTrip (func:'a option -> 'b option):(Nullable<'a> -> Nullable<'b>) =
        Option.ofNullable
        >> func
        >> Option.toNullable

    let (|Null|Exists|) (nullable:Nullable<'a>) =
        match nullable.HasValue with
        | false -> Null
        | true -> Exists(nullable.Value)

    let bind (binder:'a -> Nullable<'b>) (nullable:Nullable<'a>):Nullable<'b> =
        match nullable with
        | Null -> Nullable<'b>()
        | Exists(value:'a) -> binder value

    let contains (value:'a) (nullable:Nullable<'a>):bool =
        match nullable with
        | Null -> false
        | Exists(out:'a) -> value = out

    let count (nullable:Nullable<'a>):int =
        match nullable with
        | Null -> 0
        | _ -> 1

    let defaultValue (nullable:Nullable<'a>):'a =
        match nullable with
        | Null -> Unchecked.defaultof<'a>
        | Exists(value:'a) -> value

    let exists (predicate:Nullable<'a> -> bool) (nullable:Nullable<'a>):bool =
        match nullable with
        | Null -> false
        | _ -> predicate nullable

    let filter (predicate:'a -> bool) (nullable:Nullable<'a>):Nullable<'a> =
        match nullable with
        | Null -> Nullable<'a>()
        | Exists(value:'a) ->
            match predicate value with
            | true -> nullable
            | false -> Nullable<'a>()

    let fold (folder:'b -> 'a -> 'b) (state:'b) (nullable:Nullable<'a>):'b =
        match nullable with
        | Null -> state
        | Exists(value:'a) -> folder state value

    let foldBack (folder:'a -> 'b-> 'b) (state:'b) (nullable:Nullable<'a>):'b =
        match nullable with
        | Null -> state
        | Exists(value:'a) -> folder value state

    let forAll (predicate:Nullable<'a> -> bool) (nullable:Nullable<'a>):bool =
        match nullable with
        | Null -> true
        | _ -> predicate nullable

    let isNone (nullable:Nullable<'a>):bool =
        match nullable with
        | Null -> true
        | _ -> false

    let isSome (nullable:Nullable<'a>):bool =
        match nullable with
        | Null -> false
        | _ -> true

    let iter (action:'a -> unit) (nullable:Nullable<'a>):unit =
        match nullable with
        | Null -> ()
        | Exists(value:'a) -> action value

    let map (mapper:'a -> 'b) (nullable:Nullable<'a>):Nullable<'b> =
        match nullable with
        | Null -> Nullable<'b>()
        | Exists(value:'a) -> Nullable<'b>(mapper value)

    let map2 (mapper:'a -> 'b -> 'c) (nullable:Nullable<'a>) (nullable2:Nullable<'b>):Nullable<'c> =
        match nullable, nullable2 with
        | Exists(value:'a), Exists(value2:'b) -> Nullable<'c>(mapper value value2)
        | _ -> Nullable<'c>()

    let map3 (mapper:'a -> 'b -> 'c -> 'd) (nullable:Nullable<'a>) (nullable2:Nullable<'b>) (nullable3:Nullable<'c>):Nullable<'d> =
        match nullable, nullable2, nullable3 with
        | Exists(value:'a), Exists(value2:'b), Exists(value3:'c) -> Nullable<'d>(mapper value value2 value3)
        | _ -> Nullable<'d>()

    let ofOption (option:'a option):Nullable<'a> =
        match option with
        | None -> Nullable<'a>()
        | Some(value:'a) -> Nullable<'a>(value)

    let toArray (nullable:Nullable<'a>):'a array =
        match nullable with
        | Null -> [||]
        | Exists(value:'a) -> [|value|]

    let toList (nullable:Nullable<'a>):'a list =
        match nullable with
        | Null -> []
        | Exists(value:'a) -> [value]

    let toOption (nullable:Nullable<'a>):'a option =
        match nullable with
        | Null -> None
        | Exists(value:'a) -> Some(value)