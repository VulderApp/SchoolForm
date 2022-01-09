using MediatR;

namespace Vulder.School.Form.Core.Models;

public class SchoolFormCollectionModel : IRequest<List<ProjectAggregate.Form.Form>>
{
    public int Page { get; set; }
}