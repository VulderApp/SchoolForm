using MongoDB.Driver;
using Vulder.School.Form.Infrastructure.Database.Interfaces;

namespace Vulder.School.Form.Infrastructure.Database.Repositories;

public class FormRepository : IFormRepository
{
    public FormRepository(MongoDbContext context)
    {
        Forms = context.Forms;
    }

    private IMongoCollection<Core.ProjectAggregate.Form.Form>? Forms { get; set; }

    public async Task<Core.ProjectAggregate.Form.Form> Create(Core.ProjectAggregate.Form.Form form)
    {
        await Forms!.InsertOneAsync(form);

        return form;
    }

    public async Task<Core.ProjectAggregate.Form.Form> GetById(Guid id)
    {
        return await Forms!.Find(x => x.Id == id).FirstAsync();
    }

    public Task<List<Core.ProjectAggregate.Form.Form>> GetFormList(int page)
    {
        var forms = Forms!.AsQueryable()
            .OrderByDescending(x => x.CreatedAt)
            .Skip((page - 1) * 20)
            .ToList();

        return Task.FromResult(forms);
    }

    public async Task Update(Core.ProjectAggregate.Form.Form form)
    {
        await Forms!.ReplaceOneAsync(x => x.Id == form.Id, form);
    }
}