using MediatR;

namespace Vulder.School.Form.Core.Models;

public class SchoolFormApproveRequestModel : SchoolFormApproveModel, IRequest
{
    public Guid AdminId { get; set; }
}