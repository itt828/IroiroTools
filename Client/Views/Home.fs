module IroiroTools.Client.Views.Home

open Bolero.Html

let bodyStyle =
    attr.``style``
        "  display: flex;
  flex-direction: column;"

let homePage =
    div {
        p { "oisu-" }
        comp<AntDesign.Button> { "antdesign button" }
        button { "futuu no button" }
    }
