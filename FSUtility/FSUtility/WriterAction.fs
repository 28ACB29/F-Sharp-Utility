namespace FSUtility

open System

type SideEffect<'a> = SideEffect of 'a * Action<'a>

module WriterAction =

    let writer (func:'a -> 'b1) (action:Action<'b1>):'a -> unit =
        action.Invoke << func

    let map (func:'a -> 'b) (sideEffectA:SideEffect<'a>):SideEffect<'b> =
        match sideEffectA with
        | SideEffect((value:'a), (action:Action<'a>)) ->
            action.Invoke value
            let newAction:Action<'b> = Action<'b>(func >> ignore)
            SideEffect(func value, newAction)

    let rtrn (value:'a) (action:Action<'a>):SideEffect<'a> = SideEffect((value:'a), (action:Action<'a>))

    let apply (sideEffectFunc:SideEffect<'a -> 'b>) (sideEffectA:SideEffect<'a>):SideEffect<'b> =
        match sideEffectFunc, sideEffectA with
        | SideEffect((func:'a -> 'b), (actionFunc:Action<'a -> 'b>)), SideEffect((value:'a), (action:Action<'a>)) ->
            let newAction:Action<'b> =
                action.Invoke value
                Action<'b>(func)
            SideEffect(func value, newAction)

    let bind (sideEffectFunc:'a -> SideEffect<'b>) (sideEffectA:SideEffect<'a>):SideEffect<'b> =
        match sideEffectA with
        | SideEffect((value:'a), (action:Action<'a>)) ->
            action.Invoke value
            sideEffectFunc value