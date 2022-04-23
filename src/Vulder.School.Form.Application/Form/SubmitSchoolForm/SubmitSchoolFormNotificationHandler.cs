using MediatR;
using Vulder.School.Form.Core.Utils;
using Vulder.School.Form.Infrastructure.Mailing;

namespace Vulder.School.Form.Application.Form.SubmitSchoolForm;

public class SubmitSchoolFormNotificationHandler : INotificationHandler<Core.ProjectAggregate.Form.Form>
{
    private readonly ISendEmail _sendEmail;

    public SubmitSchoolFormNotificationHandler(ISendEmail sendEmail)
    {
        _sendEmail = sendEmail;
    }

    public async Task Handle(Core.ProjectAggregate.Form.Form notification, CancellationToken cancellationToken)
    {
        var formatters = new Dictionary<string, string>
        {
            {
                "id", notification.Id.ToString()
            }
        };

        var body = await HtmlTemplateUtil.Format(formatters, "Templates/submitForm.html");
        await _sendEmail.Send(notification.RequesterEmail!, $"Zgłoszenie szkoły {notification.SchoolName}", body);
    }
}