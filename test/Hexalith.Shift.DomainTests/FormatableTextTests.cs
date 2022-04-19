namespace Hexalith.Shift.DomainTests;

using FluentAssertions;

using Hexalith.Shift.Domain.Facade;

using Microsoft.Extensions.Localization;

using NSubstitute;

using Xunit;

public class FormatableTextTests
{
    [Fact]
    public void Check_arguments_values()
    {
        var text = new FormatableText("", new object[] { "one", "two", "three", "four" });
        text.Arguments.Should().HaveCount(4);
        text.Arguments[0].Should().Be("one");
        text.Arguments[1].Should().Be("two");
        text.Arguments[2].Should().Be("three");
        text.Arguments[3].Should().Be("four");
    }

    [Fact]
    public void Check_cast_to_string_result()
    {
        FormatableText text = new("Hello {0} {1}", new object[] { "me", "you" });
        ((string)text).Should().Be("Hello me you");
    }

    [Fact]
    public void Check_text_value()
    {
        FormatableText text = new("Hello me");
        text.Text.Should().Be("Hello me");
    }

    [Fact]
    public void Check_to_string_localized_result()
    {
        IStringLocalizer localizer = Substitute.For<IStringLocalizer>();
        localizer["Hello {0} {1}"].Returns(new LocalizedString("Hello {0} {1}", "Hello {0} {1} in another language"));

        FormatableText text = new("Hello {0} {1}", new object[] { "me", "you" }, localizer);
        text.ToString().Should().Be("Hello me you in another language");
    }

    [Fact]
    public void Check_to_string_result()
    {
        FormatableText text = new("Hello {0} {1}", new object[] { "me", "you" });
        text.ToString().Should().Be("Hello me you");
    }
}