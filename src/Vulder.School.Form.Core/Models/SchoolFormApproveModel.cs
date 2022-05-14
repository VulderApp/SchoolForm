using MediatR;

namespace Vulder.School.Form.Core.Models;

public class SchoolFormApproveModel : INotification
{
    public Guid FormId { get; set; }
}