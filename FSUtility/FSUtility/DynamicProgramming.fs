namespace FSUtility

open System
open System.Collections.Generic

module DynamicProgramming =

    let memoize (method:'a -> 'b):'a -> 'b =
        let cache:Dictionary<'a, 'b> = Dictionary<'a, 'b>()
        fun (argument:'a) ->
            match cache.ContainsKey(argument) with
            | true -> ()
            | false -> cache.[argument] <- method argument
            cache.[argument]

    let private distance (a:'a) (b:'a):int =
        match a = b with
        | true -> 0
        | false-> 1

    let editDistance (a:'a IList) (b:'a IList):int[,] =
        let m:int = a.Count;
        let n:int = b.Count;
        let distances:int[,] = Array2D.init m n (fun (i:int) (j:int) -> match i = 0 || j = 0 with | true -> Int32.MaxValue | false-> 0)
        for (i:int) in 0..m - 1 do
            for (j:int) in 0..n - 1 do
                // distances[i, j + 1] -> a[i] deletion, b[j] insertion
                // distances[i + 1, j] -> a[i] insertion, b[j] deletion
                // distances[i, j] -> a[i], b[j] match
                distances.[i, j] <- (distance a.[i] b.[j]) + min (min distances.[i, j + 1] distances.[i + 1, j]) distances.[i, j]
        distances