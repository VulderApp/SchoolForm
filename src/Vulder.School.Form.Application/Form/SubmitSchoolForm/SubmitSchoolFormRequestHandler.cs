using MediatR;
using Vulder.School.Form.Infrastructure.Database.Interfaces;

namespace Vulder.School.Form.Application.Form.SubmitSchoolForm;

public class
    SubmitSchoolFormRequestHandler : IRequestHandler<Core.ProjectAggregate.Form.Form, Core.ProjectAggregate.Form.Form>
{
    private readonly IFormRepository _formRepository;

    public SubmitSchoolFormRequestHandler(IFormRepository formRepository)
    {
        _formRepository = formRepository;
    }

    public async Task<Core.ProjectAggregate.Form.Form> Handle(Core.ProjectAggregate.Form.Form request,
        CancellationToken cancellationToken)
    {
        await _formRepository.Create(request.CreatePublishTime());

        return request;
    }
}