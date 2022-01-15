namespace Vulder.School.Form.Infrastructure.Database.Interfaces;

public interface IFormRepository
{
    Task<Core.ProjectAggregate.Form.Form> Create(Core.ProjectAggregate.Form.Form form);
    Task<Core.ProjectAggregate.Form.Form> GetById(Guid id);
    Task<List<Core.ProjectAggregate.Form.Form>> GetFormList(int page);
    Task Update(Core.ProjectAggregate.Form.Form form);
}