using Autofac;
using Vulder.School.Form.Infrastructure.Database.Interfaces;
using Vulder.School.Form.Infrastructure.Database.Repositories;

namespace Vulder.School.Form.Infrastructure.Database;

public class DatabaseModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MongoDbContext>()
            .InstancePerLifetimeScope();

        builder.RegisterType<FormRepository>()
            .As<IFormRepository>()
            .InstancePerLifetimeScope();
    }
}