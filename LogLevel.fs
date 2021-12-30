module LogLevels
// https://exercism.org/tracks/fsharp/exercises/log-levels

let message (logLine: string) : string =
    (logLine.IndexOf ":" + 1 |> logLine.Substring)
        .Trim()


let logLevel (logLine: string) : string =
    logLine
        .Substring(1, logLine.IndexOf "]:" - 1)
        .ToLower()


let reformat (logLine: string) : string =
    sprintf "%s (%s)" (message logLine) (logLevel logLine)


printfn "'%s'" (message "[ERROR]: Invalid operation")
printfn "'%s'" (message "[WARNING]:  Disk almost full\r\n")
printfn "'%s'" (logLevel "[ERROR]: Invalid operation")
printfn "'%s'" (reformat "[INFO]: Operation completed")
