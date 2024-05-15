namespace Starkit.Client.Application.Interfaces;

using Starkit.Client.Api.Contracts.Client;
using Starkit.Client.Domain;
using Starkit.Client.Domain.Entities;

public interface IClientService
{
    GenericResponse<Client> GetClients(ClientFilters filters);
}
