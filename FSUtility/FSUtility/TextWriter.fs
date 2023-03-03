namespace FSUtility

open System
open System.IO
open System.Threading.Tasks

type ValueTypes =
    | Buffer of char array
    | BufferIndexCount of char array * int * int
    | Byte of byte
    | Boolean of bool
    | Char of char
    | Decimal of decimal
    | Double of double
    | Int16 of int16
    | Int32 of int32
    | Int64 of int64
    | Object of obj
    | SByte of sbyte
    | Single of single
    | String of string
    | UInt16 of uint16
    | UInt32 of uint32
    | UInt64 of uint64
    
type ValueTypesAsync =
    | Buffer of char array
    | BufferIndexCount of char array * int * int
    | Char of char
    | String of string

module TextWriter =

    let close (writer:'a when 'a :> TextWriter):unit = writer.Close()
    
    let flush (writer:'a when 'a :> TextWriter):unit = writer.Flush()
    
    let flushAsync (writer:'a when 'a :> TextWriter):Task = writer.FlushAsync()
    
    let write (valueTypes:ValueTypes) (writer:'b when 'b :> TextWriter):unit =
        match valueTypes with
        | ValueTypes.Buffer(buffer:char array) -> writer.Write(buffer)
        | ValueTypes.BufferIndexCount(buffer:char array, index:int, count:int) -> writer.Write(buffer, index, count)
        | Byte(value:byte) -> writer.Write(value)
        | Boolean(value:bool) -> writer.Write(value)
        | ValueTypes.Char(value:char) -> writer.Write(value)
        | Decimal(value:decimal) -> writer.Write(value)
        | Double(value:double) -> writer.Write(value)
        | Int16(value:int16) -> writer.Write(value)
        | Int32(value:int32) -> writer.Write(value)
        | Int64(value:int64) -> writer.Write(value)
        | Object(buffer:obj) -> writer.Write(buffer)
        | SByte(value:sbyte) -> writer.Write(value)
        | Single(value:single) -> writer.Write(value)
        | ValueTypes.String(value:string) -> writer.Write(value)
        | UInt16(value:uint16) -> writer.Write(value)
        | UInt32(value:uint32) -> writer.Write(value)
        | UInt64(value:uint64) -> writer.Write(value)
        
    let writeAsync (valueTypes:ValueTypesAsync) (writer:'b when 'b :> TextWriter):Task =
        match valueTypes with
        | Buffer(buffer:char array) -> writer.WriteAsync(buffer)
        | BufferIndexCount(buffer:char array, index:int, count:int) -> writer.WriteAsync(buffer, index, count)
        | Char(value:char) -> writer.WriteAsync(value)
        | String(value:string) -> writer.WriteAsync(value)
        
    let writeLine (valueTypes:ValueTypes) (writer:'b when 'b :> TextWriter):unit =
        match valueTypes with
        | ValueTypes.Buffer(buffer:char array) -> writer.WriteLine(buffer)
        | ValueTypes.BufferIndexCount(buffer:char array, index:int, count:int) -> writer.WriteLine(buffer, index, count)
        | Byte(value:byte) -> writer.WriteLine(value)
        | Boolean(value:bool) -> writer.WriteLine(value)
        | ValueTypes.Char(value:char) -> writer.WriteLine(value)
        | Decimal(value:decimal) -> writer.WriteLine(value)
        | Double(value:double) -> writer.WriteLine(value)
        | Int16(value:int16) -> writer.WriteLine(value)
        | Int32(value:int32) -> writer.WriteLine(value)
        | Int64(value:int64) -> writer.WriteLine(value)
        | Object(buffer:obj) -> writer.WriteLine(buffer)
        | SByte(value:sbyte) -> writer.WriteLine(value)
        | Single(value:single) -> writer.WriteLine(value)
        | ValueTypes.String(value:string) -> writer.WriteLine(value)
        | UInt16(value:uint16) -> writer.WriteLine(value)
        | UInt32(value:uint32) -> writer.WriteLine(value)
        | UInt64(value:uint64) -> writer.WriteLine(value)
        
    let writeLineAsync (valueTypes:ValueTypesAsync) (writer:'b when 'b :> TextWriter):Task =
        match valueTypes with
        | Buffer(buffer:char array) -> writer.WriteLineAsync(buffer)
        | BufferIndexCount(buffer:char array, index:int, count:int) -> writer.WriteLineAsync(buffer, index, count)
        | Char(value:char) -> writer.WriteLineAsync(value)
        | String(value:string) -> writer.WriteLineAsync(value)

