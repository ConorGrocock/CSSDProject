using System.Threading.Tasks;
using Tests.Integration.Common;
using Xunit;
using System.Net;

namespace Tests.Integration;

public class AccountTests : BaseTest
{
    public AccountTests() : base("account") { }

    [Fact]
    public async Task CanCreateAccount()
    {
        // Arrange
        var dto = Faker.CreateAccountDto.Generate();

        // Act
        var response = await _client.PostAsync("", ToStringContent(dto));

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }
}