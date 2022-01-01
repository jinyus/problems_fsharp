module Utils

let printAndReturn (arg: 'a) : 'a =
    printfn "%A" arg
    arg
