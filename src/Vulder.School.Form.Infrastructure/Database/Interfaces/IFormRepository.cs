namespace Vulder.School.Form.Infrastructure.Database.Interfaces;

public interface IFormRepository
{
    Task<Core.ProjectAggregate.Form.Form> Create(Core.ProjectAggregate.Form.Form form);
}