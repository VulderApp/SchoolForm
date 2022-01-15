using MediatR;
using Vulder.School.Form.Core.Models;
using Vulder.School.Form.Infrastructure.Database.Interfaces;

namespace Vulder.School.Form.Application.Admin.GetSchoolForms;

public class GetSchoolFormsRequestHandler : IRequestHandler<SchoolFormCollectionModel, List<Core.ProjectAggregate.Form.Form>>
{
    private readonly IFormRepository _formRepository;

    public GetSchoolFormsRequestHandler(IFormRepository formRepository)
    {
        _formRepository = formRepository;
    }

    public async Task<List<Core.ProjectAggregate.Form.Form>> Handle(SchoolFormCollectionModel request, CancellationToken cancellationToken)
    {
        return await _formRepository.GetFormList(request.Page);
    }
}