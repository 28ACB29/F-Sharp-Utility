namespace FSUtility

open System
open System.Globalization

module String =

    let Slice (startIndex:int) (endIndex:int) (s:string):string = s.Substring(startIndex, endIndex - startIndex)

    let EndsWith (value:string) (s:string):bool = s.EndsWith(value)

    let IndexOf (value:char) (s:string):int = s.IndexOf(value)

    let IndexOfAny (ofAny:char array) (s:string):int = s.IndexOfAny(ofAny)

    let Insert (startIndex:int) (value:string) (s:string):string = s.Insert(startIndex, value)

    let IsNormalized (s:string):bool = s.IsNormalized()

    let LastIndexOf (value:char) (s:string):int = s.LastIndexOf(value)

    let LastIndexOfAny (ofAny:char array) (s:string):int = s.LastIndexOfAny(ofAny)

    let Normalize (s:string):string = s.Normalize()

    let PadLeft (totalWidth:int) (paddingChar:char) (s:string):string = s.PadLeft(totalWidth, paddingChar)

    let PadRight (totalWidth:int) (paddingChar:char) (s:string):string = s.PadRight(totalWidth, paddingChar)

    let Remove (startIndex:int) (count:int) (s:string):string = s.Remove(startIndex, count)

    let Replace (oldValue:string) (newValue:string) (s:string):string = s.Replace(oldValue, newValue)

    let Split (separator:char array) (s:string):string array = s.Split(separator)

    let Substring (startIndex:int) (length:int) (s:string):string = s.Substring(startIndex, length)

    let StartsWith (value:string) (s:string):bool = s.StartsWith(value)

    let ToCharArray (s:string):char array = s.ToCharArray()

    let ToLower (culture:CultureInfo) (s:string):string = s.ToLower(culture)

    let ToLowerInvariant (s:string):string = s.ToLowerInvariant()

    let ToUpper (culture:CultureInfo) (s:string):string = s.ToUpper(culture)

    let ToUpperInvariant (s:string):string = s.ToUpperInvariant()

    let Trim (trimChars:char array) (s:string):string = s.Trim(trimChars)

    let TrimEnd (trimChars:char array) (s:string):string = s.TrimEnd(trimChars)

    let TrimStart (trimChars:char array) (s:string):string = s.TrimStart(trimChars)