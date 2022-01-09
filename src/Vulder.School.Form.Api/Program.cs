using Autofac;
using Autofac.Extensions.DependencyInjection;
using Vulder.School.Form.Application;
using Vulder.School.Form.Infrastructure;
using Vulder.SharedKernel;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(containerBuilder =>
{
    containerBuilder.RegisterModule(new DefaultInfrastructureModule());
    containerBuilder.RegisterModule(new DefaultApplicationModule());
}));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDefaultJwtConfiguration(builder.Configuration);
builder.Services.AddSwaggerGen();
builder.Services.AddValidators();
builder.Services.AddDefaultCorsPolicy();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }