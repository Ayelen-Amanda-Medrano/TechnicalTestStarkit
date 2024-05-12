namespace Starkit.Client.Application.Services;

using Starkit.Client.Api.Contracts.Client;
using Starkit.Client.Application.Interfaces;
using Microsoft.Extensions.Logging;
using Starkit.Client.Domain.Entities;
using Starkit.Client.Domain;
using System.Linq.Expressions;

public class ClientService : IClientService
{
    private readonly ILogger<ClientService> _logger;
    private readonly IClientRepository _clientRepository;

    public ClientService(ILogger<ClientService> logger, IClientRepository clientRepository)
    {
        _logger = logger;
        _clientRepository = clientRepository;
    }
    public GenericResponse<Client> GetClientsAsync(ClientFilters filters)
    {
        Expression<Func<Client, bool>> defaultFilters = x => true;

        if (filters.Gender != null)
        {
            defaultFilters = CombineFilters(defaultFilters, x => x.Gender == filters.Gender);
        }

        if (filters.Name != null)
        {
            defaultFilters = CombineFilters(defaultFilters, x => x.Name.StartsWith(filters.Name));
        }

        return _clientRepository.GetClients(defaultFilters);

    }

    private Expression<Func<Client, bool>> CombineFilters(Expression<Func<Client, bool>> filter1, Expression<Func<Client, bool>> filter2)
    {
        var parameter = Expression.Parameter(typeof(Client));

        var body = Expression.AndAlso(
            Expression.Invoke(filter1, parameter),
            Expression.Invoke(filter2, parameter)
        );

        return Expression.Lambda<Func<Client, bool>>(body, parameter);
    }
}
