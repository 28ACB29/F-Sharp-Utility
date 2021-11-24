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

    let private boolToOption (value:bool):unit option =
        match value with
        | true -> Some()
        | false -> None

    let (|EndsWith|_|) (value:string) (s:string) =
        s.EndsWith(value)
        |> boolToOption

    let (|NullOrEmpty|_|) (value:string) =
        String.IsNullOrEmpty(value)
        |> boolToOption

    let (|NullOrWhiteSpace|_|) (value:string) =
        String.IsNullOrWhiteSpace(value)
        |> boolToOption

    let (|Normalized|_|) (normalizationFormOption:NormalizationForm option) (s:string) =
        match normalizationFormOption with
        | None ->
            s.IsNormalized()
            |> boolToOption
        | Some(normalizationForm:NormalizationForm) ->
            s.IsNormalized(normalizationForm)
            |> boolToOption

    let (|StartsWith|_|) (value:string) (s:string) =
        s.StartsWith(value)
        |> boolToOption

    let slice (startIndex:int) (endIndex:int) (s:string):string = s.Substring(startIndex, endIndex - startIndex)

    let chars (index:int) (s:string):char = s.Chars index

    let compareOrdinal (options:(int * int * int) option) (strA:string) (strB:string):int =
        match options with
        | None ->  String.CompareOrdinal(strA, strB)
        | Some((indexA:int), (indexB:int), (length:int)) ->  String.CompareOrdinal(strA, indexA, strB, indexB, length)

    let indexOf (value:char) (s:string):int = s.IndexOf(value)

    let indexOfAny (ofAny:char array) (s:string):int = s.IndexOfAny(ofAny)

    let insert (startIndex:int) (value:string) (s:string):string = s.Insert(startIndex, value)

    let lastIndexOf (value:char) (s:string):int = s.LastIndexOf(value)

    let lastIndexOfAny (ofAny:char array) (s:string):int = s.LastIndexOfAny(ofAny)

    let length (s:string):int = s.Length

    let normalize (normalizationFormOption:NormalizationForm option) (s:string):string =
        match normalizationFormOption with
        | None -> s.Normalize()
        | Some(normalizationForm:NormalizationForm) -> s.Normalize(normalizationForm)

    let padLeft (paddingCharOption:char option) (totalWidth:int) (s:string):string =
        match paddingCharOption with
        | None -> s.PadLeft(totalWidth)
        | Some(paddingChar:char) -> s.PadLeft(totalWidth, paddingChar)

    let padRight (paddingCharOption:char option) (totalWidth:int) (s:string):string =
        match paddingCharOption with
        | None -> s.PadRight(totalWidth)
        | Some(paddingChar:char) -> s.PadRight(totalWidth, paddingChar)

    let remove (countOption:int option) (startIndex:int) (s:string):string =
        match countOption with
        | None -> s.Remove(startIndex)
        | Some(count:int) -> s.Remove(startIndex, count)

    let replaceChar (oldChar:char) (newChar:char) (s:string):string = s.Replace(oldChar, newChar)

    let replaceString (oldValue:string) (newValue:string) (s:string):string = s.Replace(oldValue, newValue)

    let split (separator:char array) (s:string):string array = s.Split(separator)

    let substring (startIndex:int) (lengthOption:int option) (s:string):string =
        match lengthOption with
        | None -> s.Substring(startIndex)
        | Some(length:int) -> s.Substring(startIndex, length)

    let toCharArray (s:string):char array = s.ToCharArray()

    let toLower (cultureInfoOption:CultureInfo option) (s:string):string =
        match cultureInfoOption with
        | None -> s.ToLower()
        | Some(cultureInfo:CultureInfo) -> s.ToLower(cultureInfo)

    let toLowerInvariant (s:string):string = s.ToLowerInvariant()

    let toUpper (cultureInfoOption:CultureInfo option) (s:string):string =
        match cultureInfoOption with
        | None -> s.ToLower()
        | Some(cultureInfo:CultureInfo) -> s.ToLower(cultureInfo)

    let toUpperInvariant (s:string):string = s.ToUpperInvariant()

    let trim (trimCharsOption:char array option) (s:string):string =
        match trimCharsOption with
        | None -> s.Trim()
        | Some(trimChars:char array) -> s.Trim(trimChars)

    let trimEnd (trimChars:char array) (s:string):string = s.TrimEnd(trimChars)

    let TrimStart (trimChars:char array) (s:string):string = s.TrimStart(trimChars)