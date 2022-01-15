using System;
using FluentValidation.TestHelper;
using Vulder.School.Form.Core.Models;
using Vulder.School.Form.Core.Validators;
using Xunit;

namespace Vulder.School.Form.UnitTests.Core.Validators;

public class SchoolFormApproveModelValidatorTest
{
    [Fact]
    public void TestSchoolFormApproveModelValidator_Correct()
    {
        var validator = new SchoolFormApproveModelValidator();

        var model = new SchoolFormApproveModel
        {
            FormId = Guid.NewGuid()
        };

        Assert.True(validator.TestValidate(model).IsValid);
    }
    
    [Fact]
    public void TestSchoolFormApproveModelValidator_NotValid()
    {
        var validator = new SchoolFormApproveModelValidator();
        var model = new SchoolFormApproveModel
        {
            FormId = Guid.Empty
        };

        Assert.False(validator.TestValidate(model).IsValid);
    }
}