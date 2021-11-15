using MediatR;

namespace Vulder.School.Form.Core.Models;

public class SchoolFormModel : IRequest<SchoolFormModel>
{
    public string? Email { get; set; }
    public string? SchoolName { get; set; }
    public string? SchoolUrl { get; set; }
    public string? TimetableUrl { get; set; }
}