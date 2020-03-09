namespace FSUtility

open System
open System.Globalization
open System.Text

module String =

    let (|Interned|_|) (str:string) =
        match str with
        | null -> None
        | _ ->
            str
            |> String.IsInterned
            |> Some

    let (|NullOrEmpty|_|) (value:string) =
        match String.IsNullOrEmpty(value) with
        | true -> Some()
        | false -> None

    let (|NullOrWhiteSpace|_|) (value:string) =
        match String.IsNullOrWhiteSpace(value) with
        | true -> Some()
        | false -> None

    let Slice (startIndex:int) (endIndex:int) (s:string):string = s.Substring(startIndex, endIndex - startIndex)

    let EndsWith (value:string) (s:string):bool = s.EndsWith(value)

    let IndexOf (value:char) (s:string):int = s.IndexOf(value)

    let IndexOfAny (ofAny:char array) (s:string):int = s.IndexOfAny(ofAny)

    let Insert (startIndex:int) (value:string) (s:string):string = s.Insert(startIndex, value)

    let IsNormalized (normalizationFormOption: NormalizationForm option) (s:string):bool =
        match normalizationFormOption with
        | None -> s.IsNormalized()
        | Some(normalizationForm: NormalizationForm) -> s.IsNormalized(normalizationForm)

    let LastIndexOf (value:char) (s:string):int = s.LastIndexOf(value)

    let LastIndexOfAny (ofAny:char array) (s:string):int = s.LastIndexOfAny(ofAny)

    let Normalize (normalizationFormOption: NormalizationForm option) (s:string):string =
        match normalizationFormOption with
        | None -> s.Normalize()
        | Some(normalizationForm: NormalizationForm) -> s.Normalize(normalizationForm)

    let PadLeft (totalWidth:int) (paddingCharOption:char option) (s:string):string =
        match paddingCharOption with
        | None -> s.PadLeft(totalWidth)
        | Some(paddingChar: char) -> s.PadLeft(totalWidth, paddingChar)

    let PadRight (totalWidth:int) (paddingCharOption:char option) (s:string):string =
        match paddingCharOption with
        | None -> s.PadRight(totalWidth)
        | Some(paddingChar: char) -> s.PadRight(totalWidth, paddingChar)

    let Remove (startIndex:int) (countOption:int option) (s:string):string =
        match countOption with
        | None -> s.Remove(startIndex)
        | Some(count: int) -> s.Remove(startIndex, count)

    let Replace (oldValue:string) (newValue:string) (s:string):string = s.Replace(oldValue, newValue)

    let Split (separator:char array) (s:string):string array = s.Split(separator)

    let Substring (startIndex:int) (lengthOption:int option) (s:string):string =
        match lengthOption with
        | None -> s.Substring(startIndex)
        | Some(length: int) -> s.Substring(startIndex, length)

    let StartsWith (value:string) (s:string):bool = s.StartsWith(value)

    let ToCharArray (s:string):char array = s.ToCharArray()

    let ToLower (cultureInfoOption:CultureInfo option) (s:string):string =
        match cultureInfoOption with
        | None -> s.ToLower()
        | Some(cultureInfo: CultureInfo) -> s.ToLower(cultureInfo)

    let ToLowerInvariant (s:string):string = s.ToLowerInvariant()

    let ToUpper (cultureInfoOption:CultureInfo option) (s:string):string =
        match cultureInfoOption with
        | None -> s.ToLower()
        | Some(cultureInfo: CultureInfo) -> s.ToLower(cultureInfo)

    let ToUpperInvariant (s:string):string = s.ToUpperInvariant()

    let Trim (trimCharsOption:char array option) (s:string):string =
        match trimCharsOption with
        | None -> s.Trim()
        | Some(trimChars: char array) -> s.Trim(trimChars)

    let TrimEnd (trimChars:char array) (s:string):string = s.TrimEnd(trimChars)

    let TrimStart (trimChars:char array) (s:string):string = s.TrimStart(trimChars)