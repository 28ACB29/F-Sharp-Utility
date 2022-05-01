namespace FSUtility

open System
open System.Threading.Tasks
open System.Xml
open System.Xml.Schema

module XMLWriter =

    let private boolToOption (value:bool):unit option =
        match value with
        | true -> Some()
        | false -> None

    let settings (writer:'a when 'a :> XmlWriter):XmlWriterSettings = writer.Settings
  
    let writeState (writer:'a when 'a :> XmlWriter):WriteState = writer.WriteState
  
    let xmlLang (writer:'a when 'a :> XmlWriter):string = writer.XmlLang
  
    let xmlSpace (writer:'a when 'a :> XmlWriter):XmlSpace = writer.XmlSpace

    let close  (writer:'a when 'a :> XmlWriter):unit = writer.Close()

