namespace FSUtility

open System

module Nullable =

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

    let count (nullable:Nullable<'a>):int =
        match nullable with
        | Null -> 0
        | _ -> 1

    let exists (predicate:Nullable<'a> -> bool) (nullable:Nullable<'a>):bool =
        match nullable with
        | Null -> false
        | _ -> predicate nullable

    let forAll (predicate:Nullable<'a> -> bool) (nullable:Nullable<'a>):bool =
        match nullable with
        | Null -> true
        | _ -> predicate nullable

    let fold (folder:'b -> 'a -> 'b) (state:'b) (nullable:Nullable<'a>):'b =
        match nullable with
        | Null -> state
        | Exists(value:'a) -> folder state value

    let foldBack (folder:'a -> 'b-> 'b) (state:'b) (nullable:Nullable<'a>):'b =
        match nullable with
        | Null -> state
        | Exists(value:'a) -> folder value state

    let isNone (nullable:Nullable<'a>):bool =
        match nullable with
        | Null -> true
        | _ -> false

    let isSome (nullable:Nullable<'a>):bool =
        match nullable with
        | Null -> false
        | _ -> true

    let iter (action:Nullable<'a> -> unit) (nullable:Nullable<'a>):unit =
        match nullable with
        | Null -> ()
        | _ -> action nullable

    let map (mapper:'a -> 'b) (nullable:Nullable<'a>):Nullable<'b> =
        match nullable with
        | Null -> Nullable<'b>()
        | Exists(value:'a) -> Nullable<'b>(mapper value)

    let toArray (nullable:Nullable<'a>):'a array =
        match nullable with
        | Null -> [||]
        | Exists(value:'a) -> [|value|]

    let toList (nullable:Nullable<'a>):'a list =
        match nullable with
        | Null -> []
        | Exists(value:'a) -> [value]