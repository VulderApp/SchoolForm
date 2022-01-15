using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Vulder.SharedKernel;

namespace Vulder.School.Form.Core.ProjectAggregate.Form;

public class Form : BaseEntity, IRequest<Form>
{
    [BsonRequired]
    public string? RequesterEmail { get; set; }

    [BsonRequired]
    public string? SchoolName { get; set; }

    [BsonRequired]
    public string? SchoolUrl { get; set; }

    [BsonRequired]
    public string? TimetableUrl { get; set; }

    [BsonRequired]
    public DateTime CreatedAt { get; set; }

    [BsonRequired]
    public bool Approved { get; set; }

    [BsonRequired]
    [BsonRepresentation(BsonType.String)]
    public Guid? ApproveAdminId { get; set; }

    [BsonRequired]
    public DateTime? ApprovedAt { get; set; }

    public Form GenerateId()
    {
        Id = Guid.NewGuid();

        return this;
    }

    public Form CreatePublishTime()
    {
        CreatedAt = DateTime.Now;

        return this;
    }

    public Form SetApproveTime()
    {
        ApprovedAt = DateTime.UtcNow;

        return this;
    }
}