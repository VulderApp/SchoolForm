using Autofac;
using AutoMapper;
using Vulder.School.Form.Infrastructure.AutoMapper;
using Vulder.School.Form.Infrastructure.Database;

namespace Vulder.School.Form.Infrastructure;

public class DefaultInfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(_ => new MapperConfiguration(c => { c.AddProfile<AutoMapperProfile>(); }));

        builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

        builder.RegisterModule(new DatabaseModule());
    }
}