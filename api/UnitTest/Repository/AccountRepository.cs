using System;
using System.Threading.Tasks;
using api.Models.Entities;
using api.Repositories;
using api.Repositories.Common.Exceptions;
using api.Repositories.Common.Interfaces;
using Xunit;
using static UnitTest.Repository.Common.RepositoryUtilities;

namespace UnitTest.Repository;

public class AccountRepositoryTests
{
    [Fact]
    public async Task CanGetByEmail()
    {
        // Arrange
        var account = new Account
        {
            Id = Guid.NewGuid(),
            Name = "Sam",
            Email = "test@emai.com"
        };

        var repository = await GetRepository();

        await repository.Insert(account);

        // Act
        var result = await repository.GetByEmail(account.Email);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(result.Id, account.Id);
        Assert.Equal(result.Email, account.Email);
    }

    [Fact]
    public async Task GetByEmailThrowsWhenEntityMissing()
    {
        // Arrange
        var repository = await GetRepository();

        // Act, Assert
        await Assert.ThrowsAsync<EntityNotFoundException<Account>>(
            () => repository.GetByEmail("bad email"));
    }

    private static async Task<IAccountRepository> GetRepository()
        => new AccountRepository(await GetContext());
}