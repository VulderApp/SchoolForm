using MongoDB.Driver;

namespace Vulder.School.Form.Infrastructure.Database;

public class MongoDbContext
{
    public IMongoCollection<Core.ProjectAggregate.Form.Form> Forms { get; set; }

    public MongoDbContext(string connectionString)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("Vulder");
        database.GetCollection<Core.ProjectAggregate.Form.Form>("Forms");
    }
}