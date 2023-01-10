namespace FSUtility

open System
open System.Text.RegularExpressions

type configuration =
    | Default
    | Options of RegexOptions
    | OptionsTimeout of RegexOptions * TimeSpan

type replaceMember =
    | Replacement of string
    | Evaluator of MatchEvaluator
    | ReplacementCount of string * int
    | EvaluatorCount of MatchEvaluator * int
    | ReplacementCountStartAt of string * int * int
    | EvaluatorCountStartAt of MatchEvaluator * int * int

type replaceStatic =
    | Replacement of string
    | Evaluator of MatchEvaluator
    | ReplacementOption of string * RegexOptions
    | EvaluatorOption of MatchEvaluator * RegexOptions
    | ReplacementOptionTimeout of string * RegexOptions * TimeSpan
    | EvaluatorOptionTimeout of MatchEvaluator * RegexOptions * TimeSpan

type splitMember =
    | Default
    | Count of int
    | CountStartAt of int * int


module RegularExpression =

    let cacheSize:int = Regex.CacheSize

    let matchTimeout (regex:Regex):TimeSpan = regex.MatchTimeout

    let options (regex:Regex):RegexOptions = regex.Options

    let rightToLeft (regex:Regex):bool = regex.RightToLeft

    let escape (str:string):string = Regex.Escape(str)

    let getGroupNames (regex:Regex):string array = regex.GetGroupNames()

    let getGroupNumbers (regex:Regex):int array = regex.GetGroupNumbers()

    let groupNameFromNumber (i:int) (regex:Regex):string = regex.GroupNameFromNumber(i)

    let groupNumberFromName (name:string) (regex:Regex):int = regex.GroupNumberFromName(name)

    let isMatchMember (index:int option) (input:string) (regex:Regex):bool =
        match index with
        | None -> regex.IsMatch(input)
        | Some(startat:int) -> regex.IsMatch(input, startat)

    let isMatchStatic (configuration:configuration) (pattern:string) (input:string):bool =
        match configuration with
        | configuration.Default -> Regex.IsMatch(input, pattern)
        | Options(options:RegexOptions) -> Regex.IsMatch(input, pattern, options)
        | OptionsTimeout(options:RegexOptions, matchTimeout:TimeSpan) -> Regex.IsMatch(input, pattern, options, matchTimeout)

    let matchesMember (index:int option) (input:string) (regex:Regex):MatchCollection =
        match index with
        | None -> regex.Matches(input)
        | Some(startat:int) -> regex.Matches(input, startat)

    let matchesStatic (configuration:configuration) (pattern:string) (input:string):MatchCollection =
        match configuration with
        | configuration.Default -> Regex.Matches(input, pattern)
        | Options(options:RegexOptions) -> Regex.Matches(input, pattern, options)
        | OptionsTimeout(options:RegexOptions, matchTimeout:TimeSpan) -> Regex.Matches(input, pattern, options, matchTimeout)

    let replaceMember (replace:replaceMember) (input:string) (regex:Regex):string = 
        match replace with
        | replaceMember.Replacement(replacement:string) -> regex.Replace(input, replacement)
        | replaceMember.Evaluator(evaluator:MatchEvaluator) -> regex.Replace(input, evaluator)
        | ReplacementCount(replacement:string, count:int) -> regex.Replace(input, replacement, count)
        | EvaluatorCount(evaluator:MatchEvaluator, count:int) -> regex.Replace(input, evaluator, count)
        | ReplacementCountStartAt(replacement:string, count:int, startAt:int) -> regex.Replace(input, replacement, count, startAt)
        | EvaluatorCountStartAt(evaluator:MatchEvaluator, count:int, startAt:int) -> regex.Replace(input, evaluator, count, startAt)

    let replaceStatic (replace:replaceStatic) (pattern:string) (input:string):string =
        match replace with
        | replaceStatic.Replacement(replacement:string) -> Regex.Replace(input, pattern, replacement)
        | replaceStatic.Evaluator(evaluator:MatchEvaluator) -> Regex.Replace(input, pattern, evaluator)
        | ReplacementOption(replacement:string, options:RegexOptions) -> Regex.Replace(input, pattern, replacement, options)
        | EvaluatorOption(evaluator:MatchEvaluator, options:RegexOptions) -> Regex.Replace(input, pattern, evaluator, options)
        | ReplacementOptionTimeout(replacement:string, options:RegexOptions, matchTimeOut:TimeSpan) -> Regex.Replace(input, pattern, replacement, options, matchTimeOut)
        | EvaluatorOptionTimeout(evaluator:MatchEvaluator, options:RegexOptions, matchTimeOut:TimeSpan) -> Regex.Replace(input, pattern, evaluator, options, matchTimeOut)

    let splitMember (split:splitMember) (input:string) (regex:Regex):string array =
        match split with
        | Default -> regex.Split(input)
        | Count(count:int) -> regex.Split(input, count)
        | CountStartAt(count:int, startAt:int) -> regex.Split(input, count, startAt)

    let splitStatic (configuration:configuration) (pattern:string) (input:string):string array =
        match configuration with
        | configuration.Default -> Regex.Split(input, pattern)
        | Options(options:RegexOptions) -> Regex.Split(input, pattern, options)
        | OptionsTimeout(options:RegexOptions, matchTimeout:TimeSpan) -> Regex.Split(input, pattern, options, matchTimeout)

    let unescape (str:string):string = Regex.Unescape(str)