using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Starkit.Client.Application.Interfaces;
using Starkit.Client.Domain;
using System.Linq.Expressions;
using System.Net;
using Xunit;

namespace Starkit.Client.UnitTests.IntegrationTests;

public class GetClientsTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public GetClientsTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory
            .WithWebHostBuilder(builder =>
            {
                builder
                    .UseEnvironment("Test")
                    .ConfigureAppConfiguration((host, configuration) =>
                    {
                        configuration.Sources.Clear();
                        configuration
                            .SetBasePath(Environment.CurrentDirectory)
                            .AddEnvironmentVariables();
                    })
                    .ConfigureTestServices(services =>
                    {
                        var clientRepository = Substitute.For<IClientRepository>();
                        var expectedResponse = new GenericResponse<Domain.Entities.Client>();
                        clientRepository.GetClients(Arg.Any<Expression<Func<Domain.Entities.Client, bool>>>()).Returns(expectedResponse);

                        services.AddSingleton(clientRepository);
                    });
            });
    }

    [Fact]
    public async Task GetClients_ReturnsOk()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/api/names");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetClients_ReturnsBadRequest()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/api/names?Gender=P");

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
