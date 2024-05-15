namespace Starkit.Client.Application.Services;

using Starkit.Client.Api.Contracts.Client;
using Starkit.Client.Application.Interfaces;
using Microsoft.Extensions.Logging;
using Starkit.Client.Domain.Entities;
using Starkit.Client.Domain;
using System.Linq.Expressions;
using Starkit.Client.Application.Exceptions;
using System.Net;

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
        try
        {
            Expression<Func<Client, bool>> filter = BuildFilter(filters);
            return _clientRepository.GetClients(filter);
        }
        catch(Exception ex)
        {
            var errorMessage = "Error getting clients.";
            var error = $"Error: {errorMessage} - Exception message: {ex.Message}";

            _logger.LogError(error);
            throw new ServiceException(HttpStatusCode.InternalServerError, error);
        }
    }

    private static Expression<Func<Client, bool>> BuildFilter(ClientFilters filters)
    {
        Expression<Func<Client, bool>> filter = x => true;

        if (filters.Gender != null)
        {
            filter = CombineFilters(filter, x => x.Gender == filters.Gender.ToString());
        }

        if (filters.Name != null)
        {
            filter = CombineFilters(filter, x => x.Name.StartsWith(filters.Name));
        }

        return filter;
    }

    private static Expression<Func<Client, bool>> CombineFilters(Expression<Func<Client, bool>> filter1, Expression<Func<Client, bool>> filter2)
    {
        var parameter = Expression.Parameter(typeof(Client));

        var body = Expression.AndAlso(
            Expression.Invoke(filter1, parameter),
            Expression.Invoke(filter2, parameter)
        );

        return Expression.Lambda<Func<Client, bool>>(body, parameter);
    }
}
