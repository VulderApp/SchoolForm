using MediatR;
using Vulder.School.Form.Core.Models;
using Vulder.School.Form.Infrastructure.Database.Interfaces;

namespace Vulder.School.Form.Application.Form.ApproveSchoolForm;

public class
    ApproveSchoolFormRequestHandler : IRequestHandler<SchoolFormApproveRequestModel, Unit>
{
    private readonly IFormRepository _formRepository;

    public ApproveSchoolFormRequestHandler(IFormRepository formRepository)
    {
        _formRepository = formRepository;
    }

    public async Task<Unit> Handle(SchoolFormApproveRequestModel request,
        CancellationToken cancellationToken)
    {
        var form = await _formRepository.GetById(request.FormId);

        form.Approved = true;
        form.ApproveAdminId = request.AdminId;
        form.SetApproveTime();

        await _formRepository.Update(form);

        return Unit.Value;
    }
}