namespace Starkit.Client.Infrastructure;

using Microsoft.Extensions.DependencyInjection;
using Starkit.Client.Application.Interfaces;
using Starkit.Client.Infraestructure.Repositories;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        => services.AddPersistenceServices();

    private static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddScoped<IClientRepository, ClientRepository>();

        return services;
    }
}
