namespace Starkit.Client.Application.Repositories;

using Microsoft.Extensions.Options;
using Starkit.Client.Api.Contracts.Client;
using Starkit.Client.Application.Interfaces;
using Starkit.Client.Application.Options;
using Starkit.Client.Domain;
using Starkit.Client.Domain.Entities;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;

public class ClientRepository : IClientRepository
{
    private readonly IOptions<JsonFilesOptions> _jsonFilesOptions;
    public ClientRepository(IOptions<JsonFilesOptions> jsonFilesOptions)
    {
        _jsonFilesOptions = jsonFilesOptions;
    }

    public GenericResponse<Client> GetClients(Expression<Func<Client, bool>> filterExpression)
    {
        string jsonData = File.ReadAllText(_jsonFilesOptions.Value.Names);

        var clients = JsonSerializer.Deserialize<GenericResponse<Client>>(jsonData, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

        var clientsFiltered = clients!.Response.AsQueryable().Where(filterExpression).ToArray();

        return new GenericResponse<Client>()
        {
            Response = clientsFiltered,
        };
    }
}