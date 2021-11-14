using MediatR;
using Vulder.School.Form.Core.Models;

namespace Vulder.School.Form.Application.Form.SubmitSchoolForm;

public class SubmitSchoolFormCommandHandler : IRequestHandler<SchoolFormModel, SchoolFormModel>
{
    public Task<SchoolFormModel> Handle(SchoolFormModel request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}