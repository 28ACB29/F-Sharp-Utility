namespace FSUtility

open System

module BaseConvert =

    let digitsToNumber (inputBase:uint64) (digits:uint64 list):uint64 =
        digits
        |> List.fold (fun (number:uint64) (digit:uint64) -> number * inputBase + digit) 0UL

    let numberTodigits (outputBase:uint64) (number:uint64):uint64 list =
        let rec tailCall (digits:uint64 list) (remainder:uint64):uint64 list =
            match remainder with
            | 0UL -> digits
            | _ -> tailCall ((remainder % outputBase)::digits) (remainder / outputBase)
        tailCall [] number

    let rebase (digits:uint64 list) (inputBase:uint64) (outputBase:uint64):uint64 list option =
        match inputBase, outputBase with
        | inputBase, outputBase when inputBase > 1UL && outputBase > 1UL && List.forall (fun (digit:uint64) -> digit < inputBase) digits ->
            digits
            |> digitsToNumber inputBase
            |> numberTodigits outputBase
            |> Some
        | _ -> None

