namespace FSUtility

open System
open System.Collections.Generic

module SequenceMetric =

    let levenshteinDistance (a:'a IList) (b:'a IList):int =
        let m:int = Seq.length a
        let n:int = Seq.length b
        let distances:int [,] = Array2D.init (1 + m) (1 + m) (fun (i:int) (j:int) -> 0)
        for i in 0 .. m do 
            for j in 0 .. n do
                distances.[i,j] <- if a.[i] = b.[j] then 1 else 0 + Math.Min(Math.Min(distances.[i, j + 1], distances.[i + 1, j]), distances.[i, j])
        distances.[m, n]
        
    let timeWarpDistance (distance:'a -> 'a -> int) (a:'a IList) (b:'a IList):int =
        let m:int = Seq.length a
        let n:int = Seq.length b
        let distances:int [,] = Array2D.init (1 + m) (1 + m) (fun (i:int) (j:int) -> if (i = 0) <> (j = 0) then Int32.MaxValue else 0)
        for i in 0 .. m do 
            for j in 0 .. n do
                distances.[i,j] <- distance a.[i] b.[j] + Math.Min(Math.Min(distances.[i, j + 1], distances.[i + 1, j]), distances.[i, j])
        distances.[m, n]