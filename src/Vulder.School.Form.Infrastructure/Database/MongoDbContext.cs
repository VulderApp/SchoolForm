using MongoDB.Driver;
using Vulder.School.Form.Core.Configuration;

namespace Vulder.School.Form.Infrastructure.Database;

public class MongoDbContext
{
    public MongoDbContext()
    {
        var client = new MongoClient(Constants.MongoDbConnectionString);
        var database = client.GetDatabase("Vulder");
        Forms = database.GetCollection<Core.ProjectAggregate.Form.Form>("Forms");
    }

    public IMongoCollection<Core.ProjectAggregate.Form.Form>? Forms { get; set; }
}