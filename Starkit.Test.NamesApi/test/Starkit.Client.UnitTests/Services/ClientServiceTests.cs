namespace Starkit.Client.UnitTests.Services;

using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Starkit.Client.Api.Contracts.Client;
using Starkit.Client.Application.Interfaces;
using Starkit.Client.Application.Services;
using Starkit.Client.Domain;
using Starkit.Client.Domain.Entities;
using System.Linq.Expressions;
using Xunit;

public class ClientServiceTests
{
    private readonly ILogger<ClientService> _logger;
    private readonly IClientRepository _clientRepository;
    private readonly ClientService _clientService;

    public ClientServiceTests()
    {
        _logger = Substitute.For<ILogger<ClientService>>();
        _clientRepository = Substitute.For<IClientRepository>();
        _clientService = new ClientService(_logger, _clientRepository);
    }

    [Fact]
    public void GetClients_WhenOKCallClientDatabase_ReturnClients()
    {
        // Arrange
        _clientRepository.GetClients(Arg.Any<Expression<Func<Client, bool>>>()).Returns(new GenericResponse<Client>());

        // Act
        var result = _clientService.GetClients(new ClientFilters());

        // Assert
        result.Should().NotBeNull().And.BeOfType<GenericResponse<Client>>();
    }
}
