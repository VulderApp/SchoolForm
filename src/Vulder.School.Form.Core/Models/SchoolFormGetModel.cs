using MediatR;

namespace Vulder.School.Form.Core.Models;

public class SchoolFormGetModel : IRequest<ProjectAggregate.Form.Form>
{
    public Guid Id { get; set; }
}