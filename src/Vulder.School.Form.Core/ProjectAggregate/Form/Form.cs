using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Vulder.SharedKernel;

namespace Vulder.School.Form.Core.ProjectAggregate.Form;

public class Form : BaseEntity, IRequest<Form>
{
    [BsonRequired] public string? RequesterEmail { get; set; }

    [BsonRequired] public string? SchoolName { get; set; }

    [BsonRequired] public string? SchoolUrl { get; set; }

    [BsonRequired] public string? TimetableUrl { get; set; }

    [BsonRequired] public DateTime CreatedAt { get; set; }

    [BsonRequired] public Status Status { get; set; } = Status.None;

    [BsonRequired]
    [BsonRepresentation(BsonType.String)]
    public Guid? ApproveAdminId { get; set; }

    [BsonRequired]
    [BsonRepresentation(BsonType.String)]
    public Guid? RefusedAdminId { get; set; }

    [BsonRequired] public DateTime? ApprovedAt { get; set; }

    [BsonRequired] public DateTime? RefusedAt { get; set; }

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
        Status = Status.Approved;
        ApprovedAt = DateTime.UtcNow;

        return this;
    }

    public Form SetRefuse(Guid adminId)
    {
        Status = Status.Refused;
        RefusedAdminId = adminId;
        RefusedAt = DateTime.UtcNow;

        return this;
    }
}