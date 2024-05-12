namespace Starkit.Client.Application.Interfaces;

using Starkit.Client.Api.Contracts.Client;
using Starkit.Client.Domain;
using Starkit.Client.Domain.Entities;
using System.Linq.Expressions;

public interface IClientRepository
{
    GenericResponse<Client> GetClients(Expression<Func<Client, bool>> filterExpression);
}
