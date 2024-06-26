﻿namespace Starkit.Client.Infraestructure.Repositories;

using Microsoft.Extensions.Options;
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
        string jsonData = File.ReadAllText(_jsonFilesOptions.Value.Clients);
        var jsonSerializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var clients = JsonSerializer.Deserialize<GenericResponse<Client>>(jsonData, jsonSerializerOptions);

        var clientsFiltered = clients!.Response.AsQueryable().Where(filterExpression).ToArray();

        return new GenericResponse<Client>()
        {
            Response = clientsFiltered,
        };
    }
}