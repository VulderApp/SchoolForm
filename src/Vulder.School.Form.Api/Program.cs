using Autofac;
using Autofac.Extensions.DependencyInjection;
using Vulder.School.Form.Application;
using Vulder.School.Form.Infrastructure;
using Vulder.SharedKernel;
using NLog.Web;
using Vulder.SharedKernel.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDefaultJwtConfiguration(builder.Configuration);
builder.Services.AddSwaggerGen();
builder.Services.AddValidators();
builder.Services.AddDefaultCorsPolicy();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(containerBuilder =>
{
    containerBuilder.RegisterModule(new DefaultInfrastructureModule());
    containerBuilder.RegisterModule(new DefaultApplicationModule());
}));
builder.Host.UseNLog();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.UseMiddleware<ControllerActionLoggingMiddleware>();

app.UseCors("CORS");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
}