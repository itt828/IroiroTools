module IroiroTools.Client.Main

open System
open Elmish
open Bolero
open Bolero.Html
open Bolero.Remoting
open Bolero.Remoting.Client
open Bolero.Templating.Client
open IroiroTools.Client.views.Home

type Page = | [<EndPoint "/">] Home

type Model = { page: Page }

let initModel = { page = Home }, Cmd.none

type Message = SetPage of Page

let update message model =
    match message with
    | SetPage page -> { model with page = page }, Cmd.none

let router = Router.infer SetPage (fun model -> model.page)

let view model dispatch = homePage

type MyApp() =
    inherit ProgramComponent<Model, Message>()
    override this.Program = Program.mkProgram (fun _ -> initModel) update view
