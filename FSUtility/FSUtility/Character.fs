namespace FSUtility

open System
open System.Globalization

module Character =

    let private yieldIfTrue (predicate:char -> bool) (character:char) =
        match predicate character with
        | true ->
            character
            |> Some
        | false -> None

    let (|Control|_|) (character:char) = yieldIfTrue Char.IsControl character

    let (|Digit|_|) (character:char) = yieldIfTrue Char.IsDigit character

    let (|HighSurrogate|_|) (character:char) = yieldIfTrue Char.IsHighSurrogate character

    let (|Letter|_|) (character:char) = yieldIfTrue Char.IsLetter character

    let (|LowSurrogate|_|) (character:char) = yieldIfTrue Char.IsLowSurrogate character

    let (|Lower|_|) (character:char) = yieldIfTrue Char.IsLower character

    let (|Punctuation|_|) (character:char) = yieldIfTrue Char.IsPunctuation character

    let (|Number|_|) (character:char) = yieldIfTrue Char.IsNumber character

    let (|Separator|_|) (character:char) = yieldIfTrue Char.IsSeparator character

    let (|Surrogate|_|) (character:char) = yieldIfTrue Char.IsSurrogate character

    let (|Symbol|_|) (character:char) = yieldIfTrue Char.IsSymbol character

    let (|Upper|_|) (character:char) = yieldIfTrue Char.IsUpper character

    let (|WhiteSpace|_|) (character:char) = yieldIfTrue Char.IsWhiteSpace character

    let ToLower (culture:CultureInfo) (c:char):char = Char.ToLower(c, culture)

    let ToUpper (culture:CultureInfo) (c:char):char = Char.ToUpper(c, culture)

