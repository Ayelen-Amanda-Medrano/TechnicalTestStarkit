namespace Starkit.Client.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Starkit.Client.Api.Contracts.Client;
using Starkit.Client.Application.Interfaces;
using Starkit.Client.Domain;
using Starkit.Client.Domain.Entities;
using System.Net;

[ApiController]
[Route("/clients")]
public class ClientController : ControllerBase
{
    private readonly ILogger<ClientController> _logger;
    private readonly IClientService _clientService;

    public ClientController(ILogger<ClientController> logger, IClientService clientService)
    {
        _logger = logger;
        _clientService = clientService;
    }

    [HttpGet("filter")]
    [ProducesResponseType(typeof(GenericResponse<Client>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public IActionResult GetClientsAsync([FromQuery] ClientFilters filters)
    {
        _logger.LogInformation("Calling to service");

        var response = _clientService.GetClientsAsync(filters);

        return Ok(response);
    }
}