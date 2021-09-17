module Tests

open System
open System.Net.Http.Json
open FSharpWebApiTemplate
open Microsoft.AspNetCore.Mvc.Testing
open Xunit

[<Fact>]
let ``My test`` () =
    Assert.True(true)

[<Fact>]
let ``WebApplicationFactory test`` () =
    async {
        let webApp = new WebApplicationFactory<WeatherForecast>()
        let client = webApp.CreateDefaultClient()
        let! forecast = client.GetFromJsonAsync<WeatherForecast[]>("/weatherforecast") |> Async.AwaitTask
        Assert.Equal(5, forecast.Length)
    }
