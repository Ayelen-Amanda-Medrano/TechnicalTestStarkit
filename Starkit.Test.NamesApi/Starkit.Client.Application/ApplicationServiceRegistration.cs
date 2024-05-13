namespace Starkit.Client.Application;

using Microsoft.Extensions.DependencyInjection;
using Starkit.Client.Application.Interfaces;
using Starkit.Client.Application.Services;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Services
        services.AddTransient<IClientService, ClientService>();

        return services;
    }
}