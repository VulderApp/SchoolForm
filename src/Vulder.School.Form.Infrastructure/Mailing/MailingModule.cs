using Autofac;

namespace Vulder.School.Form.Infrastructure.Mailing;

public class MailingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MailContext>()
            .InstancePerLifetimeScope();

        builder.RegisterType<SendEmail>()
            .As<ISendEmail>()
            .InstancePerLifetimeScope();
    }
}