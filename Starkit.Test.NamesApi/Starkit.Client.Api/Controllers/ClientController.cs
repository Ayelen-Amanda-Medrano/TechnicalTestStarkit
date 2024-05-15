namespace Starkit.Client.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Starkit.Client.Api.Contracts.Client;
using Starkit.Client.Application.Interfaces;
using Starkit.Client.Domain;
using Starkit.Client.Domain.Entities;

[ApiController]
[Route("/api/names")]
public class ClientController : ControllerBase
{
    private readonly ILogger<ClientController> _logger;
    private readonly IClientService _clientService;

    public ClientController(ILogger<ClientController> logger, IClientService clientService)
    {
        _logger = logger;
        _clientService = clientService;
    }

    [HttpGet]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<Client>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetClientsAsync([FromQuery] ClientFilters filters)
    {
        _logger.LogInformation("Calling to clients service");

        var response = _clientService.GetClientsAsync(filters);

        return Ok(response);
    }
}