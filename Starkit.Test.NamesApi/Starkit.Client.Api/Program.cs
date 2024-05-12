using Starkit.Client.Application;
using Starkit.Client.Application.Interfaces;
using Starkit.Client.Application.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IClientRepository, ClientRepository>();
ApplicationBootstraper.ConfigureServices(builder.Services, configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    c.RoutePrefix = string.Empty;
});

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();