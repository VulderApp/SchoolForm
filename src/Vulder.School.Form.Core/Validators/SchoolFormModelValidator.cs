using FluentValidation;
using Vulder.School.Form.Core.Models;

namespace Vulder.School.Form.Core.Validators;

public class SchoolFormModelValidator : AbstractValidator<SchoolFormModel>
{
    public SchoolFormModelValidator()
    {
        RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();
        RuleFor(x => x.SchoolName).NotEmpty().MinimumLength(10);
        RuleFor(x => x.SchoolUrl).NotEmpty().NotNull();
        RuleFor(x => x.TimetableUrl).NotEmpty().NotNull();
    }
}