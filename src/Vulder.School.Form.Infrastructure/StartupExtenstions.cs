using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Vulder.School.Form.Core.Models;
using Vulder.School.Form.Core.Validators;

namespace Vulder.School.Form.Infrastructure;

public static class StartupExtenstions
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddTransient<IValidator<SchoolFormModel>, SchoolFormModelValidator>();
        services.AddTransient<IValidator<SchoolFormApproveModel>, SchoolFormApproveModelValidator>();
    }
}