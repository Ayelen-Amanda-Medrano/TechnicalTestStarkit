namespace Starkit.Client.Api;

using Microsoft.OpenApi.Models;
using Starkit.Client.Application;
using Starkit.Client.Application.Options;
using Starkit.Client.Infrastructure;
using System.Text.Json.Serialization;

public static class StartupExtensions
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddApplicationServices()
            .AddInfrastructureServices();
        builder.Services
            .AddControllers()
            .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Client API", Version = "v1" });

            c.IncludeXmlComments("starkit-client-api.xml");
        });

        builder.Services.Configure<JsonFilesOptions>(builder.Configuration.GetSection("JsonFilesOptions"));

        return builder;
    }

    public static WebApplication Configure(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Client API V1");
            c.RoutePrefix = string.Empty;
        });

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}
