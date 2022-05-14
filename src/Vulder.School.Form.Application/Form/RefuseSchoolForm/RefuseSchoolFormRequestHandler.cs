using MediatR;
using Vulder.School.Form.Core.Models;
using Vulder.School.Form.Core.ProjectAggregate;
using Vulder.School.Form.Infrastructure.Database.Interfaces;

namespace Vulder.School.Form.Application.Form.RefuseSchoolForm;

public class RefuseSchoolFormRequestHandler : IRequestHandler<SchoolFormRefuseRequestModel, Unit>
{
    private readonly IFormRepository _formRepository;

    public RefuseSchoolFormRequestHandler(IFormRepository formRepository)
    {
        _formRepository = formRepository;
    }

    public async Task<Unit> Handle(SchoolFormRefuseRequestModel request, CancellationToken cancellationToken)
    {
        var form = await _formRepository.GetById(request.FormId);

        if (form.Status.Equals(Status.Refused)) throw new Exception("This form was refused");
        if (form.Status.Equals(Status.Approved)) throw new Exception("This form was approved");

        form.SetRefuse(request.AdminId);

        await _formRepository.Update(form);

        return Unit.Value;
    }
}