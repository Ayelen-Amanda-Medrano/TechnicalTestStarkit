namespace Starkit.Client.Application;

using Starkit.Client.Application.Interfaces;
using Starkit.Client.Application.Options;
using Starkit.Client.Application.Services;

public class ApplicationBootstraper
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        // Services
        services.AddTransient<IClientService, ClientService>();

        // Options
        services.Configure<JsonFilesOptions>(configuration.GetSection("JsonFilesOptions"));
    }
}
