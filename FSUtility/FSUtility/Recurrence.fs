namespace FSUtility

open System

module Recurrence =

    let ArrayDefinition (initialArray:'a array) (generator:'a array -> 'a):(int -> 'a) =
        let length:int = initialArray.Length
        let rec Equation (array:'a array) (n:int):'a =
            match n < length with
            | true -> array.[length - n]
            | false ->
                let newValue:'a = generator array
                let newArray:'a array = Array.permute (fun (i:int) -> if i < length - 1 then i + 1 else 0) array
                newArray.[length - 1] <- newValue
                Equation newArray (n - 1)
        Equation initialArray

    let ListDefinition (initialStack:'a list) (generator:'a list -> 'a):(int -> 'a) =
        let length:int = initialStack.Length
        let rec Equation (stack:'a list) (n:int):'a =
            match n < length with
            | true -> stack.[length - n]
            | false -> Equation ((generator stack)::stack) (n - 1)
        Equation initialStack