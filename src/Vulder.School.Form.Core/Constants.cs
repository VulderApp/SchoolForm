namespace Vulder.School.Form.Core;

public static class Constants
{
    public static readonly string MongoDbConnectionString =
        Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING") ?? string.Empty;

    public static readonly bool UseSendGrid =
        bool.Parse(Environment.GetEnvironmentVariable("USE_SENDGRID") ?? "false");

    public static readonly string SendGridApiKey =
        Environment.GetEnvironmentVariable("SENDGRID_API_KEY") ?? string.Empty;

    public static readonly string SendGridEmail =
        Environment.GetEnvironmentVariable("SENDGRID_EMAIL") ?? string.Empty;
}