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

    let (|Control|_|) (character:char) =
        character
        |> yieldIfTrue Char.IsControl 

    let (|Digit|_|) (character:char) =
        character
        |> yieldIfTrue Char.IsDigit

    let (|HighSurrogate|_|) (character:char) =
        character
        |> yieldIfTrue Char.IsHighSurrogate

    let (|Letter|_|) (character:char) =
        character
        |> yieldIfTrue Char.IsLetter

    let (|LowSurrogate|_|) (character:char) =
        character
        |> yieldIfTrue Char.IsLowSurrogate

    let (|Lower|_|) (character:char) =
        character
        |> yieldIfTrue Char.IsLower

    let (|Punctuation|_|) (character:char) =
        character
        |> yieldIfTrue Char.IsPunctuation

    let (|Number|_|) (character:char) =
        character
        |> yieldIfTrue Char.IsNumber

    let (|Separator|_|) (character:char) =
        character
        |> yieldIfTrue Char.IsSeparator

    let (|Surrogate|_|) (character:char) =
        character
        |> yieldIfTrue Char.IsSurrogate

    let (|Symbol|_|) (character:char) =
        character
        |> yieldIfTrue Char.IsSymbol

    let (|Upper|_|) (character:char) =
        character
        |> yieldIfTrue Char.IsUpper

    let (|WhiteSpace|_|) (character:char) =
        character
        |>yieldIfTrue Char.IsWhiteSpace

    let ToLower (culture:CultureInfo) (c:char):char = Char.ToLower(c, culture)

    let ToUpper (culture:CultureInfo) (c:char):char = Char.ToUpper(c, culture)

