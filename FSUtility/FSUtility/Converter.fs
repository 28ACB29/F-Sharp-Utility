namespace FSUtility

open System

module Converter =

    let ToBoolean (formatProvider:'a when 'a :> IFormatProvider) (convertible:'b when 'b :> IConvertible):bool = convertible.ToBoolean(formatProvider)

    let ToByte (formatProvider:'a when 'a :> IFormatProvider) (convertible:'b when 'b :> IConvertible):byte = convertible.ToByte(formatProvider)

    let ToChar (formatProvider:'a when 'a :> IFormatProvider) (convertible:'b when 'b :> IConvertible):char = convertible.ToChar(formatProvider)

    let ToDecimal (formatProvider:'a when 'a :> IFormatProvider) (convertible:'b when 'b :> IConvertible):decimal = convertible.ToDecimal(formatProvider)

    let ToDateTime (formatProvider:'a when 'a :> IFormatProvider) (convertible:'b when 'b :> IConvertible):DateTime = convertible.ToDateTime(formatProvider)

    let ToDouble (formatProvider:'a when 'a :> IFormatProvider) (convertible:'b when 'b :> IConvertible):double = convertible.ToDouble(formatProvider)

    let ToInt16 (formatProvider:'a when 'a :> IFormatProvider) (convertible:'b when 'b :> IConvertible):int16 = convertible.ToInt16(formatProvider)

    let ToInt32 (formatProvider:'a when 'a :> IFormatProvider) (convertible:'b when 'b :> IConvertible):int32 = convertible.ToInt32(formatProvider)

    let ToInt64 (formatProvider:'a when 'a :> IFormatProvider) (convertible:'b when 'b :> IConvertible):int64 = convertible.ToInt64(formatProvider)

    let ToSByte (formatProvider:'a when 'a :> IFormatProvider) (convertible:'b when 'b :> IConvertible):sbyte = convertible.ToSByte(formatProvider)

    let ToSingle (formatProvider:'a when 'a :> IFormatProvider) (convertible:'b when 'b :> IConvertible):single = convertible.ToSingle(formatProvider)

    let ToString (formatProvider:'a when 'a :> IFormatProvider) (convertible:'b when 'b :> IConvertible):string = convertible.ToString(formatProvider)

    let ToUInt16 (formatProvider:'a when 'a :> IFormatProvider) (convertible:'b when 'b :> IConvertible):uint16 = convertible.ToUInt16(formatProvider)

    let ToUInt32 (formatProvider:'a when 'a :> IFormatProvider) (convertible:'b when 'b :> IConvertible):uint32 = convertible.ToUInt32(formatProvider)

    let ToUInt64 (formatProvider:'a when 'a :> IFormatProvider) (convertible:'b when 'b :> IConvertible):UInt64 = convertible.ToUInt64(formatProvider)

