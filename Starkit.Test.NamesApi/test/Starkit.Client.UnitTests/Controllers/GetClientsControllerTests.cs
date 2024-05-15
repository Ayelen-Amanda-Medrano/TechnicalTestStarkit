namespace Starkit.Client.UnitTests.Controllers;

using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Starkit.Client.Api.Contracts.Client;
using Starkit.Client.Api.Controllers;
using Starkit.Client.Application.Interfaces;
using Starkit.Client.Domain;
using Starkit.Client.Domain.Entities;
using Xunit;

public class GetClientsControllerTests
{
    private readonly ILogger<ClientController> _logger;
    private readonly IClientService _clientService;
    private readonly ClientController _controller;

    public GetClientsControllerTests()
    {
        _logger = Substitute.For<ILogger<ClientController>>();
        _clientService = Substitute.For<IClientService>();
        _controller =  new ClientController(_logger, _clientService);
    }

    [Fact]
    public void GetClients_WhenValidRequest_ReturnsOk()
    {
        // Arrange
        var response = new GenericResponse<Client>
        {
            Response = new Client[0],
        };

        _clientService.GetClients(Arg.Any<ClientFilters>()).Returns(response);

        // Act
        var result = _controller.GetClients(new ClientFilters());

        // Assert
        result.Should()
              .NotBeNull()
              .And.BeOfType<OkObjectResult>()
              .And.Match<OkObjectResult>((x) => x.StatusCode == StatusCodes.Status200OK && x.Value != null);
    }
}
