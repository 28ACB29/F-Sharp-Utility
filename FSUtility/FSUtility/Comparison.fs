namespace FSUtility

open System
open System.Collections.Generic

type Ordering =
    | LessThan
    | EqualTo
    | GreaterThan

type Sign =
    | Negative
    | Zero
    | Positive

module Comparison =

    let private IntToUnion (sign:int) =
        match sign with
        | -1 -> Negative
        | 0 -> Zero
        | 1 -> Positive

    let private SignToOrdering (sign:Sign) =
        match sign with
        | Negative -> LessThan
        | Zero -> EqualTo
        | Positive -> GreaterThan

    let SignDecimal (value:Decimal):Sign =
        value
        |> Math.Sign
        |> IntToUnion

    let SignDouble (value:Double):Sign =
        value
        |> Math.Sign
        |> IntToUnion

    let SignInt16 (value:Int16):Sign =
        value
        |> Math.Sign
        |> IntToUnion

    let SignInt32 (value:Int32):Sign =
        value
        |> Math.Sign
        |> IntToUnion

    let SignInt64 (value:Int64):Sign =
        value
        |> Math.Sign
        |> IntToUnion

    let SignSingle (value:Single):Sign =
        value
        |> Math.Sign
        |> IntToUnion

    let SignSByte (value:SByte):Sign =
        value
        |> Math.Sign
        |> IntToUnion

    let Compare (a:'a when 'a :> IComparer<'a>) (b:'a when 'a :> IComparer<'a>):int = a.Compare(a, b)

    let CompareTo (a:'a when 'a :> IComparable<'a>) (b:'a when 'a :> IComparable<'a>):int = a.CompareTo(b)

    let IComparableOrdering (a:'a when 'a :> IComparable<'a>) (b:'a when 'a :> IComparable<'a>):Ordering =
        a.CompareTo(b)
        |> SignInt32
        |> SignToOrdering

    let IComparerOrdering (a:'a when 'a :> IComparer<'a>) (b:'a when 'a :> IComparer<'a>):Ordering =
        a.Compare(a, b)
        |> SignInt32
        |> SignToOrdering

    let (|LessThan|_|) (a:'a when 'a:comparison) (b:'a when 'a:comparison) =
        match b < a with
        | true ->
            ()
            |> Some
        | false -> None

    let (|EqualTo|_|) (a:'a when 'a:comparison) (b:'a when 'a:comparison) =
        match b = a with
        | true ->
            ()
            |> Some
        | false -> None

    let (|GreaterThan|_|) (a:'a when 'a:comparison) (b:'a when 'a:comparison) =
        match b > a with
        | true ->
            ()
            |> Some
        | false -> None

    let (|LessThanOrEqualTo|_|) (a:'a when 'a:comparison) (b:'a when 'a:comparison) =
        match b <= a with
        | true ->
            ()
            |> Some
        | false -> None

    let (|NotEqualTo|_|) (a:'a when 'a:comparison) (b:'a when 'a:comparison) =
        match b <> a with
        | true ->
            ()
            |> Some
        | false -> None

    let (|GreaterThanOrEqualTo|_|) (a:'a when 'a:comparison) (b:'a when 'a:comparison) =
        match b >= a with
        | true ->
            ()
            |> Some
        | false -> None