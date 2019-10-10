namespace FSUtility

open System.Collections.Generic

module Memoizer =

    let memoize (method:'a -> 'b):'a -> 'b =
        let cache:Dictionary<'a, 'b> = Dictionary<'a, 'b>()
        fun (argument:'a) ->
            match cache.ContainsKey(argument) with
            | true -> ()
            | false -> cache.[argument] <- method argument
            cache.[argument]