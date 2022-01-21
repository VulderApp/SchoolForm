using MediatR;

namespace Vulder.School.Form.Core.Models;

public class SchoolFormRefuseRequestModel : SchoolFormRefuseModel, IRequest
{
    public Guid AdminId { get; set; }
}