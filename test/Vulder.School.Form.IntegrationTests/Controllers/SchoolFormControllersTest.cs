using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Vulder.School.Form.Core.Models;
using Vulder.School.Form.IntegrationTests.Fixtures;
using Newtonsoft.Json;
using Xunit;
using Xunit.Priority;
using System.Net;
using Vulder.School.Form.Core.ProjectAggregate.Form.Dtos;

namespace Vulder.School.Form.IntegrationTests.Controllers;

[Collection("School form collection")]
[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public class SchoolFormControllersTest
{
    private const int ExpectedPages = 1;

    private readonly SchoolFormFixture _schoolFormFixture;

    public SchoolFormControllersTest(SchoolFormFixture schoolFormFixture)
    {
        _schoolFormFixture = schoolFormFixture;
    }

    private static async Task<HttpResponseMessage> SubmitSchoolForm(SchoolFormModel body)
    {
        await using var application = new WebAppFactoryFixture();
        using var client = application.CreateClient();
        var httpContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/form/SubmitSchoolForm", httpContent);

        return response;
    }

    [Fact]
    [Priority(0)]
    public async Task SubmitSchoolForm_POST_Responds_200_StatusCode()
    {
        var body = new SchoolFormModel
        {
            Email = "example@example.com",
            SchoolName = "ZSP 2 w Warszawie",
            SchoolUrl = "https://example.com",
            TimetableUrl = "https://example.com/timetable"
        };

        var response = await SubmitSchoolForm(body);
        var schoolForm = JsonConvert.DeserializeObject<Core.ProjectAggregate.Form.Form>(await response.Content.ReadAsStringAsync());
        _schoolFormFixture.Form = schoolForm;

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(body.Email, schoolForm.RequesterEmail);
        Assert.Equal(body.SchoolName, schoolForm.SchoolName);
        Assert.Equal(body.TimetableUrl, schoolForm.TimetableUrl);
        Assert.Equal(body.SchoolUrl, schoolForm.SchoolUrl);
    }

    [Fact]
    [Priority(1)]
    public async Task SchoolForm_GET_Responds_200_StatusCode()
    {
        await using var application = new WebAppFactoryFixture();
        using var client = application.CreateClient();

        using var response = await client.GetAsync($"/form/GetSchoolForm?formId={_schoolFormFixture.Form.Id}");
        var schoolForm = JsonConvert.DeserializeObject<Core.ProjectAggregate.Form.Form>(await response.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(_schoolFormFixture.Form.Id, schoolForm.Id);
        Assert.Equal(_schoolFormFixture.Form.SchoolName, schoolForm.SchoolName);
        Assert.Equal(_schoolFormFixture.Form.TimetableUrl, schoolForm.TimetableUrl);
        Assert.Equal(_schoolFormFixture.Form.SchoolUrl, schoolForm.SchoolUrl);
    }

    [Fact]
    [Priority(2)]
    public async Task SchoolForms_GET_Responds_200_StatusCode()
    {
        await using var application = new WebAppFactoryFixture();
        using var client = application.CreateClient();

        using var response = await client.GetAsync("/form/GetSchoolForms?page=1");
        var schoolForms = JsonConvert.DeserializeObject<FormsDto>(await response.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(ExpectedPages, schoolForms.Pages);
        Assert.NotEmpty(schoolForms.Forms);
    }

    [Fact]
    [Priority(3)]
    public async Task ApproveSchoolForm_POST_Responds_200_StatusCode()
    {
        var approveModel = new SchoolFormApproveModel
        {
            FormId = _schoolFormFixture.Form.Id
        };

        await using var application = new WebAppFactoryFixture();
        using var client = application.CreateClient();

        var httpContent = new StringContent(JsonConvert.SerializeObject(approveModel), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("/form/ApproveSchoolForm", httpContent);
        var schoolForm = JsonConvert.DeserializeObject<Core.ProjectAggregate.Form.Form>(await response.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(schoolForm);
    }

    [Fact]
    [Priority(4)]
    public async Task RefuseSchoolForm_PUT_Responds_200_StatusCode()
    {
        var body = new SchoolFormModel
        {
            Email = "example@example.com",
            SchoolName = "ZSP 1 w Warszawie",
            SchoolUrl = "https://example.com",
            TimetableUrl = "https://example.com/timetable"
        };

        var schoolFormResponse = await SubmitSchoolForm(body);
        var schoolForm = JsonConvert.DeserializeObject<Core.ProjectAggregate.Form.Form>(await schoolFormResponse.Content.ReadAsStringAsync());

        await using var application = new WebAppFactoryFixture();
        using var client = application.CreateClient();

        var refuseSchoolFormModel = new RefuseSchoolFormModel
        {
            FormId = schoolForm.Id,
        };

        var httpContent = new StringContent(JsonConvert.SerializeObject(refuseSchoolFormModel), Encoding.UTF8,
            "application/json");
        using var response = await client.PutAsync("/form/RefuseSchoolForm", httpContent);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}