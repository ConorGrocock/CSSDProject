using System.Threading.Tasks;
using Tests.Integration.Common;
using Xunit;
using System.Net;
using Tests.Integration.Actions;
using static Tests.Integration.Common.Utilities;

namespace Tests.Integration;

public class AccountTests
{
    [Fact]
    public async Task CanCreateAccount()
    {
        var client = CreateApp().CreateClient();

        // Arrange 
        var account = Faker.CreateAccountDto.Generate();

        // Act
        var response = await client.CreateAccount(account);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }
}