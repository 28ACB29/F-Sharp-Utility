namespace FSUtility

open System
open System.IO

module BinaryReader =

    let close (reader:'a when 'a :> BinaryReader):unit = reader.Close()
    
    let peekChar (reader:'a when 'a :> BinaryReader):int = reader.PeekChar()
    
    let readBoolean (reader:'a when 'a :> BinaryReader):bool = reader.ReadBoolean()
    
    let readByte (reader:'a when 'a :> BinaryReader):byte = reader.ReadByte()
    
    let readBytes (count:int) (reader:'a when 'a :> BinaryReader):byte array = reader.ReadBytes(count)
    
    let readChar (reader:'a when 'a :> BinaryReader):char = reader.ReadChar()
    
    let readChars (count:int) (reader:'a when 'a :> BinaryReader):char array = reader.ReadChars(count)
    
    let readDecimal (reader:'a when 'a :> BinaryReader):decimal = reader.ReadDecimal()
    
    let readDouble (reader:'a when 'a :> BinaryReader):double = reader.ReadDouble()
    
    let readSingle (reader:'a when 'a :> BinaryReader):single = reader.ReadSingle()
    
    let readInt16 (reader:'a when 'a :> BinaryReader):int16 = reader.ReadInt16()
    
    let readInt32 (reader:'a when 'a :> BinaryReader):int32 = reader.ReadInt32()
    
    let readInt64 (reader:'a when 'a :> BinaryReader):int64 = reader.ReadInt64()
    
    let readSByte (reader:'a when 'a :> BinaryReader):sbyte = reader.ReadSByte()
    
    let readString (reader:'a when 'a :> BinaryReader):string = reader.ReadString()
    
    let readUInt16 (reader:'a when 'a :> BinaryReader):uint16 = reader.ReadUInt16()
    
    let readUInt32 (reader:'a when 'a :> BinaryReader):uint32 = reader.ReadUInt32()
    
    let readUInt64 (reader:'a when 'a :> BinaryReader):uint64 = reader.ReadUInt64()

