namespace Hexalith.Shift.Domain.Facade;

using Microsoft.Extensions.Localization;
using Microsoft.FSharp.Collections;

public class FormatableText
{
    private readonly IStringLocalizer? L;

    public FormatableText(string text, object[]? arguments = default, IStringLocalizer? stringLocalizer = default)
    {
        Text = text;
        Arguments = arguments ?? Array.Empty<object>();
        L = stringLocalizer;
    }

    public FormatableText(Domain.FormatableText formatable, IStringLocalizer? stringLocalizer = default)
    {
        Text = formatable.Text;
        Arguments = formatable.Arguments.ToArray();
        L = stringLocalizer;
    }

    public FormatableText(FormatableText formatable, IStringLocalizer? stringLocalizer = default)
    {
        Text = formatable.Text;
        Arguments = formatable.Arguments;
        L = stringLocalizer;
    }

    public object[] Arguments { get; }
    public string Text { get; }

    public static implicit operator string(FormatableText text)
        => text.ToString();

    public override string ToString()
        => string.Format((L == null) ? Text : L[Text], Arguments);

    public static implicit operator Domain.FormatableText(FormatableText text)
        => new(text.Text, ListModule.OfSeq(text.Arguments));
}