namespace FSUtility

open System
open System.Globalization

module Character =

    let (|Control|_|) (character:char) =
        match Char.IsControl(character) with
        | true ->
            character
            |> Some
        | false -> None

    let (|Digit|_|) (character:char) =
        match Char.IsDigit(character) with
        | true ->
            character
            |> Some
        | false -> None

    let (|HighSurrogate|_|) (character:char) =
        match Char.IsHighSurrogate(character) with
        | true ->
            character
            |> Some
        | false -> None

    let (|Letter|_|) (character:char) =
        match Char.IsLetter(character) with
        | true ->
            character
            |> Some
        | false -> None

    let (|LowSurrogate|_|) (character:char) =
        match Char.IsLowSurrogate(character) with
        | true ->
            character
            |> Some
        | false -> None

    let (|Lower|_|) (character:char) =
        match Char.IsLower(character) with
        | true ->
            character
            |> Some
        | false -> None

    let (|Punctuation|_|) (character:char) =
        match Char.IsPunctuation(character) with
        | true ->
            character
            |> Some
        | false -> None

    let (|Number|_|) (character:char) =
        match Char.IsNumber(character) with
        | true ->
            character
            |> Some
        | false -> None

    let (|Separator|_|) (character:char) =
        match Char.IsSeparator(character) with
        | true ->
            character
            |> Some
        | false -> None

    let (|Surrogate|_|) (character:char) =
        match Char.IsSurrogate(character) with
        | true ->
            character
            |> Some
        | false -> None

    let (|Symbol|_|) (character:char) =
        match Char.IsSymbol(character) with
        | true ->
            character
            |> Some
        | false -> None

    let (|Upper|_|) (character:char) =
        match Char.IsUpper(character) with
        | true ->
            character
            |> Some
        | false -> None

    let (|WhiteSpace|_|) (character:char) =
        match Char.IsWhiteSpace(character) with
        | true ->
            character
            |> Some
        | false -> None

    let ToLower (culture:CultureInfo) (c:char):char = Char.ToLower(c, culture)

    let ToUpper (culture:CultureInfo) (c:char):char = Char.ToUpper(c, culture)

