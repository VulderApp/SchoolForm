using MediatR;
using Vulder.School.Form.Core.Models;
using Vulder.School.Form.Core.Utils;
using Vulder.School.Form.Infrastructure.Database.Interfaces;
using Vulder.School.Form.Infrastructure.Mailing;

namespace Vulder.School.Form.Application.Form.RefuseSchoolForm;

public class RefuseSchoolFormNotificationHandler : INotificationHandler<RefuseSchoolFormModel>
{
    private readonly IFormRepository _formRepository;
    private readonly ISendEmail _sendEmail;

    public RefuseSchoolFormNotificationHandler(ISendEmail sendEmail, IFormRepository formRepository)
    {
        _sendEmail = sendEmail;
        _formRepository = formRepository;
    }

    public async Task Handle(RefuseSchoolFormModel notification, CancellationToken cancellationToken)
    {
        var form = await _formRepository.GetById(notification.FormId);
        var formatters = new Dictionary<string, string>
        {
            {
                "schoolName", form.SchoolName!
            }
        };

        var body = await HtmlTemplateUtil.Format(formatters, "Templates/refuseForm.html");
        await _sendEmail.Send(form.RequesterEmail!, "Odrzucenie zgłoszenia", body);
    }
}