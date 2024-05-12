namespace Starkit.Client.Application.Interfaces;
using Starkit.Client.Api.Contracts.Client;

public interface IClientService
{
    ClientResponse GetClientsAsync(ClientFilters filters);
}
