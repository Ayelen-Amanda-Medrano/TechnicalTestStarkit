namespace Starkit.Client.Application.Services;

using Starkit.Client.Api.Contracts.Client;
using Starkit.Client.Application.Interfaces;
using Starkit.Client.Domain.Entities;
using Microsoft.Extensions.Logging;
public class ClientService : IClientService
{
    private readonly ILogger<ClientService> _logger;
    private readonly IClientRepository _clientRepository;

    public ClientService(ILogger<ClientService> logger, IClientRepository clientRepository)
    {
        _logger = logger;
        _clientRepository = clientRepository;
    }
    public ClientResponse GetClientsAsync(ClientFilters filters)
    {
        var clients = _clientRepository.GetClients();
        return new ClientResponse();
    }
}
