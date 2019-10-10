namespace FSUtility

open System

module Deque =

    type 'a ListDeque = Stacks of 'a list * 'a list

    let rec private shift (difference:int) (Stacks((front:'a list), (back:'a list)):'a ListDeque):('a ListDeque) =
        match Comparison.SignInt32 difference with
        | Negative -> shift (difference + 1) (Stacks((front.Tail), (front.Head::back)))
        | Zero -> Stacks((front:'a list), (back:'a list))
        | Positive -> shift (difference - 1) (Stacks((back.Head::front), (back.Tail)))

    let private rebalance (Stacks((front:'a list), (back:'a list)):'a ListDeque):('a ListDeque) =
        let frontSize:int = List.length front
        let backSize:int = List.length back
        let difference:int = backSize - frontSize
        shift (difference - Math.Sign difference) (Stacks((front:'a list), (back:'a list)))

    let Empty:'a ListDeque = Stacks([], [])

    let PeekBack (deque:'a ListDeque):'a option =
        match deque with
        | Stacks(_, (head:'a)::(tail:'a list)) -> Some(head)
        | _ -> None

    let PeekFront (deque:'a ListDeque):'a option =
        match deque with
        | Stacks((head:'a)::(tail:'a list), _) -> Some(head)
        | _ ->
            let rebalanced:'a ListDeque = rebalance deque
            match rebalanced with
            | Stacks((head:'a)::(tail:'a list), _) -> Some(head)
            | _ -> None

    let PopBack (deque:'a ListDeque):('a option * 'a ListDeque) =
        match deque with
        | Stacks((front:'a list), (head:'a)::(tail:'a list)) -> (Some(head), Stacks(front, tail))
        | _ ->
            let rebalanced:'a ListDeque = rebalance deque
            match rebalanced with
            | Stacks((front:'a list), (head:'a)::(tail:'a list)) -> (Some(head), Stacks(front, tail))
            | _ -> (None, deque)

    let PopFront (deque:'a ListDeque):('a option * 'a ListDeque) =
        match deque with
        | Stacks((head:'a)::(tail:'a list), (back:'a list)) -> (Some(head), Stacks(tail, back))
        | _ -> (None, deque)

    let PushBack (value:'a) (deque:'a ListDeque):('a ListDeque) =
        match deque with
        | Stacks((front:'a list), (back:'a list)) -> Stacks(front, value::back)

    let PushFront (value:'a) (deque:'a ListDeque):('a ListDeque) =
        match deque with
        | Stacks((front:'a list), (back:'a list)) -> Stacks(value::front, back)