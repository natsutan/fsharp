module Logger

type LogLevel = 
    | DEBUG = 0
    | INFO = 1     
    | WARNING = 2
    | ERROR = 3
    | MESSEGE = 4 

type Logger() = 
    //propertiy
    let mutable log_level:LogLevel = LogLevel.MESSEGE
    
    member x.Level  
        with get() = log_level
        and set(level:LogLevel) = log_level <- level

    member x.Log(msg:string, level:LogLevel) =
        if level >= log_level then
            match level with  
            | LogLevel.DEBUG -> printfn "DEBUG: %s" msg
            | LogLevel.INFO -> printfn "INFO: %s" msg
            | _ -> printfn "%s" msg



