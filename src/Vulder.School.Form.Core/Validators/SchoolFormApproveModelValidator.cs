using FluentValidation;
using Vulder.School.Form.Core.Models;

namespace Vulder.School.Form.Core.Validators;

public class SchoolFormApproveModelValidator : AbstractValidator<SchoolFormApproveModel>
{
    public SchoolFormApproveModelValidator()
    {
        RuleFor(x => x.FormId).NotNull().NotEmpty();
    }
}