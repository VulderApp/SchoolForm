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
        await Forms.InsertOneAsync(form);

        return form;
    }
}