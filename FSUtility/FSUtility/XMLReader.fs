namespace FSUtility

open System
open System.Threading.Tasks
open System.Xml
open System.Xml.Schema

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

    let close (reader:'a when 'a :> XmlReader):unit = reader.Close()
 
    let lookupNamespace (prefix:string) (reader:'a when 'a :> XmlReader):string = reader.LookupNamespace(prefix)
 
    let moveToContent (reader:'a when 'a :> XmlReader):XmlNodeType = reader.MoveToContent()
 
    let moveToContentAsync (reader:'a when 'a :> XmlReader):Task<XmlNodeType> = reader.MoveToContentAsync()
 
    let moveToElement (reader:'a when 'a :> XmlReader):bool = reader.MoveToElement()
 
    let moveToFirstAttribute (reader:'a when 'a :> XmlReader):bool = reader.MoveToFirstAttribute()
 
    let moveToNextAttribute (reader:'a when 'a :> XmlReader):bool = reader.MoveToNextAttribute()
 
    let resolveEntity (reader:'a when 'a :> XmlReader):unit = reader.ResolveEntity()