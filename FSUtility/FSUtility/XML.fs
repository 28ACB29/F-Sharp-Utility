namespace FSUtility

open System
open System.Threading.Tasks
open System.Xml
open System.Xml.Schema

module XML =

    // Start XMLNode

    let private boolToOption (value:bool):unit option =
        match value with
        | true -> Some()
        | false -> None

    let (|ChildNodes|_|) (node:'a when 'a :> XmlNode) =
        node.HasChildNodes
        |> boolToOption

    let (|LocalName|_|) (node:'a when 'a :> XmlNode) =
        try
            node.LocalName
            |> Some
        with
            | _ -> None

    let (|Name|_|) (node:'a when 'a :> XmlNode) =
        try
            node.Name
            |> Some
        with
            | _ -> None

    let (|NodeType|_|) (node:'a when 'a :> XmlNode) =
        try
            node.NodeType
            |> Some
        with
            | _ -> None

    let (|ReadOnly|_|) (node:'a when 'a :> XmlNode) =
        node.IsReadOnly
        |> boolToOption

    let (|Supports|_|) (feature:string) (version:string) (node:'a when 'a :> XmlNode) =
        node.Supports(feature, version)
        |> boolToOption

    let attributes (node:'a when 'a :> XmlNode):XmlAttributeCollection = node.Attributes

    let baseURI (node:'a when 'a :> XmlNode):string = node.BaseURI
    
    let childNodes (node:'a when 'a :> XmlNode):XmlNodeList = node.ChildNodes
    
    let firstChild (node:'a when 'a :> XmlNode):XmlNode = node.FirstChild
    
    let innerText (node:'a when 'a :> XmlNode):string = node.InnerText
    
    let innerXml (node:'a when 'a :> XmlNode):string = node.InnerXml
    
    let lastChild (node:'a when 'a :> XmlNode):XmlNode = node.LastChild
    
    let namespaceURI (node:'a when 'a :> XmlNode):string = node.NamespaceURI
    
    let nextSibling (node:'a when 'a :> XmlNode):XmlNode = node.NextSibling
    
    let outerXml (node:'a when 'a :> XmlNode):string = node.OuterXml
    
    let ownerDocument (node:'a when 'a :> XmlNode):XmlDocument = node.OwnerDocument
    
    let parentNode (node:'a when 'a :> XmlNode):XmlNode = node.ParentNode
    
    let prefix (node:'a when 'a :> XmlNode):string = node.Prefix
    
    let previousSibling (node:'a when 'a :> XmlNode):XmlNode = node.PreviousSibling
    
    let previousText (node:'a when 'a :> XmlNode):XmlNode = node.PreviousText
    
    let schemaInfo (node:'a when 'a :> XmlNode):IXmlSchemaInfo = node.SchemaInfo
    
    let value (node:'a when 'a :> XmlNode):string = node.Value
    
    let appendChild (newChild:'a when 'a :> XmlNode) (node:'a when 'a :> XmlNode):XmlNode = node.AppendChild(newChild)
    
    let getNamespaceOfPrefix (prefix:string) (node:'a when 'a :> XmlNode):string = node.GetNamespaceOfPrefix(prefix)
    
    let getPrefixOfNamespace (namespaceURI:string) (node:'a when 'a :> XmlNode):string = node.GetPrefixOfNamespace(namespaceURI)
    
    let insertAfter (refChild:'a when 'a :> XmlNode) (newChild:'a when 'a :> XmlNode) (node:'a when 'a :> XmlNode):XmlNode = node.InsertAfter(newChild, refChild)
    
    let insertBefore (refChild:'a when 'a :> XmlNode) (newChild:'a when 'a :> XmlNode) (node:'a when 'a :> XmlNode):XmlNode = node.InsertBefore(newChild, refChild)
    
    let normalize (node:'a when 'a :> XmlNode):'a when 'a :> XmlNode =
        node.Normalize()
        node
    
    let prependChild (newChild:'a when 'a :> XmlNode) (node:'a when 'a :> XmlNode):XmlNode = node.PrependChild(newChild)
    
    let removeAll (node:'a when 'a :> XmlNode):'a when 'a :> XmlNode =
        node.RemoveAll()
        node
    
    let removeChild (oldChild:'a when 'a :> XmlNode) (node:'a when 'a :> XmlNode):XmlNode =
        node.RemoveChild(oldChild) |> ignore
        node
    
    let replaceChild (oldChild:'a when 'a :> XmlNode) (newChild:'a when 'a :> XmlNode) (node:'a when 'a :> XmlNode):XmlNode =
        node.ReplaceChild(newChild, oldChild) |> ignore
        node
    
    let selectNodes (nsmgroption:XmlNamespaceManager option) (xpath:string) (node:'a when 'a :> XmlNode):XmlNodeList =
        match nsmgroption with
        | None -> node.SelectNodes(xpath)
        | Some(nsmgr:XmlNamespaceManager) -> node.SelectNodes(xpath, nsmgr)
    
    let selectSingleNode (nsmgroption:XmlNamespaceManager option) (xpath:string) (node:'a when 'a :> XmlNode):XmlNode =
        match nsmgroption with
        | None -> node.SelectSingleNode(xpath)
        | Some(nsmgr:XmlNamespaceManager) -> node.SelectSingleNode(xpath, nsmgr)

    let writeContentTo (w:XmlWriter) (node:'a when 'a :> XmlNode):unit = node.WriteContentTo(w)

    let writeTo (w:XmlWriter) (node:'a when 'a :> XmlNode):unit = node.WriteTo(w)

    // End XMLNode

    // Start XMLReader
    
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
    
    let xmlSpace (reader:'a when 'a :> XmlReader):string = reader.XmlSpace

    let close (reader:'a when 'a :> XmlReader):unit = reader.Close()

    let isName (str:string):bool = XmlReader.IsName(str)
    
    let isNameToken (str:string):bool = XmlReader.IsNameToken(str)
    
    let lookupNamespace (prefix:string) (reader:'a when 'a :> XmlReader):string = reader.LookupNamespace(prefix)
    
    let moveToContent (reader:'a when 'a :> XmlReader):unit = reader.MoveToContent()
    
    let moveToContentAsync (reader:'a when 'a :> XmlReader):Task<XmlNodeType> = reader.MoveToContentAsync()
    
    let moveToElement (reader:'a when 'a :> XmlReader):bool = reader.MoveToElement()
    
    let moveToFirstAttribute (reader:'a when 'a :> XmlReader):bool = reader.MoveToFirstAttribute()
    
    let moveToNextAttribute (reader:'a when 'a :> XmlReader):bool = reader.MoveToNextAttribute()
    
    let resolveEntity (reader:'a when 'a :> XmlReader):unit = reader.ResolveEntity()

    // End XMLReader

    // Start XMLWriter
    
    let settings (writer:'a when 'a :> XmlWriter):XmlWriterSettings = writer.Settings
    
    let writeState (writer:'a when 'a :> XmlWriter):WriteState = writer.WriteState
    
    let xmlLang (writer:'a when 'a :> XmlWriter):string = writer.XmlLang
    
    let xmlSpace (writer:'a when 'a :> XmlWriter):string = writer.XmlSpace

    let close  (writer:'a when 'a :> XmlWriter):unit = writer.Close()

    // End XMLWriter