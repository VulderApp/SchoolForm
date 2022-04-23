using SendGrid;
using SendGrid.Helpers.Mail;
using Vulder.School.Form.Core;

namespace Vulder.School.Form.Infrastructure.Mailing;

public class MailContext
{
    public MailContext()
    {
        Client = new SendGridClient(Constants.SendGridApiKey);
        Address = new EmailAddress(Constants.SendGridEmail, "Vulder Bot");
    }

    public SendGridClient Client { get; }
    public EmailAddress Address { get; }
}