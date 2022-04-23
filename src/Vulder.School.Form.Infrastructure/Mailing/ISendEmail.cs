namespace Vulder.School.Form.Infrastructure.Mailing;

public interface ISendEmail
{
    Task Send(string to, string subject, string body);
}