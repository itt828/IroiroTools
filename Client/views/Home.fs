module IroiroTools.Client.views.Home

open Bolero.Html

let bodyStyle =
    attr.``style``
        "  display: flex;
  flex-direction: column;"

let homePage = div { p { "oisu-" } }
