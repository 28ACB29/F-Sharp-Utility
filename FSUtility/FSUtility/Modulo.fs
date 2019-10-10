namespace FSUtility

open System

module Modulo =

    let modulo (n: int64) (m: int64) =
        match Math.Sign(n) with
        | -1 -> (m - ((-n) % m))
        | 0 -> 0L
        | 1 -> n % m

    let (|Even|Odd|) (input:uint64) =
        match input % 2UL with
        | 0UL -> Even
        | _ -> Odd

    let getInclusive (a:uint64) (m:uint64):uint64 =
        let overflow:uint64 =
            match a % m with
            | 0UL -> 1UL
            | _ -> 0UL
        (a / m) + overflow

    let moduloSum (a:uint64) (b:uint64) (m:uint64):uint64 = (a % m + b % m) % m

    let moduloDifference (a:uint64) (b:uint64) (m:uint64):uint64 = (a % m - b % m) % m

    let moduloProduct (a:uint64) (b:uint64) (m:uint64):uint64 = (a % m * b % m) % m

    let moduloSquare (a:uint64) (m:uint64):uint64 = moduloProduct a a m

    let seriesModuloSum (a:uint64) (m:uint64):uint64 =
        let quotient:uint64 = a / m
        let remainder:uint64 = a % m
        let whole:uint64 = Seq.fold(fun (accumulator:uint64) (element:uint64) -> (accumulator + element) % m) 0UL [|1UL .. (m - 1UL)|]
        let part:uint64 = Seq.fold(fun (accumulator:uint64) (element:uint64) -> (accumulator + element) % m) 0UL [|1UL .. remainder|]
        ((quotient * whole) % m + part) % m

    let fastModuloPower (a:uint64) (b:uint64) (m:uint64):uint64 =
        let rec tail (a:uint64) (b:uint64) (m:uint64) (c:uint64):uint64 =
            match a, b with
            | 0UL, _ -> 0UL
            | _, 0UL -> c % m
            | a, 1UL -> moduloProduct a c m
            | _ ->
                match b with
                | Even -> tail (moduloSquare a m) (b / 2UL) m c
                | Odd -> tail (moduloSquare a m) ((b - 1UL) / 2UL) m (moduloProduct a c m)
        tail a b m 1UL

    let patternMatcher (n:int) (outputs:'a array) (i:int):'a option =
        if outputs.Length = n && i > -1 && i < n then
            outputs.[i]
            |> Some
        else
            None