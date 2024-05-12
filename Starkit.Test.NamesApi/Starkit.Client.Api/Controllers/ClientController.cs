namespace Starkit.Client.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Starkit.Client.Api.Contracts.Client;
using Starkit.Client.Application.Interfaces;

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

    [HttpGet("filters")]
    public IActionResult GetClientsAsync([FromQuery] ClientFilters filters)
    {
        var response = _clientService.GetClientsAsync(filters);

        return Ok(response);
    }
}