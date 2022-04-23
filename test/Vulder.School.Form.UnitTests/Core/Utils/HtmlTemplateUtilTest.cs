using System.Collections.Generic;
using Vulder.School.Form.Core.Utils;
using Xunit;

namespace Vulder.School.Form.UnitTests.Core.Utils;

public class HtmlTemplateUtilTest
{
    private const string ExpectedFormatedText = "<h1>This is example</h1>";

    [Fact]
    public async void CheckHtmlFormatingResult()
    {
        var formatters = new Dictionary<string, string>
        {
            {
                "text", "example"
            }
        };
        var result  = await HtmlTemplateUtil.Format(formatters, "templates/test.html");

        Assert.Equal(ExpectedFormatedText, result);
    }
}
