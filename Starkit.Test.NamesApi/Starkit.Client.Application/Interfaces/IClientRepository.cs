namespace Starkit.Client.Application.Interfaces;

using Starkit.Client.Domain;
using Starkit.Client.Domain.Entities;
public interface IClientRepository
{
    GenericResponse<Client> GetClients();
}
