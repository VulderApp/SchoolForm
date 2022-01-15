using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vulder.School.Form.Core.Models;
using Vulder.School.Form.IntegrationTests.Fixtures;
using Xunit;

namespace Vulder.School.Form.IntegrationTests.Controllers.Forms;

public class ApproveSchoolFormControllerTest
{
    [Fact]
    public async Task POST_Responds_200_StatusCode()
    {
        var formModel = new SchoolFormModel
        {
            Email = "example@example.com",
            SchoolName = "ZSP 2 w Warszawie",
            SchoolUrl = "https://example.com",
            TimetableUrl = "https://example.com/timetable"
        };

        await using var application = new WebAppFactoryFixture();
        using var client = application.CreateClient();
        var httpContent = new StringContent(JsonConvert.SerializeObject(formModel), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("/form/SubmitSchoolForm", httpContent);

        var formId =
            JsonConvert.DeserializeObject<Core.ProjectAggregate.Form.Form>(await response.Content.ReadAsStringAsync())!.Id;
        var approveModel = new SchoolFormApproveModel
        {
            FormId = formId
        };

        httpContent = new StringContent(JsonConvert.SerializeObject(approveModel), Encoding.UTF8, "application/json");
        using var approveFormResponse = await client.PostAsync("/form/ApproveSchoolForm", httpContent);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}