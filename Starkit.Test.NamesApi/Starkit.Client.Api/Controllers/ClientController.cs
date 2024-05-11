using Microsoft.AspNetCore.Mvc;
using Starkit.Client.Api.Contracts.Client;

namespace App.Controllers;

[ApiController]
[Route("/clients")]
public class ClientController : ControllerBase
{
    private readonly ILogger<ClientController> _logger;

    public ClientController(ILogger<ClientController> logger)
    {
        _logger = logger;
    }

    [HttpGet("filters")]
    public IActionResult Get([FromQuery] ClientFilters filters)
    {
        return Ok(filters);
    }
}