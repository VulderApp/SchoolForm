using MediatR;

namespace Vulder.School.Form.Core.Models;

public class SchoolFormApproveRequestModel : SchoolFormApproveModel, IRequest<ProjectAggregate.Form.Form>
{
    public Guid AdminId { get; set; }
}