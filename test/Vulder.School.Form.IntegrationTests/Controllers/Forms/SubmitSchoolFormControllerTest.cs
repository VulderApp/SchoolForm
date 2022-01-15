using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Vulder.School.Form.Core.Models;
using Vulder.School.Form.IntegrationTests.Fixtures;
using Xunit;

namespace Vulder.School.Form.IntegrationTests.Controllers.Forms;

public class SubmitSchoolFormControllerTest
{
    [Fact]
    public async Task POST_Responds_200_StatusCode()
    {
        var body = new SchoolFormModel
        {
            Email = "example@example.com",
            SchoolName = "ZSP 1 w Warszawie",
            SchoolUrl = "https://example.com",
            TimetableUrl = "https://example.com/timetable"
        };

        await using var application = new WebAppFactoryFixture();
        using var client = application.CreateClient();
        var httpContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("/form/SubmitSchoolForm", httpContent);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}