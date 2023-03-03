namespace FSUtility

open System
open System.IO

type ValueTypes =
    | Object of byte array
    | BufferIndexCount of byte array * int * int
    | Byte of byte
    | Boolean of bool
    | Char of char
    | Buffer of char array
    | Decimal of decimal
    | Double of double
    | Int16 of int16
    | Int32 of int32
    | Int64 of int64
    | SByte of sbyte
    | Single of single
    | String of string
    | UInt16 of uint16
    | UInt32 of uint32
    | UInt64 of uint64

module BinaryWriter =

    let close (writer:'a when 'a :> BinaryWriter):unit = writer.Close()
    
    let flush (writer:'a when 'a :> BinaryWriter):unit = writer.Flush()

    let seek (origin:SeekOrigin) (offset:int) (writer:'a when 'a :> BinaryWriter):int64 = writer.Seek(offset, origin)
    
    let write (valueTypes:ValueTypes) (writer:'b when 'b :> BinaryWriter):unit =
        match valueTypes with
        | Object(buffer:byte array) -> writer.Write(buffer)
        | BufferIndexCount(buffer:byte array, index:int, count:int) -> writer.Write(buffer, index, count)
        | Byte(value:byte) -> writer.Write(value)
        | Boolean(value:bool) -> writer.Write(value)
        | Char(ch:char) -> writer.Write(ch)
        | Buffer(chars:char array) -> writer.Write(chars)
        | Decimal(value:decimal) -> writer.Write(value)
        | Double(value:double) -> writer.Write(value)
        | Int16(value:int16) -> writer.Write(value)
        | Int32(value:int32) -> writer.Write(value)
        | Int64(value:int64) -> writer.Write(value)
        | SByte(value:sbyte) -> writer.Write(value)
        | Single(value:single) -> writer.Write(value)
        | String(value:string) -> writer.Write(value)
        | UInt16(value:uint16) -> writer.Write(value)
        | UInt32(value:uint32) -> writer.Write(value)
        | UInt64(value:uint64) -> writer.Write(value)