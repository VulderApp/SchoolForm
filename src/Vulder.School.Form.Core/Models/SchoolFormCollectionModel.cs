using MediatR;
using Vulder.School.Form.Core.ProjectAggregate.Form.Dtos;

namespace Vulder.School.Form.Core.Models;

public class SchoolFormCollectionModel : IRequest<FormsDto>
{
    public int Page { get; set; }
}