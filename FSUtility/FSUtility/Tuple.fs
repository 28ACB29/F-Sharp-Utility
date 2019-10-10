namespace FSUtility

open System

module Tuple =

    type Orders<'a, 'b, 'c, 'd, 'e, 'f, 'g, 'h> =
        | Single of 'a
        | Double of 'a * 'b
        | Triple of 'a * 'b * 'c
        | Quadruple of 'a * 'b * 'c * 'd
        | Quintuple of 'a * 'b * 'c * 'd * 'e
        | Hextuple of 'a * 'b * 'c * 'd * 'e * 'f
        | Heptuple of 'a * 'b * 'c * 'd * 'e * 'f * 'g
        | Octuple of 'a * 'b * 'c * 'd * 'e * 'f * 'g * 'h

    let first (tuple:Orders<'a, 'b, 'c, 'd, 'e, 'f, 'g, 'h>):'a option =
        match tuple with
        | Single(value:'a) -> Some(value)
        | Double(value:'a, _) -> Some(value)
        | Triple(value:'a, _, _) -> Some(value)
        | Quadruple(value:'a, _, _, _) -> Some(value)
        | Quintuple(value:'a, _, _, _, _) -> Some(value)
        | Hextuple(value:'a, _, _, _, _, _) -> Some(value)
        | Heptuple(value:'a, _, _, _, _, _, _) -> Some(value)
        | Octuple(value:'a, _, _, _, _, _, _, _) -> Some(value)

    let second (tuple:Orders<'a, 'b, 'c, 'd, 'e, 'f, 'g, 'h>):'b option =
        match tuple with
        | Double(_, value:'b) -> Some(value)
        | Triple(_, value:'b, _) -> Some(value)
        | Quadruple(_, value:'b, _, _) -> Some(value)
        | Quintuple(_, value:'b, _, _, _) -> Some(value)
        | Hextuple(_, value:'b, _, _, _, _) -> Some(value)
        | Heptuple(_, value:'b, _, _, _, _, _) -> Some(value)
        | Octuple(_, value:'b, _, _, _, _, _, _) -> Some(value)
        | _ -> None

    let third (tuple:Orders<'a, 'b, 'c, 'd, 'e, 'f, 'g, 'h>):'c option =
        match tuple with
        | Triple(_, _, value:'c) -> Some(value)
        | Quadruple(_, _, value:'c, _) -> Some(value)
        | Quintuple(_, _, value:'c, _, _) -> Some(value)
        | Hextuple(_, _, value:'c, _, _, _) -> Some(value)
        | Heptuple(_, _, value:'c, _, _, _, _) -> Some(value)
        | Octuple(_, _, value:'c, _, _, _, _, _) -> Some(value)
        | _ -> None

    let fourth (tuple:Orders<'a, 'b, 'c, 'd, 'e, 'f, 'g, 'h>):'d option =
        match tuple with
        | Quadruple(_, _, _, value:'d) -> Some(value)
        | Quintuple(_, _, _, value:'d, _) -> Some(value)
        | Hextuple(_, _, _, value:'d, _, _) -> Some(value)
        | Heptuple(_, _, _, value:'d, _, _, _) -> Some(value)
        | Octuple(_, _, _, value:'d, _, _, _, _) -> Some(value)
        | _ -> None

    let fifth (tuple:Orders<'a, 'b, 'c, 'd, 'e, 'f, 'g, 'h>):'e option =
        match tuple with
        | Quintuple(_, _, _, _, value:'e) -> Some(value)
        | Hextuple(_, _, _, _, value:'e, _) -> Some(value)
        | Heptuple(_, _, _, _, value:'e, _, _) -> Some(value)
        | Octuple(_, _, _, _, value:'e, _, _, _) -> Some(value)
        | _ -> None

    let sixth (tuple:Orders<'a, 'b, 'c, 'd, 'e, 'f, 'g, 'h>):'f option =
        match tuple with
        | Hextuple(_, _, _, _, _, value:'f) -> Some(value)
        | Heptuple(_, _, _, _, _, value:'f, _) -> Some(value)
        | Octuple(_, _, _, _, _, value:'f, _, _) -> Some(value)
        | _ -> None

    let seventh (tuple:Orders<'a, 'b, 'c, 'd, 'e, 'f, 'g, 'h>):'g option =
        match tuple with
        | Heptuple(_, _, _, _, _, _, value:'g) -> Some(value)
        | Octuple(_, _, _, _, _, _, value:'g, _) -> Some(value)
        | _ -> None

    let eigth (tuple:Orders<'a, 'b, 'c, 'd, 'e, 'f, 'g, 'h>):'h option =
        match tuple with
        | Octuple(_, _, _, _, _, _, _, value:'h) -> Some(value)
        | _ -> None

    let ofArray (genericArray:'a array):Orders<'a, 'a, 'a, 'a, 'a, 'a, 'a, 'a> option =
        match genericArray with
        | [|value1:'a|] -> Some(Single(value1))
        | [|value1:'a; value2:'a|] -> Some(Double(value1, value2))
        | [|value1:'a; value2:'a; value3:'a|] -> Some(Triple(value1, value2, value3))
        | [|value1:'a; value2:'a; value3:'a; value4:'a|] -> Some(Quadruple(value1, value2, value3, value4))
        | [|value1:'a; value2:'a; value3:'a; value4:'a; value5:'a|] -> Some(Quintuple(value1, value2, value3, value4, value5))
        | [|value1:'a; value2:'a; value3:'a; value4:'a; value5:'a; value6:'a|] -> Some(Hextuple(value1, value2, value3, value4, value5, value6))
        | [|value1:'a; value2:'a; value3:'a; value4:'a; value5:'a; value6:'a; value7:'a|] -> Some(Heptuple(value1, value2, value3, value4, value5, value6, value7))
        | [|value1:'a; value2:'a; value3:'a; value4:'a; value5:'a; value6:'a; value7:'a; value8:'a|] -> Some(Octuple(value1, value2, value3, value4, value5, value6, value7, value8))
        | _ -> None

    let ofList (genericList:'a list):Orders<'a, 'a, 'a, 'a, 'a, 'a, 'a, 'a> option =
        match genericList with
        | [value1:'a] -> Some(Single(value1))
        | [value1:'a; value2:'a] -> Some(Double(value1, value2))
        | [value1:'a; value2:'a; value3:'a] -> Some(Triple(value1, value2, value3))
        | [value1:'a; value2:'a; value3:'a; value4:'a] -> Some(Quadruple(value1, value2, value3, value4))
        | [value1:'a; value2:'a; value3:'a; value4:'a; value5:'a] -> Some(Quintuple(value1, value2, value3, value4, value5))
        | [value1:'a; value2:'a; value3:'a; value4:'a; value5:'a; value6:'a] -> Some(Hextuple(value1, value2, value3, value4, value5, value6))
        | [value1:'a; value2:'a; value3:'a; value4:'a; value5:'a; value6:'a; value7:'a] -> Some(Heptuple(value1, value2, value3, value4, value5, value6, value7))
        | [value1:'a; value2:'a; value3:'a; value4:'a; value5:'a; value6:'a; value7:'a; value8:'a] -> Some(Octuple(value1, value2, value3, value4, value5, value6, value7, value8))
        | _ -> None

    let toArray (tuple:Orders<'a, 'a, 'a, 'a, 'a, 'a, 'a, 'a>):'a array =
        match tuple with
        | Single(value1:'a) -> [|value1|]
        | Double(value1:'a, value2:'a) -> [|value1; value2|]
        | Triple(value1:'a, value2:'a, value3:'a) -> [|value1; value2; value3|]
        | Quadruple(value1:'a, value2:'a, value3:'a, value4:'a) -> [|value1; value2; value3; value4|]
        | Quintuple(value1:'a, value2:'a, value3:'a, value4:'a, value5:'a) -> [|value1; value2; value3; value4; value5|]
        | Hextuple(value1:'a, value2:'a, value3:'a, value4:'a, value5:'a, value6:'a) -> [|value1; value2; value3; value4; value5; value6|]
        | Heptuple(value1:'a, value2:'a, value3:'a, value4:'a, value5:'a, value6:'a, value7:'a) -> [|value1; value2; value3; value4; value5; value6; value7|]
        | Octuple(value1:'a, value2:'a, value3:'a, value4:'a, value5:'a, value6:'a, value7:'a, value8:'a) -> [|value1; value2; value3; value4; value5; value6; value7; value8|]

    let toList (tuple:Orders<'a, 'a, 'a, 'a, 'a, 'a, 'a, 'a>):'a list =
        match tuple with
        | Single(value1:'a) -> [value1]
        | Double(value1:'a, value2:'a) -> [value1; value2]
        | Triple(value1:'a, value2:'a, value3:'a) -> [value1; value2; value3]
        | Quadruple(value1:'a, value2:'a, value3:'a, value4:'a) -> [value1; value2; value3; value4]
        | Quintuple(value1:'a, value2:'a, value3:'a, value4:'a, value5:'a) -> [value1; value2; value3; value4; value5]
        | Hextuple(value1:'a, value2:'a, value3:'a, value4:'a, value5:'a, value6:'a) -> [value1; value2; value3; value4; value5; value6]
        | Heptuple(value1:'a, value2:'a, value3:'a, value4:'a, value5:'a, value6:'a, value7:'a) -> [value1; value2; value3; value4; value5; value6; value7]
        | Octuple(value1:'a, value2:'a, value3:'a, value4:'a, value5:'a, value6:'a, value7:'a, value8:'a) -> [value1; value2; value3; value4; value5; value6; value7; value8]

    let matcher (tuple:Orders<'a, 'b, 'c, 'd, 'e, 'f, 'g, 'h>) (unary:'a -> 'i) (binary:'a -> 'b -> 'i) (ternary:'a -> 'b -> 'c -> 'i) (quaternary:'a -> 'b -> 'c -> 'd -> 'i) (quinary:'a -> 'b -> 'c -> 'd -> 'e -> 'i) (senary:'a -> 'b -> 'c -> 'd -> 'e -> 'f -> 'i) (septenary:'a -> 'b -> 'c -> 'd -> 'e -> 'f -> 'g -> 'i) (octonary:'a -> 'b -> 'c -> 'd -> 'e -> 'f -> 'g -> 'h -> 'i):'i =
        match tuple with
        | Single(value1:'a) -> unary value1
        | Double(value1:'a, value2:'b) -> binary value1 value2
        | Triple(value1:'a, value2:'b, value3:'c) -> ternary value1 value2 value3
        | Quadruple(value1:'a, value2:'b, value3:'c, value4:'d) -> quaternary value1 value2 value3 value4
        | Quintuple(value1:'a, value2:'b, value3:'c, value4:'d, value5:'e) -> quinary value1 value2 value3 value4 value5
        | Hextuple(value1:'a, value2:'b, value3:'c, value4:'d, value5:'e, value6:'f) -> senary value1 value2 value3 value4 value5 value6
        | Heptuple(value1:'a, value2:'b, value3:'c, value4:'d, value5:'e, value6:'f, value7:'g) -> septenary value1 value2 value3 value4 value5 value6 value7
        | Octuple(value1:'a, value2:'b, value3:'c, value4:'d, value5:'e, value6:'f, value7:'g, value8:'h) -> octonary value1 value2 value3 value4 value5 value6 value7 value8

    let filter (predicate:'a -> bool) (tuple:Orders<'a, 'a, 'a, 'a, 'a, 'a, 'a, 'a>):Orders<'a, 'a, 'a, 'a, 'a, 'a, 'a, 'a> option =
        tuple
        |> toArray
        |> Array.filter predicate
        |> ofArray

    let fold (folder:'a -> 'b -> 'a) (state:'a) (tuple:Orders<'b, 'b, 'b, 'b, 'b, 'b, 'b, 'b>):'a =
        let swapped (b:'b) (a:'a):'a = folder a b
        match tuple with
        | Single(value1:'b) ->
            state
            |> swapped value1
        | Double(value1:'b, value2:'b) ->
            state
            |> swapped value1
            |> swapped value2
        | Triple(value1:'b, value2:'b, value3:'b) ->
            state
            |> swapped value1
            |> swapped value2
            |> swapped value3
        | Quadruple(value1:'b, value2:'b, value3:'b, value4:'b) ->
            state
            |> swapped value1
            |> swapped value2
            |> swapped value3
            |> swapped value4
        | Quintuple(value1:'b, value2:'b, value3:'b, value4:'b, value5:'b) ->
            state
            |> swapped value1
            |> swapped value2
            |> swapped value3
            |> swapped value4
            |> swapped value5
        | Hextuple(value1:'b, value2:'b, value3:'b, value4:'b, value5:'b, value6:'b) ->
            state
            |> swapped value1
            |> swapped value2
            |> swapped value3
            |> swapped value4
            |> swapped value5
            |> swapped value6
        | Heptuple(value1:'b, value2:'b, value3:'b, value4:'b, value5:'b, value6:'b, value7:'b) ->
            state
            |> swapped value1
            |> swapped value2
            |> swapped value3
            |> swapped value4
            |> swapped value5
            |> swapped value6
            |> swapped value7
        | Octuple(value1:'b, value2:'b, value3:'b, value4:'b, value5:'b, value6:'b, value7:'b, value8:'b) ->
            state
            |> swapped value1
            |> swapped value2
            |> swapped value3
            |> swapped value4
            |> swapped value5
            |> swapped value6
            |> swapped value7
            |> swapped value8

    let foldBack (folder:'b -> 'a -> 'a) (state:'a) (tuple:Orders<'b, 'b, 'b, 'b, 'b, 'b, 'b, 'b>):'a =
        match tuple with
        | Single(value1:'b) ->
            state
            |> folder value1
        | Double(value1:'b, value2:'b) ->
            state
            |> folder value2
            |> folder value1
        | Triple(value1:'b, value2:'b, value3:'b) ->
            state
            |> folder value3
            |> folder value2
            |> folder value1
        | Quadruple(value1:'b, value2:'b, value3:'b, value4:'b) ->
            state
            |> folder value4
            |> folder value3
            |> folder value2
            |> folder value1
        | Quintuple(value1:'b, value2:'b, value3:'b, value4:'b, value5:'b) ->
            state
            |> folder value5
            |> folder value4
            |> folder value3
            |> folder value2
            |> folder value1
        | Hextuple(value1:'b, value2:'b, value3:'b, value4:'b, value5:'b, value6:'b) ->
            state
            |> folder value6
            |> folder value5
            |> folder value4
            |> folder value3
            |> folder value2
            |> folder value1
        | Heptuple(value1:'b, value2:'b, value3:'b, value4:'b, value5:'b, value6:'b, value7:'b) ->
            state
            |> folder value7
            |> folder value6
            |> folder value5
            |> folder value4
            |> folder value3
            |> folder value2
            |> folder value1
        | Octuple(value1:'b, value2:'b, value3:'b, value4:'b, value5:'b, value6:'b, value7:'b, value8:'b) ->
            state
            |> folder value8
            |> folder value7
            |> folder value6
            |> folder value5
            |> folder value4
            |> folder value3
            |> folder value2
            |> folder value1

    let map (mapper:'a -> 'b) (tuple:Orders<'a, 'a, 'a, 'a, 'a, 'a, 'a, 'a>):Orders<'b, 'b, 'b, 'b, 'b, 'b, 'b, 'b> =
        match tuple with
        | Single(value1:'a) -> Single(mapper value1)
        | Double(value1:'a, value2:'a) -> Double(mapper value1, mapper value2)
        | Triple(value1:'a, value2:'a, value3:'a) -> Triple(mapper value1, mapper value2, mapper value3)
        | Quadruple(value1:'a, value2:'a, value3:'a, value4:'a) -> Quadruple(mapper value1, mapper value2, mapper value3, mapper value4)
        | Quintuple(value1:'a, value2:'a, value3:'a, value4:'a, value5:'a) -> Quintuple(mapper value1, mapper value2, mapper value3, mapper value4, mapper value5)
        | Hextuple(value1:'a, value2:'a, value3:'a, value4:'a, value5:'a, value6:'a) -> Hextuple(mapper value1, mapper value2, mapper value3, mapper value4, mapper value5, mapper value6)
        | Heptuple(value1:'a, value2:'a, value3:'a, value4:'a, value5:'a, value6:'a, value7:'a) -> Heptuple(mapper value1, mapper value2, mapper value3, mapper value4, mapper value5, mapper value6, mapper value7)
        | Octuple(value1:'a, value2:'a, value3:'a, value4:'a, value5:'a, value6:'a, value7:'a, value8:'a) -> Octuple(mapper value1, mapper value2, mapper value3, mapper value4, mapper value5, mapper value6, mapper value7, mapper value8)