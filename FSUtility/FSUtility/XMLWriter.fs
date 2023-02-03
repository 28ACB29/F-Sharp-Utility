namespace FSUtility

open System
open System.IO
open System.Text
open System.Threading.Tasks
open System.Xml
open System.Xml.Schema

type CreateArguments =
    | OutputStream of Stream
    | OutputStreamSettings of Stream * XmlWriterSettings
    | InputUri of string
    | OutputFileNameSettings of string * XmlWriterSettings
    | OutputStringBuilder of StringBuilder
    | OutputStringBuilderSettings of StringBuilder * XmlWriterSettings
    | OutputTextWriter of TextWriter
    | OutputTextWriterSettings of TextWriter * XmlWriterSettings
    | OutputXmlWriter of XmlWriter
    | OutputXmlWriterSettings of XmlWriter * XmlWriterSettings

type ValueTypes =
    | Single of single
    | Object of obj
    | Int64 of int64
    | Int32 of int32
    | Double of double
    | String of string
    | DateTimeOffset of DateTimeOffset
    | DateTime of DateTime
    | Boolean of bool
    | Decimal of decimal

module XMLWriter =

    let private boolToOption (value:bool):unit option =
        match value with
        | true -> Some()
        | false -> None

    let settings (writer:'a when 'a :> XmlWriter):XmlWriterSettings = writer.Settings
  
    let writeState (writer:'a when 'a :> XmlWriter):WriteState = writer.WriteState
  
    let xmlLang (writer:'a when 'a :> XmlWriter):string = writer.XmlLang
  
    let xmlSpace (writer:'a when 'a :> XmlWriter):XmlSpace = writer.XmlSpace
    
    let create (createArguments:CreateArguments):XmlWriter =
        match createArguments with
        | OutputStream(output:Stream) -> XmlWriter.Create(output)
        | OutputStreamSettings(output:Stream, settings:XmlWriterSettings) -> XmlWriter.Create(output, settings)
        | InputUri(outputFileName:string) -> XmlWriter.Create(outputFileName)
        | OutputFileNameSettings(outputFileName:string, settings:XmlWriterSettings) -> XmlWriter.Create(outputFileName, settings)
        | OutputStringBuilder(output:StringBuilder) -> XmlWriter.Create(output)
        | OutputStringBuilderSettings(output:StringBuilder, settings:XmlWriterSettings) -> XmlWriter.Create(output, settings)
        | OutputTextWriter(output:TextWriter) -> XmlWriter.Create(output)
        | OutputTextWriterSettings(output:TextWriter, settings:XmlWriterSettings) -> XmlWriter.Create(output, settings)
        | OutputXmlWriter(output:XmlWriter) -> XmlWriter.Create(output)
        | OutputXmlWriterSettings(output:XmlWriter, xmlWriterSettings:XmlWriterSettings) -> XmlWriter.Create(output, xmlWriterSettings)

    let close (writer:'a when 'a :> XmlWriter):unit = writer.Close()
    
    let flush (writer:'a when 'a :> XmlWriter):unit = writer.Flush()
    
    let flushAsync (writer:'a when 'a :> XmlWriter):Task = writer.FlushAsync()

    let lookupPrefix (ns:string) (writer:'a when 'a :> XmlWriter):string = writer.LookupPrefix(ns)
    
    let writeAttributes (defattr:bool) (reader:'a when 'a :> XmlReader) (writer:'b when 'b :> XmlWriter):unit = writer.WriteAttributes(reader, defattr)
    
    let writeAttributesAsync (defattr:bool) (reader:'a when 'a :> XmlReader) (writer:'b when 'b :> XmlWriter):Task = writer.WriteAttributesAsync(reader, defattr)
    
    let writeBase64 (count:int) (index:int) (buffer:byte array) (writer:'b when 'b :> XmlWriter):unit = writer.WriteBase64(buffer, index, count)
    
    let writeBase64Async (count:int) (index:int) (buffer:byte array) (writer:'b when 'b :> XmlWriter):Task = writer.WriteBase64Async(buffer, index, count)
    
    let writeBinHex (count:int) (index:int) (buffer:byte array) (writer:'b when 'b :> XmlWriter):unit = writer.WriteBinHex(buffer, index, count)
    
    let writeBinHexAsync (count:int) (index:int) (buffer:byte array) (writer:'b when 'b :> XmlWriter):Task = writer.WriteBinHexAsync(buffer, index, count)
    
    let writeCData (text:string) (writer:'b when 'b :> XmlWriter):unit = writer.WriteCData(text)
    
    let writeCDataAsync (text:string) (writer:'b when 'b :> XmlWriter):Task = writer.WriteCDataAsync(text)
    
    let writeCharEntity (ch:char) (writer:'b when 'b :> XmlWriter):unit = writer.WriteCharEntity(ch)
    
    let writeCharEntityAsync (ch:char) (writer:'b when 'b :> XmlWriter):Task = writer.WriteCharEntityAsync(ch)
    
    let writeChars (count:int) (index:int) (buffer:char array) (writer:'b when 'b :> XmlWriter):unit = writer.WriteChars(buffer, index, count)
    
    let writeCharsAsync (count:int) (index:int) (buffer:char array) (writer:'b when 'b :> XmlWriter):Task = writer.WriteCharsAsync(buffer, index, count)
    
    let writeComment (text:string) (writer:'b when 'b :> XmlWriter):unit = writer.WriteComment(text)
    
    let writeCommentAsync (text:string) (writer:'b when 'b :> XmlWriter):Task = writer.WriteCommentAsync(text)
    
    let writeDocType (name:string) (pubid:string) (sysid:string) (subset:string) (writer:'b when 'b :> XmlWriter):unit = writer.WriteDocType(name, pubid, sysid, subset)
    
    let writeDocTypeAsync (name:string) (pubid:string) (sysid:string) (subset:string) (writer:'b when 'b :> XmlWriter):Task = writer.WriteDocTypeAsync(name, pubid, sysid, subset)
    
    let writeEndAttribute (writer:'b when 'b :> XmlWriter):unit = writer.WriteEndAttribute()
    
    let writeEndDocument (writer:'b when 'b :> XmlWriter):unit = writer.WriteEndDocument()
    
    let writeEndDocumentAsync (writer:'b when 'b :> XmlWriter):Task = writer.WriteEndDocumentAsync()
    
    let writeEndElement (writer:'b when 'b :> XmlWriter):unit = writer.WriteEndElement()
    
    let writeEndElementAsync (writer:'b when 'b :> XmlWriter):Task = writer.WriteEndElementAsync()
    
    let writeEntityRef (name:string) (writer:'b when 'b :> XmlWriter):unit = writer.WriteEntityRef(name)
    
    let writeEntityRefAsync (name:string) (writer:'b when 'b :> XmlWriter):Task = writer.WriteEntityRefAsync(name)
    
    let writeFullEndElement (writer:'b when 'b :> XmlWriter):unit = writer.WriteFullEndElement()
    
    let writeFullEndElementAsync (writer:'b when 'b :> XmlWriter):Task = writer.WriteFullEndElementAsync()
    
    let writeName (name:string) (writer:'b when 'b :> XmlWriter):unit = writer.WriteName(name)
    
    let writeNameAsync (name:string) (writer:'b when 'b :> XmlWriter):Task = writer.WriteNameAsync(name)
    
    let writeNmToken (name:string) (writer:'b when 'b :> XmlWriter):unit = writer.WriteNmToken(name)
    
    let writeNmTokenAsync (name:string) (writer:'b when 'b :> XmlWriter):Task = writer.WriteNmTokenAsync(name)
    
    let writeProcessingInstruction (text:string) (name:string) (writer:'b when 'b :> XmlWriter):unit = writer.WriteProcessingInstruction(name, text)
    
    let writeProcessingInstructionAsync (text:string) (name:string) (writer:'b when 'b :> XmlWriter):Task = writer.WriteProcessingInstructionAsync(name, text)
    
    let writeQualifiedName (ns:string) (localName:string) (writer:'b when 'b :> XmlWriter):unit = writer.WriteQualifiedName(localName, ns)
    
    let writeQualifiedNameAsync (ns:string) (localName:string) (writer:'b when 'b :> XmlWriter):Task = writer.WriteQualifiedNameAsync(localName, ns)
    
    let writeString (text:string) (writer:'b when 'b :> XmlWriter):unit = writer.WriteString(text)
    
    let writeStringAsync (text:string) (writer:'b when 'b :> XmlWriter):Task = writer.WriteStringAsync(text)
    
    let writeSurrogateCharEntity (lowChar:char) (highChar:char) (writer:'b when 'b :> XmlWriter):unit = writer.WriteSurrogateCharEntity(lowChar, highChar)
    
    let writeSurrogateCharEntityAsync (lowChar:char) (highChar:char) (writer:'b when 'b :> XmlWriter):Task = writer.WriteSurrogateCharEntityAsync(lowChar, highChar)
    
    let writeValue (valueTypes:ValueTypes) (writer:'b when 'b :> XmlWriter):unit =
        match valueTypes with
        | Single(single:single) -> writer.WriteValue(single)
        | Object(obj:obj) -> writer.WriteValue(obj)
        | Int64(int64:int64) -> writer.WriteValue(int64)
        | Int32(int32:int32) -> writer.WriteValue(int32)
        | Double(double:double) -> writer.WriteValue(double)
        | String(string:string) -> writer.WriteValue(string)
        | DateTimeOffset(dateTimeOffset:DateTimeOffset) -> writer.WriteValue(dateTimeOffset)
        | DateTime(dateTime:DateTime) -> writer.WriteValue(dateTime)
        | Boolean(bool:bool) -> writer.WriteValue(bool)
        | Decimal(decimal:decimal) -> writer.WriteValue(decimal)
    
    let writeWhitespace (ws:string) (writer:'b when 'b :> XmlWriter):unit = writer.WriteWhitespace(ws)
    
    let writeWhitespaceAsync (ws:string) (writer:'b when 'b :> XmlWriter):Task = writer.WriteWhitespaceAsync(ws)