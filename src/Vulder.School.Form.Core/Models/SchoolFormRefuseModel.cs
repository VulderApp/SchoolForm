using MediatR;

namespace Vulder.School.Form.Core.Models;

public class RefuseSchoolFormModel : INotification
{
    public Guid FormId { get; set; }
}