namespace FSUtility

open System
open System.IO
open System.Threading.Tasks
open System.Xml
open System.Xml.Schema

type CreateArguments =
    | InputStream of Stream
    | InputStreamSettings of Stream * XmlReaderSettings
    | InputStreamSettingsBaseUri of Stream * XmlReaderSettings * string
    | InputStreamSettingsInputContext of Stream * XmlReaderSettings * XmlParserContext
    | InputUri of string
    | InputUriSettings of string * XmlReaderSettings
    | InputUriSettingsInputContext of string * XmlReaderSettings * XmlParserContext
    | InputTextReader of TextReader
    | InputTextReaderSettings of TextReader * XmlReaderSettings
    | InputTextReaderSettingsBaseUri of TextReader * XmlReaderSettings * string
    | InputTextReaderSettingsInputContext of TextReader * XmlReaderSettings * XmlParserContext
    | ReaderSettings of XmlReader * XmlReaderSettings

module XMLReader =

    let private boolToOption (value:bool):unit option =
        match value with
        | true -> Some()
        | false -> None

    let (|ReadBinaryContent|_|) (reader:'a when 'a :> XmlReader) =
         reader.CanReadBinaryContent
         |> boolToOption
     
    let (|ReadValueChunk|_|) (reader:'a when 'a :> XmlReader) =
         reader.CanReadValueChunk
         |> boolToOption
     
    let (|ResolveEntity|_|) (reader:'a when 'a :> XmlReader) =
         reader.CanResolveEntity
         |> boolToOption
     
    let (|EOF|_|) (reader:'a when 'a :> XmlReader) =
         reader.EOF
         |> boolToOption
     
    let (|Default|_|) (reader:'a when 'a :> XmlReader) =
         reader.IsDefault
         |> boolToOption
     
    let (|EmptyElement|_|) (reader:'a when 'a :> XmlReader) =
         reader.IsEmptyElement
         |> boolToOption
  
    let (|Name|_|) (str:string) =
         XmlReader.IsName(str)
         |> boolToOption
  
    let (|NameToken|_|) (str:string) =
         XmlReader.IsNameToken(str)
         |> boolToOption

    let (|Attributes|_|) (reader:'a when 'a :> XmlReader) =
         reader.HasAttributes
         |> boolToOption

    let attributeCount (reader:'a when 'a :> XmlReader):int = reader.AttributeCount
 
    let baseURI (reader:'a when 'a :> XmlReader):string = reader.BaseURI
 
    let depth (reader:'a when 'a :> XmlReader):int = reader.Depth
 
    let localName (reader:'a when 'a :> XmlReader):string = reader.LocalName
 
    let name (reader:'a when 'a :> XmlReader):string = reader.Name
 
    let namespaceURI (reader:'a when 'a :> XmlReader):string = reader.NamespaceURI
 
    let nameTable (reader:'a when 'a :> XmlReader):XmlNameTable = reader.NameTable
 
    let nodeType (reader:'a when 'a :> XmlReader):XmlNodeType = reader.NodeType
 
    let prefix (reader:'a when 'a :> XmlReader):string = reader.Prefix
 
    let quoteChar (reader:'a when 'a :> XmlReader):char = reader.QuoteChar
 
    let readState (reader:'a when 'a :> XmlReader):ReadState = reader.ReadState
 
    let schemaInfo (reader:'a when 'a :> XmlReader):IXmlSchemaInfo = reader.SchemaInfo
 
    let settings (reader:'a when 'a :> XmlReader):XmlReaderSettings = reader.Settings
 
    let value (reader:'a when 'a :> XmlReader):string = reader.Value
 
    let valueType (reader:'a when 'a :> XmlReader):Type = reader.ValueType
 
    let xmlLang (reader:'a when 'a :> XmlReader):string = reader.XmlLang
 
    let xmlSpace (reader:'a when 'a :> XmlReader):XmlSpace = reader.XmlSpace
    
    let create (createArguments:CreateArguments):XmlReader =
        match createArguments with
        | InputStream(input:Stream) -> XmlReader.Create(input)
        | InputStreamSettings(input:Stream, settings:XmlReaderSettings) -> XmlReader.Create(input, settings)
        | InputStreamSettingsBaseUri(input:Stream, settings:XmlReaderSettings, baseUri:string) -> XmlReader.Create(input, settings, baseUri)
        | InputStreamSettingsInputContext(input:Stream, settings:XmlReaderSettings, inputContext:XmlParserContext) -> XmlReader.Create(input, settings, inputContext)
        | InputUri(inputUri:string) -> XmlReader.Create(inputUri)
        | InputUriSettings(inputUri:string, settings:XmlReaderSettings) -> XmlReader.Create(inputUri, settings)
        | InputUriSettingsInputContext(inputUri:string, settings:XmlReaderSettings, inputContext:XmlParserContext) -> XmlReader.Create(inputUri, settings, inputContext)
        | InputTextReader(input:TextReader) -> XmlReader.Create(input)
        | InputTextReaderSettings(input:TextReader, settings:XmlReaderSettings) -> XmlReader.Create(input, settings)
        | InputTextReaderSettingsBaseUri(input:TextReader, settings:XmlReaderSettings, baseUri:string) -> XmlReader.Create(input, settings, baseUri)
        | InputTextReaderSettingsInputContext(input:TextReader, settings:XmlReaderSettings, inputContext:XmlParserContext) -> XmlReader.Create(input, settings, inputContext)
        | ReaderSettings(xmlReader:XmlReader, settings:XmlReaderSettings) -> XmlReader.Create(xmlReader, settings)

    let close (reader:'a when 'a :> XmlReader):unit = reader.Close()
 
    let lookupNamespace (prefix:string) (reader:'a when 'a :> XmlReader):string = reader.LookupNamespace(prefix)
 
    let moveToContent (reader:'a when 'a :> XmlReader):XmlNodeType = reader.MoveToContent()
 
    let moveToContentAsync (reader:'a when 'a :> XmlReader):Task<XmlNodeType> = reader.MoveToContentAsync()
 
    let moveToElement (reader:'a when 'a :> XmlReader):bool = reader.MoveToElement()
 
    let moveToFirstAttribute (reader:'a when 'a :> XmlReader):bool = reader.MoveToFirstAttribute()
 
    let moveToNextAttribute (reader:'a when 'a :> XmlReader):bool = reader.MoveToNextAttribute()
    
    let read (reader:'a when 'a :> XmlReader):bool = reader.Read()
    
    let readAsync (reader:'a when 'a :> XmlReader):Task<bool> = reader.ReadAsync()
    
    let readAttributeValue (reader:'a when 'a :> XmlReader):bool = reader.ReadAttributeValue()
    
    let readContentAs (returnType:Type) (namespaceResolver:IXmlNamespaceResolver) (reader:'a when 'a :> XmlReader):obj = reader.ReadContentAs(returnType, namespaceResolver)
    
    let readContentAsAsync (returnType:Type) (namespaceResolver:IXmlNamespaceResolver) (reader:'a when 'a :> XmlReader):Task<obj> = reader.ReadContentAsAsync(returnType, namespaceResolver)
    
    let readContentAsBase64 (count:int) (index:int) (buffer:byte array) (reader:'a when 'a :> XmlReader):int = reader.ReadContentAsBase64(buffer, index, count)
    
    let readContentAsBase64Async (count:int) (index:int) (buffer:byte array) (reader:'a when 'a :> XmlReader):Task<int> = reader.ReadContentAsBase64Async(buffer, index, count)
    
    let readContentAsBoolean (reader:'a when 'a :> XmlReader):bool = reader.ReadContentAsBoolean()
    
    let readContentAsDateTime (reader:'a when 'a :> XmlReader):DateTime = reader.ReadContentAsDateTime()
    
    let readContentAsDateTimeOffset (reader:'a when 'a :> XmlReader):DateTimeOffset = reader.ReadContentAsDateTimeOffset()
    
    let readContentAsDecimal (reader:'a when 'a :> XmlReader):decimal = reader.ReadContentAsDecimal()
    
    let readContentAsDouble (reader:'a when 'a :> XmlReader):double = reader.ReadContentAsDouble()
    
    let readContentAsFloat (reader:'a when 'a :> XmlReader):single = reader.ReadContentAsFloat()
    
    let readContentAsInt (reader:'a when 'a :> XmlReader):int = reader.ReadContentAsInt()
    
    let readContentAsLong (reader:'a when 'a :> XmlReader):int64 = reader.ReadContentAsLong()
    
    let readContentAsObject (reader:'a when 'a :> XmlReader):obj = reader.ReadContentAsObject()
    
    let readContentAsObjectAsync (reader:'a when 'a :> XmlReader):Task<obj> = reader.ReadContentAsObjectAsync()
    
    let readContentAsString (reader:'a when 'a :> XmlReader):string = reader.ReadContentAsString()
    
    let readContentAsStringAsync (reader:'a when 'a :> XmlReader):Task<string> = reader.ReadContentAsStringAsync()
    
    let readElementContentAsAsync (returnType:Type) (namespaceResolver:IXmlNamespaceResolver) (reader:'a when 'a :> XmlReader):Task<obj> = reader.ReadElementContentAsAsync(returnType, namespaceResolver)
    
    let readElementContentAsBase64 (count:int) (index:int) (buffer:byte array) (reader:'a when 'a :> XmlReader):int = reader.ReadElementContentAsBase64(buffer, index, count)
    
    let readElementContentAsBase64Async (count:int) (index:int) (buffer:byte array) (reader:'a when 'a :> XmlReader):Task<int> = reader.ReadElementContentAsBase64Async(buffer, index, count)
    
    let readElementContentAsBoolean (reader:'a when 'a :> XmlReader):bool = reader.ReadElementContentAsBoolean()
    
    let readElementContentAsDateTime (reader:'a when 'a :> XmlReader):DateTime = reader.ReadElementContentAsDateTime()
    
    let readElementContentAsDecimal (reader:'a when 'a :> XmlReader):decimal = reader.ReadElementContentAsDecimal()
    
    let readElementContentAsDouble (reader:'a when 'a :> XmlReader):double = reader.ReadElementContentAsDouble()
    
    let readElementContentAsFloat (reader:'a when 'a :> XmlReader):single = reader.ReadElementContentAsFloat()
    
    let readElementContentAsInt (reader:'a when 'a :> XmlReader):int = reader.ReadElementContentAsInt()
    
    let readElementContentAsLong (reader:'a when 'a :> XmlReader):int64 = reader.ReadElementContentAsLong()
    
    let readElementContentAsObject (reader:'a when 'a :> XmlReader):obj = reader.ReadElementContentAsObject()
    
    let readElementContentAsObjectAsync (reader:'a when 'a :> XmlReader):Task<obj> = reader.ReadElementContentAsObjectAsync()
    
    let readElementContentAsString (reader:'a when 'a :> XmlReader):string = reader.ReadElementContentAsString()
    
    let readElementContentAsStringAsync (reader:'a when 'a :> XmlReader):Task<string> = reader.ReadElementContentAsStringAsync()

    let readEndElement (reader:'a when 'a :> XmlReader):unit = reader.ReadEndElement()
    
    let readInnerXml (reader:'a when 'a :> XmlReader):string = reader.ReadInnerXml()
    
    let readInnerXmlAsync (reader:'a when 'a :> XmlReader):Task<string> = reader.ReadInnerXmlAsync()
    
    let readOuterXml (reader:'a when 'a :> XmlReader):string = reader.ReadOuterXml()
    
    let readOuterXmlAsync (reader:'a when 'a :> XmlReader):Task<string> = reader.ReadOuterXmlAsync()
    
    let readString (reader:'a when 'a :> XmlReader):string = reader.ReadString()
    
    let readSubtree (reader:'a when 'a :> XmlReader):XmlReader = reader.ReadSubtree()
    
    let readValueChunk (count:int) (index:int) (buffer:char array) (reader:'a when 'a :> XmlReader):int = reader.ReadValueChunk(buffer, index, count)
    
    let readValueChunkAsync (count:int) (index:int) (buffer:char array) (reader:'a when 'a :> XmlReader):Task<int> = reader.ReadValueChunkAsync(buffer, index, count)
    
    let resolveEntity (reader:'a when 'a :> XmlReader):unit = reader.ResolveEntity()
    
    let skip (reader:'a when 'a :> XmlReader):unit = reader.Skip()
    
    let skipAsync (reader:'a when 'a :> XmlReader):Task = reader.SkipAsync()