namespace FSUtility

open System

module ProtectedInteger =

    type ProtectedInt8 =
        | Int of int8
        | PosInf
        | NegInf

    type ProtectedInt16 =
        | Int of Int16
        | PosInf
        | NegInf

    type ProtectedInt32 =
        | Int of Int32
        | PosInf
        | NegInf

    type ProtectedInt64 =
        | Int of Int64
        | PosInf
        | NegInf

    type ProtectedUInt8 =
        | UInt of uint8
        | PosInf

    type ProtectedUInt16 =
        | UInt of UInt16
        | PosInf

    type ProtectedUInt32 =
        | UInt of UInt32
        | PosInf

    type ProtectedUInt64 =
        | UInt of UInt64
        | PosInf

    let add8 (a:ProtectedInt8) (b:ProtectedInt8):ProtectedInt8 =
        match a, b with
        | ProtectedInt8.PosInf, _ -> ProtectedInt8.PosInf
        | _, ProtectedInt8.PosInf -> ProtectedInt8.PosInf
        | ProtectedInt8.NegInf, _ -> ProtectedInt8.NegInf
        | _, ProtectedInt8.NegInf -> ProtectedInt8.NegInf
        | ProtectedInt8.Int(valueA:int8), ProtectedInt8.Int(valueB:int8) ->
            match valueA + valueB with
            | Comparison.LessThan valueA
            | Comparison.LessThan valueB -> ProtectedInt8.PosInf
            | Comparison.GreaterThan valueA
            | Comparison.GreaterThan valueB -> ProtectedInt8.NegInf
            | _ ->
                valueA + valueB
                |> ProtectedInt8.Int

    let add16 (a:ProtectedInt16) (b:ProtectedInt16):ProtectedInt16 =
        match a, b with
        | ProtectedInt16.PosInf, _ -> ProtectedInt16.PosInf
        | _, ProtectedInt16.PosInf -> ProtectedInt16.PosInf
        | ProtectedInt16.NegInf, _ -> ProtectedInt16.NegInf
        | _, ProtectedInt16.NegInf -> ProtectedInt16.NegInf
        | ProtectedInt16.Int(valueA:int16), ProtectedInt16.Int(valueB:int16) ->
            match valueA + valueB with
            | Comparison.LessThan valueA
            | Comparison.LessThan valueB -> ProtectedInt16.PosInf
            | Comparison.GreaterThan valueA
            | Comparison.GreaterThan valueB -> ProtectedInt16.NegInf
            | _ ->
                valueA + valueB
                |> ProtectedInt16.Int

    let add32 (a:ProtectedInt32) (b:ProtectedInt32):ProtectedInt32 =
        match a, b with
        | ProtectedInt32.PosInf, _ -> ProtectedInt32.PosInf
        | _, ProtectedInt32.PosInf -> ProtectedInt32.PosInf
        | ProtectedInt32.NegInf, _ -> ProtectedInt32.NegInf
        | _, ProtectedInt32.NegInf -> ProtectedInt32.NegInf
        | ProtectedInt32.Int(valueA:int32), ProtectedInt32.Int(valueB:int32) ->
            match valueA + valueB with
            | Comparison.LessThan valueA
            | Comparison.LessThan valueB -> ProtectedInt32.PosInf
            | Comparison.GreaterThan valueA
            | Comparison.GreaterThan valueB -> ProtectedInt32.NegInf
            | _ ->
                valueA + valueB
                |> ProtectedInt32.Int

    let add64 (a:ProtectedInt64) (b:ProtectedInt64):ProtectedInt64 =
        match a, b with
        | ProtectedInt64.PosInf, _ -> ProtectedInt64.PosInf
        | _, ProtectedInt64.PosInf -> ProtectedInt64.PosInf
        | ProtectedInt64.NegInf, _ -> ProtectedInt64.NegInf
        | _, ProtectedInt64.NegInf -> ProtectedInt64.NegInf
        | ProtectedInt64.Int(valueA:int64), ProtectedInt64.Int(valueB:int64) ->
            match valueA + valueB with
            | Comparison.LessThan valueA
            | Comparison.LessThan valueB -> ProtectedInt64.PosInf
            | Comparison.GreaterThan valueA
            | Comparison.GreaterThan valueB -> ProtectedInt64.NegInf
            | _ ->
                valueA + valueB
                |> ProtectedInt64.Int

    let addU8 (a:ProtectedUInt8) (b:ProtectedUInt8):ProtectedUInt8 =
        match a, b with
        | ProtectedUInt8.PosInf, _ -> ProtectedUInt8.PosInf
        | _, ProtectedUInt8.PosInf -> ProtectedUInt8.PosInf
        | ProtectedUInt8.UInt(valueA:uint8), ProtectedUInt8.UInt(valueB:uint8) ->
            match valueA + valueB with
            | Comparison.LessThan valueA
            | Comparison.LessThan valueB -> ProtectedUInt8.PosInf
            | _ ->
                valueA + valueB
                |> ProtectedUInt8.UInt

    let addU16 (a:ProtectedUInt16) (b:ProtectedUInt16):ProtectedUInt16 =
        match a, b with
        | ProtectedUInt16.PosInf, _ -> ProtectedUInt16.PosInf
        | _, ProtectedUInt16.PosInf -> ProtectedUInt16.PosInf
        | ProtectedUInt16.UInt(valueA:uint16), ProtectedUInt16.UInt(valueB:uint16) ->
            match valueA + valueB with
            | Comparison.LessThan valueA
            | Comparison.LessThan valueB -> ProtectedUInt16.PosInf
            | _ ->
                valueA + valueB
                |> ProtectedUInt16.UInt

    let addU32 (a:ProtectedUInt32) (b:ProtectedUInt32):ProtectedUInt32 =
        match a, b with
        | ProtectedUInt32.PosInf, _ -> ProtectedUInt32.PosInf
        | _, ProtectedUInt32.PosInf -> ProtectedUInt32.PosInf
        | ProtectedUInt32.UInt(valueA:uint32), ProtectedUInt32.UInt(valueB:uint32) ->
            match valueA + valueB with
            | Comparison.LessThan valueA
            | Comparison.LessThan valueB -> ProtectedUInt32.PosInf
            | _ ->
                valueA + valueB
                |> ProtectedUInt32.UInt

    let addU64 (a:ProtectedUInt64) (b:ProtectedUInt64):ProtectedUInt64 =
        match a, b with
        | ProtectedUInt64.PosInf, _ -> ProtectedUInt64.PosInf
        | _, ProtectedUInt64.PosInf -> ProtectedUInt64.PosInf
        | ProtectedUInt64.UInt(valueA:uint64), ProtectedUInt64.UInt(valueB:uint64) ->
            match valueA + valueB with
            | Comparison.LessThan valueA
            | Comparison.LessThan valueB -> ProtectedUInt64.PosInf
            | _ ->
                valueA + valueB
                |> ProtectedUInt64.UInt
                               
    let mul8 (a:ProtectedInt8) (b:ProtectedInt8):ProtectedInt8 =
        match a, b with
        | ProtectedInt8.PosInf, _ -> ProtectedInt8.PosInf
        | _, ProtectedInt8.PosInf -> ProtectedInt8.PosInf
        | ProtectedInt8.NegInf, _ -> ProtectedInt8.NegInf
        | _, ProtectedInt8.NegInf -> ProtectedInt8.NegInf
        | ProtectedInt8.Int(valueA:int8), ProtectedInt8.Int(valueB:int8) ->
            match valueA * valueB with
            | Comparison.LessThan valueA
            | Comparison.LessThan valueB -> ProtectedInt8.PosInf
            | Comparison.GreaterThan valueA
            | Comparison.GreaterThan valueB -> ProtectedInt8.NegInf
            | _ ->
                valueA * valueB
                |> ProtectedInt8.Int

    let mul16 (a:ProtectedInt16) (b:ProtectedInt16):ProtectedInt16 =
        match a, b with
        | ProtectedInt16.PosInf, _ -> ProtectedInt16.PosInf
        | _, ProtectedInt16.PosInf -> ProtectedInt16.PosInf
        | ProtectedInt16.NegInf, _ -> ProtectedInt16.NegInf
        | _, ProtectedInt16.NegInf -> ProtectedInt16.NegInf
        | ProtectedInt16.Int(valueA:int16), ProtectedInt16.Int(valueB:int16) ->
            match valueA * valueB with
            | Comparison.LessThan valueA
            | Comparison.LessThan valueB -> ProtectedInt16.PosInf
            | Comparison.GreaterThan valueA
            | Comparison.GreaterThan valueB -> ProtectedInt16.NegInf
            | _ ->
                valueA * valueB
                |> ProtectedInt16.Int

    let mul32 (a:ProtectedInt32) (b:ProtectedInt32):ProtectedInt32 =
        match a, b with
        | ProtectedInt32.PosInf, _ -> ProtectedInt32.PosInf
        | _, ProtectedInt32.PosInf -> ProtectedInt32.PosInf
        | ProtectedInt32.NegInf, _ -> ProtectedInt32.NegInf
        | _, ProtectedInt32.NegInf -> ProtectedInt32.NegInf
        | ProtectedInt32.Int(valueA:int32), ProtectedInt32.Int(valueB:int32) ->
            match valueA * valueB with
            | Comparison.LessThan valueA
            | Comparison.LessThan valueB -> ProtectedInt32.PosInf
            | Comparison.GreaterThan valueA
            | Comparison.GreaterThan valueB -> ProtectedInt32.NegInf
            | _ ->
                valueA * valueB
                |> ProtectedInt32.Int

    let mul64 (a:ProtectedInt64) (b:ProtectedInt64):ProtectedInt64 =
        match a, b with
        | ProtectedInt64.PosInf, _ -> ProtectedInt64.PosInf
        | _, ProtectedInt64.PosInf -> ProtectedInt64.PosInf
        | ProtectedInt64.NegInf, _ -> ProtectedInt64.NegInf
        | _, ProtectedInt64.NegInf -> ProtectedInt64.NegInf
        | ProtectedInt64.Int(valueA:int64), ProtectedInt64.Int(valueB:int64) ->
            match valueA * valueB with
            | Comparison.LessThan valueA
            | Comparison.LessThan valueB -> ProtectedInt64.PosInf
            | Comparison.GreaterThan valueA
            | Comparison.GreaterThan valueB -> ProtectedInt64.NegInf
            | _ ->
                valueA * valueB
                |> ProtectedInt64.Int

    let mulU8 (a:ProtectedUInt8) (b:ProtectedUInt8):ProtectedUInt8 =
        match a, b with
        | ProtectedUInt8.PosInf, _ -> ProtectedUInt8.PosInf
        | _, ProtectedUInt8.PosInf -> ProtectedUInt8.PosInf
        | ProtectedUInt8.UInt(valueA:uint8), ProtectedUInt8.UInt(valueB:uint8) ->
            match valueA * valueB with
            | Comparison.LessThan valueA
            | Comparison.LessThan valueB -> ProtectedUInt8.PosInf
            | _ ->
                valueA * valueB
                |> ProtectedUInt8.UInt

    let mulU16 (a:ProtectedUInt16) (b:ProtectedUInt16):ProtectedUInt16 =
        match a, b with
        | ProtectedUInt16.PosInf, _ -> ProtectedUInt16.PosInf
        | _, ProtectedUInt16.PosInf -> ProtectedUInt16.PosInf
        | ProtectedUInt16.UInt(valueA:uint16), ProtectedUInt16.UInt(valueB:uint16) ->
            match valueA * valueB with
            | Comparison.LessThan valueA
            | Comparison.LessThan valueB -> ProtectedUInt16.PosInf
            | _ ->
                valueA * valueB
                |> ProtectedUInt16.UInt

    let mulU32 (a:ProtectedUInt32) (b:ProtectedUInt32):ProtectedUInt32 =
        match a, b with
        | ProtectedUInt32.PosInf, _ -> ProtectedUInt32.PosInf
        | _, ProtectedUInt32.PosInf -> ProtectedUInt32.PosInf
        | ProtectedUInt32.UInt(valueA:uint32), ProtectedUInt32.UInt(valueB:uint32) ->
            match valueA * valueB with
            | Comparison.LessThan valueA
            | Comparison.LessThan valueB -> ProtectedUInt32.PosInf
            | _ ->
                valueA * valueB
                |> ProtectedUInt32.UInt

    let mulU64 (a:ProtectedUInt64) (b:ProtectedUInt64):ProtectedUInt64 =
        match a, b with
        | ProtectedUInt64.PosInf, _ -> ProtectedUInt64.PosInf
        | _, ProtectedUInt64.PosInf -> ProtectedUInt64.PosInf
        | ProtectedUInt64.UInt(valueA:uint64), ProtectedUInt64.UInt(valueB:uint64) ->
            match valueA * valueB with
            | Comparison.LessThan valueA
            | Comparison.LessThan valueB -> ProtectedUInt64.PosInf
            | _ ->
                valueA * valueB
                |> ProtectedUInt64.UInt



