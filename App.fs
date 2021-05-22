module challenge.App
open Giraffe
open Microsoft.AspNetCore.Http

type Message =
    {
        Text : string
    }

let indexHandler (name : string) =
    let greetings = sprintf "Hello %s, from Giraffe!" name
    text greetings

let webApp : HttpFunc -> HttpContext -> HttpFuncResult =
    choose [
        GET >=>
            choose [
                route "/" >=> indexHandler "world"
                routef "/hello/%s" indexHandler
            ]
        setStatusCode 404 >=> text "Not Found" ]