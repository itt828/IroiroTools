module IroiroTools.Client.Views.ImagePreviewer

open Bolero
open Bolero.Html
open Elmish
open Microsoft.AspNetCore.Components.Forms
open System

let getImage (file: IBrowserFile) =
    async {
        let buf: byte[] = Array.zeroCreate (file.Size |> int)
        let! x = file.OpenReadStream().ReadAsync(buf).AsTask() |> Async.AwaitTask
        return "data:image/png;base64," + (Convert.ToBase64String buf)
    }

type Model = { file: string }
let initModel = { file = "" }

type Message =
    | UploadFile of IBrowserFile
    | FileUploaded of string

let update message model =
    match message with
    | UploadFile file -> model, Cmd.OfAsync.perform getImage file Message.FileUploaded
    | FileUploaded image -> { model with file = image }, Cmd.none


let imagePreviewerComponent model dispatch =
    match model.file with
    | "" ->
        div {
            comp<InputFile> {
                attr.``type`` "file"
                attr.callback "OnChange" (fun (e: InputFileChangeEventArgs) -> dispatch (UploadFile e.File))
            }
        }
    | f -> img { "src" => f }

type ImagePreviewer() =
    inherit ProgramComponent<Model, Message>()

    override this.Program =
        Program.mkProgram (fun _ -> initModel, Cmd.none) update imagePreviewerComponent

let ImagePreviewerPage () = div { comp<ImagePreviewer> }
