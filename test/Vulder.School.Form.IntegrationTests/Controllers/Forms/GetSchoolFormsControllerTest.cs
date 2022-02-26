using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vulder.School.Form.Core.Models;
using Vulder.School.Form.IntegrationTests.Fixtures;
using Xunit;

namespace Vulder.School.Form.IntegrationTests.Controllers.Forms;

public class GetSchoolFormsController
{
    [Fact]
    public async Task GET_Responds_200_StatusCode()
    {
        var formModel = new SchoolFormModel
        {
            Email = "example@example.com",
            SchoolName = "ZSP 3 w Warszawie",
            SchoolUrl = "https://example.com",
            TimetableUrl = "https://example.com/timetable"
        };

        await using var application = new WebAppFactoryFixture();
        using var client = application.CreateClient();
        var httpContent = new StringContent(JsonConvert.SerializeObject(formModel), Encoding.UTF8, "application/json");
        await client.PostAsync("/form/SubmitSchoolForm", httpContent);

        using var response = await client.GetAsync("/form/GetSchoolForms?page=1");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}