using MediatR;

namespace Vulder.School.Form.Core.Models;

public class SchoolFormRefuseRequestModel : RefuseSchoolFormModel, IRequest
{
    public Guid AdminId { get; set; }
}