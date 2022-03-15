using System.Threading.Tasks;
using Tests.Integration.Common;
using Xunit;
using System.Net;
using Tests.Integration.Actions;

namespace Tests.Integration;

public class AccountTests : BaseTest
{
    [Fact]
    public async Task CanCreateAccount()
    {
        // Arrange 
        var account = Faker.CreateAccountDto.Generate();

        // Arrange, Act
        var response = await _client.CreateAccount(account);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }
}