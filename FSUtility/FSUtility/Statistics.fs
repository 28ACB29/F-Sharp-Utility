namespace FSUtility

open System

module Statistics =

    let median (data:double array):double =
        let length:int = Array.length data
        match length % 2 with
        | 0 -> (data.[length / 2 - 1] + data.[length / 2] |> double) / 2.0
        | _ -> double data.[length / 2]

    let mode (data:'a array when 'a : comparison):'a when 'a : comparison =
        let counts:('a * int) array = Array.countBy id data
        let maxCount:int =
            counts
            |> Array.maxBy (fun (_, count:int) -> count)
            |> snd
        let mostCommon:('a * int) array =
            counts
            |> Array.filter (fun (_, count:int) -> count = maxCount)
            |> Array.sortBy (fun (item:'a, _) -> item)
        mostCommon.[0] |> fst

    let quartiles (data:double array):(double * double * double) =
        let length:int = Array.length data
        match length % 2 with
        | 0 -> (median(data.[..length / 2 - 1]), median(data), median(data.[length / 2..]))
        | _ ->  (median(data.[..length / 2 - 1]), median(data), median(data.[length / 2 + 1..]))

    let residuals (data:double array):double array =
        let mean:double = Array.average data
        Array.map (fun element -> element - mean) data

    let sigma (data:double array):double =
        let n:double =
            data
            |> Array.length
            |> double
        let totalResiduals:double =
            data
            |> residuals
            |> Array.fold(fun acculumator element -> acculumator + pown element 2) 0.0
        Math.Sqrt((totalResiduals) / n)

    let product (array:int array):int =
        array
        |> Array.fold(fun accumulator element -> accumulator * element) 1

    let factorial (n:int):int = product [|1..n|]

    let binomialCoefficient (n:int) (k:int):int =
        (product [|n - (k - 1)..n|]) / (factorial k)

    let binomialDistribution (n:int) (k:int) (p:double):double =
        (k |> binomialCoefficient n |> double) * (pown p k) * (pown (1.0 - p) (n - k))

    let geometricDistribution (k:int) (p:double):double = (pown (1.0 - p) (k - 1)) * p

    let poissionDistribution (k:int) (lambda:double):double = (pown lambda k) * Math.Exp(-1.0 * lambda) / (k |> factorial |> double)

    let standardScore (mu:double) (sigma:double) (x:double) = (x - mu) / sigma

    let normalDistribution (mu:double) (sigma:double) (x:double):double =
        let z:double =
            x
            |> standardScore mu sigma
        Math.Exp(-0.5 * (pown z 2)) / (sigma * Math.Sqrt(2.0 * Math.PI))

    let cumulativeDistribution (mu:double) (sigma:double) (x:double):double =
        let integrate (a:double) (b:double) =
            let stepSize:float = 0.001
            let steps:int =
                (b - a) / stepSize
                |> Math.Ceiling
                |> int
            let intervalSize = (b - a) / (steps |> double)
            let intervalMidpoint = intervalSize / 2.0
            ([|1..2..2 * steps + 1|] |> Array.fold(fun accumulator element -> accumulator + normalDistribution 0.0 1.0 (a + (element |> double) * intervalMidpoint)) 0.0) * intervalSize
        let z = standardScore mu sigma x
        match Math.Sign(z) with
        | -1 -> integrate z 0.0
        | 0 -> 0.0
        | 1 -> integrate 0.0 z

    let covariance (X:double array) (Y:double array):double =
        let n:double =
            X
            |> Array.length
            |> double
        let residualsX:double array = residuals X
        let residualsY:double array = residuals Y
        (Array.fold2(fun accumulator element1 element2 -> accumulator + element1 * element2) 0.0 residualsX residualsY) / n

    let rho (X:double array) (Y:double array):double =
        let sigmaX:double = sigma X
        let sigmaY:double = sigma Y
        covariance X Y / (sigmaX * sigmaY)

    let converToRanks(data:'a array when 'a : comparison):int array =
        let sorted = data |> Array.sort
        data |> Array.map(fun element1 -> Array.findIndex(fun element2 -> element1 = element2) sorted)

    let r (X:'a array) (Y:'a array):double =
        let n:double = X |> Array.length |> double
        let rankX:int array = converToRanks(X)
        let rankY:int array = converToRanks(Y)
        let d:double = Array.fold2(fun accumulator element1 element2 -> accumulator + pown (element1 - element2) 2) 0 rankX rankY |> double
        1.0 - (6.0 * d / (n * (pown n 2 - 1.0)))

    let linearRegression (X:double array) (Y:double array):(double * double) =
        let b:double = (covariance X Y) / (covariance X X)
        let a:double = (Array.average Y) - b * (Array.average X)
        (a, b)



