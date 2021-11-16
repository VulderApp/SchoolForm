using System.Threading.Tasks;
using FluentValidation.TestHelper;
using Vulder.School.Form.Core.Models;
using Vulder.School.Form.Core.Validators;
using Xunit;

namespace Vulder.School.Form.UnitTests.Core.Validators;

public class SchoolFormModelValidatorTest
{
    [Fact]
    public void TestSchoolFormModelValidator_AssetsTrue()
    {
        var validator = new SchoolFormModelValidator();
        
        var model = new SchoolFormModel
        {
            Email = "example@example.com",
            SchoolName = "ZSP 1 w Warszawie",
            SchoolUrl = "https://example.com",
            TimetableUrl = "https://example.com/Timetable"
        };
        
        Assert.True(validator.TestValidate(model).IsValid);
    }
}