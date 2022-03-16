using System.Threading.Tasks;
using Tests.Integration.Common;
using Xunit;
using System.Net;
using Tests.Integration.Actions;
using static Tests.Integration.Common.Utilities;
using Microsoft.Extensions.DependencyInjection;
using api.Services.Common.Interfaces;
using Tests.Integration.Services;
using System.Linq;

namespace Tests.Integration;

public class AuthTests
{
    [Fact]
    public async Task CanRequestAuthentication()
    {
        var app = CreateApp();
        var client = app.CreateClient();

        // Arrange 
        var account = Faker.CreateAccountDto.Generate();
        await client.CreateAccount(account);

        // Act
        var response = await client.RequestAuthentication(account.Email);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        using var scope = app.Services.CreateAsyncScope();
        var emailService = (IntegrationEmailService)scope.ServiceProvider.GetRequiredService<IEmailService>();

        Assert.Single(emailService.EmailItems);
        Assert.Single(emailService.EmailItems, x => x.To == account.Email);
    }

    [Fact]
    public async Task CanVerifyAuthentication()
    {
        var app = CreateApp();
        var client = app.CreateClient();

        // Arrange 
        var account = Faker.CreateAccountDto.Generate();
        await client.CreateAccount(account);
        await client.RequestAuthentication(account.Email);

        using var scope = app.Services.CreateAsyncScope();
        var emailService = (IntegrationEmailService)scope.ServiceProvider.GetRequiredService<IEmailService>();

        var token = emailService
            .EmailItems
            .Single(x => x.To == account.Email)
            .Message[^36..];

        // Act
        var (response, tokenDto) = await client.VerifyAuthentication(token);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(tokenDto);
        Assert.NotNull(tokenDto!.Token);
        Assert.NotEmpty(tokenDto!.Token);
    }
}