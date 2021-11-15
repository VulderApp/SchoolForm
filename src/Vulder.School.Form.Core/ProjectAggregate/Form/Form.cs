using MediatR;
using Vulder.SharedKernel;

namespace Vulder.School.Form.Core.ProjectAggregate.Form;

public class Form : BaseEntity, IRequest<Form>
{
    public string? Email { get; set; }
    public string? SchoolName { get; set; }
    public string? SchoolUrl { get; set; }
    public string? TimetableUrl { get; set; }
    public DateTime CreatedAt { get; set; }

    public Form CreatePublishTime()
    {
        CreatedAt = DateTime.Now;

        return this;
    }
}