namespace FSUtility

open System

module NumberType =

    type UnsignedInteger =
    | Unsigned8 of Byte
    | Unsigned16 of UInt16
    | Unsigned32 of UInt32
    | Unsigned64 of UInt64

    type SignedInteger =
    | Signed8 of SByte
    | Signed16 of Int16
    | Signed32 of Int32
    | Signed64 of Int64

    type Integer =
    | UnsignedInteger
    | SignedInteger

    type Floating =
    | Float32 of Single
    | Float64 of Double
    | Float128 of Decimal

    type Signed =
    | SignedInteger
    | Floating

    type Number =
    | Integer
    | Floating

