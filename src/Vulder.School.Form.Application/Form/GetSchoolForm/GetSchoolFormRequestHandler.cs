using MediatR;
using Vulder.School.Form.Core.Models;
using Vulder.School.Form.Infrastructure.Database.Interfaces;

namespace Vulder.School.Form.Application.Form.GetSchoolForm;

public class GetSchoolFormRequestHandler : IRequestHandler<SchoolFormGetModel, Core.ProjectAggregate.Form.Form>
{
    private readonly IFormRepository _formRepository;

    public GetSchoolFormRequestHandler(IFormRepository formRepository)
    {
        _formRepository = formRepository;
    }

    public Task<Core.ProjectAggregate.Form.Form> Handle(SchoolFormGetModel request, CancellationToken cancellationToken)
    {
        return _formRepository.GetById(request.Id);
    }
}