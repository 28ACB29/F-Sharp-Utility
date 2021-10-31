namespace FSUtility

open System

module StringConvert =

    let private yieldIfTrue (parser:string -> (bool * 'a)) (s:string):'a option =
        match parser s with
        | (true, (result:'a)) ->
            result
            |> Some
        | _ -> None

    let (|Boolean|_|) (s:string) =
        s
        |> yieldIfTrue Boolean.TryParse

    let (|Byte|_|) (s:string) =
        s
        |> yieldIfTrue Byte.TryParse

    let (|Char|_|) (s:string) =
        s
        |> yieldIfTrue Char.TryParse

    let (|Decimal|_|) (s:string) =
        s
        |> yieldIfTrue Decimal.TryParse

    let (|Double|_|) (s:string) =
        s
        |> yieldIfTrue Double.TryParse

    let (|Int16|_|) (s:string) =
        s
        |> yieldIfTrue Int16.TryParse

    let (|Int32|_|) (s:string) =
        s
        |> yieldIfTrue Int32.TryParse

    let (|Int64|_|) (s:string) =
        s
        |> yieldIfTrue Int64.TryParse

    let (|SByte|_|) (s:string) =
        s
        |> yieldIfTrue SByte.TryParse

    let (|Single|_|) (s:string) =
        s
        |> yieldIfTrue Single.TryParse

    let (|UInt16|_|) (s:string) =
        s
        |> yieldIfTrue UInt16.TryParse

    let (|UInt32|_|) (s:string) =
        s
        |> yieldIfTrue UInt32.TryParse

    let (|UInt64|_|) (s:string) =
        s
        |> yieldIfTrue UInt64.TryParse