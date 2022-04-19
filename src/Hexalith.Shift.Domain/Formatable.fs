namespace Hexalith.Shift.Domain

type FormatableText = { Text: string; Arguments: obj list }

module Formatable =
    let create (text: string, arguments: obj list) : FormatableText = { Text = text; Arguments = arguments }