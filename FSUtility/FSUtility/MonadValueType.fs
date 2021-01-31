namespace FSUtility

open System

module MonadValueType =

    let (|Null|Exists|) (nullable:'a when 'a:null) =
        match nullable with
        | null -> Null
        | _ -> Exists(nullable)

    let bind (binder:'a -> 'b when 'a:null and 'b:null) (nullable:'a when 'a:null):'b =
        match nullable with
        | null -> null
        | _ -> binder nullable

    let count (nullable:'a when 'a:null):int =
        match nullable with
        | null -> 0
        | _ -> 1

    let exists (predicate:'a -> bool when 'a:null) (nullable:'a when 'a:null):bool =
        match nullable with
        | null -> false
        | _ -> predicate nullable

    let forAll (predicate:'a -> bool when 'a:null) (nullable:'a when 'a:null):bool =
        match nullable with
        | null -> true
        | _ -> predicate nullable

    let fold (folder:'b -> 'a -> 'b when 'a:null) (state:'b) (nullable:'a when 'a:null):'b =
        match nullable with
        | null -> state
        | _ -> folder state nullable

    let foldBack (folder:'a -> 'b-> 'b when 'a:null) (state:'b) (nullable:'a when 'a:null):'b =
        match nullable with
        | null -> state
        | _ -> folder nullable state

    let isNone (nullable:'a when 'a:null):bool =
        match nullable with
        | null -> true
        | _ -> false

    let isSome (nullable:'a when 'a:null):bool =
        match nullable with
        | null -> false
        | _ -> true

    let iter (action:'a -> unit when 'a:null) (nullable:'a when 'a:null):unit =
        match nullable with
        | null -> ()
        | _ -> action nullable

    let toArray (nullable:'a when 'a:null):'a array =
        match nullable with
        | null -> [||]
        | (value:'a) -> [|value|]

    let toList (nullable:'a when 'a:null):'a list =
        match nullable with
        | null -> []
        | (value:'a) -> [value]

