namespace Vulder.School.Form.Core.Configuration;

public static class Constants
{
    public static readonly string MongoDbConnectionString =
        Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING") ?? string.Empty;
}