namespace FSUtility

open System

module StringConvert =

    let (|Boolean|_|) (s:string) =
        match Boolean.TryParse(s) with
        | (true, result:Boolean) ->
            result
            |> Some
        | _ -> None

    let (|Byte|_|) (s:string) =
        match Byte.TryParse(s) with
        | (true, result:Byte) ->
            result
            |> Some
        | _ -> None

    let (|Char|_|) (s:string) =
        match Char.TryParse(s) with
        | (true, result:Char) ->
            result
            |> Some
        | _ -> None

    let (|Decimal|_|) (s:string) =
        match Decimal.TryParse(s) with
        | (true, result:Decimal) ->
            result
            |> Some
        | _ -> None

    let (|Double|_|) (s:string) =
        match Double.TryParse(s) with
        | (true, result:Double) ->
            result
            |> Some
        | _ -> None

    let (|Int16|_|) (s:string) =
        match Int16.TryParse(s) with
        | (true, result:Int16) ->
            result
            |> Some
        | _ -> None

    let (|Int32|_|) (s:string) =
        match Int32.TryParse(s) with
        | (true, result:Int32) ->
            result
            |> Some
        | _ -> None

    let (|Int64|_|) (s:string) =
        match Int64.TryParse(s) with
        | (true, result:Int64) ->
            result
            |> Some
        | _ -> None

    let (|SByte|_|) (s:string) =
        match SByte.TryParse(s) with
        | (true, result:SByte) ->
            result
            |> Some
        | _ -> None

    let (|Single|_|) (s:string) =
        match Single.TryParse(s) with
        | (true, result:Single) ->
            result
            |> Some
        | _ -> None

    let (|UInt16|_|) (s:string) =
        match UInt16.TryParse(s) with
        | (true, result:UInt16) ->
            result
            |> Some
        | _ -> None

    let (|UInt32|_|) (s:string) =
        match UInt32.TryParse(s) with
        | (true, result:UInt32) ->
            result
            |> Some
        | _ -> None

    let (|UInt64|_|) (s:string) =
        match UInt64.TryParse(s) with
        | (true, result:UInt64) ->
            result
            |> Some
        | _ -> None