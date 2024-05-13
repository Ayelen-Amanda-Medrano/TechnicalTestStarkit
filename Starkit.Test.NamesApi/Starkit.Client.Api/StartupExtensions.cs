namespace Starkit.Client.Api;

using Starkit.Client.Application;
using Starkit.Client.Application.Options;
using Starkit.Client.Infrastructure;
public static class StartupExtensions
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddApplicationServices()
            .AddInfrastructureServices();
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();

        builder.Services.Configure<JsonFilesOptions>(builder.Configuration.GetSection("JsonFilesOptions"));

        return builder;
    }

    public static WebApplication Configure(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
            c.RoutePrefix = string.Empty;
        });

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}
