using System;
using System.Threading.Tasks;
using api.Models.Entities;
using api.Repositories;
using api.Repositories.Common.Exceptions;
using api.Repositories.Common.Interfaces;
using Xunit;
using static UnitTest.Repository.Common.RepositoryUtilities;


namespace UnitTest.Repository;

public class SignInTokenRepositoryTests
{
    [Fact]
    public async Task CanGetByValue()
    {
        // Arrange
        var signInToken = new SignInToken
        {
            Id = Guid.NewGuid(),
            Value = "token value"
        };

        var repository = await GetRepository();

        await repository.Insert(signInToken);

        // Act
        var result = await repository.GetByValue(signInToken.Value);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(result.Id, signInToken.Id);
        Assert.Equal(result.Value, signInToken.Value);
    }

    [Fact]
    public async Task GetByValueThrowsWhenEntityMissing()
    {
        // Arrange
        var repository = await GetRepository();

        // Act, Assert
        await Assert.ThrowsAsync<EntityNotFoundException<SignInToken>>(
            () => repository.GetByValue("bad value"));
    }

    private static async Task<ISignInTokenRepository> GetRepository()
        => new SignInTokenRepository(await GetContext());
}