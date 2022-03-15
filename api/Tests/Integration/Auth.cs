using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using api.Controllers;
using api.Services.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Tests.Integration.Actions;
using Tests.Integration.Common;
using Tests.Integration.Services;
using Xunit;
using static Tests.Integration.Common.Utilities;

namespace Tests.Integration;

public class AuthTests : BaseTest
{
    private string Endpoint { get; }

    public AuthTests()
    {
        Endpoint = Endpoint<AuthController>();
    }

    [Fact]
    public async Task CanRequestAuthentication()
    {
        // Arrange
        using var scope = _serviceProvider.CreateScope();
        var emailService = (IntegrationEmailService)scope.ServiceProvider.GetRequiredService<IEmailService>();

        var account = Faker.CreateAccountDto.Generate();
        await _client.CreateAccount(account);

        // Act
        var response = await _client.RequestAuthentication(account.Email);
        var emailItem = emailService.EmailItems.SingleOrDefault(x => x.To == account.Email);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(emailItem);
    }

    [Fact]
    public async Task CanVerifyAuthentication()
    {
        // Arrange
        using var scope = _serviceProvider.CreateScope();
        var emailService = (IntegrationEmailService)scope.ServiceProvider.GetRequiredService<IEmailService>();

        var account = Faker.CreateAccountDto.Generate();
        await _client.CreateAccount(account);
        await _client.RequestAuthentication(account.Email);

        Console.WriteLine("what");
        Console.WriteLine(emailService.EmailItems);

        var token = emailService.EmailItems
            .Single(x => x.To == account.Email)
            .Message[^36..]; // trailing GUID

        // Act
        var (response, tokenDto) = await _client.VerifyAuthentication(token);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(tokenDto);
        Assert.NotNull(tokenDto!.Token);
        Assert.NotEmpty(tokenDto!.Token);
    }
}