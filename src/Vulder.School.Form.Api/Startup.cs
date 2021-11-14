using Autofac;
using Vulder.School.Form.Infrastructure;

namespace Vulder.School.Form.Api;

public class Startup
{
    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterModule(new DefaultInfrastructureModule());
    }
}