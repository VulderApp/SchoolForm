using System.Reflection;
using Autofac;
using MediatR;
using MediatR.Pipeline;
using Vulder.School.Form.Application.Form.SubmitSchoolForm;
using Module = Autofac.Module;

namespace Vulder.School.Form.Application;

public class DefaultApplicationModule : Module
{
    private readonly List<Assembly?> _assemblies = new();

    public DefaultApplicationModule()
    {
        _assemblies.Add(Assembly.GetAssembly(typeof(Core.ProjectAggregate.Form.Form)));
        _assemblies.Add(Assembly.GetAssembly(typeof(SubmitSchoolFormRequestHandler)));
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Mediator>()
            .As<IMediator>()
            .InstancePerLifetimeScope();

        builder.Register<ServiceFactory>(context =>
        {
            var c = context.Resolve<IComponentContext>();
            return t => c.Resolve(t);
        });

        var mediatorOpenTypes = new[]
        {
            typeof(IRequestHandler<,>),
            typeof(IRequestExceptionHandler<,,>),
            typeof(IRequestExceptionHandler<,>),
            typeof(INotificationHandler<>)
        };

        foreach (var mediatorOpenType in mediatorOpenTypes)
            builder.RegisterAssemblyTypes(_assemblies.ToArray()!)
                .AsClosedTypesOf(mediatorOpenType)
                .AsImplementedInterfaces();
    }
}