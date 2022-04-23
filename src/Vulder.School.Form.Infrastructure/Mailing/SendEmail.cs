using SendGrid;
using SendGrid.Helpers.Mail;

namespace Vulder.School.Form.Infrastructure.Mailing;

public class SendEmail : ISendEmail
{
    public SendEmail(MailContext context)
    {
        Client = context.Client;
        Address = context.Address;
    }

    private SendGridClient Client { get; }
    private EmailAddress Address { get; }

    public async Task Send(string to, string subject, string body)
    {
        var mail = new SendGridMessage
        {
            From = Address,
            Subject = subject,
            HtmlContent = body
        };
        mail.AddTo(new EmailAddress(to));

        await Client.SendEmailAsync(mail).ConfigureAwait(false);
    }
}