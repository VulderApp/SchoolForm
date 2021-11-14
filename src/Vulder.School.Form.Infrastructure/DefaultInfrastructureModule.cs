using System.Reflection;
using Autofac;
using Vulder.School.Form.Infrastructure.Database;
using Module = Autofac.Module;

namespace Vulder.School.Form.Infrastructure;

public class DefaultInfrastructureModule : Module
{
    private List<Assembly> _assemblies = new ();

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule(new DatabaseModule());
    }
}