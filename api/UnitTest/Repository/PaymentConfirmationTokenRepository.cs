using System;
using System.Threading.Tasks;
using api.Models.Entities;
using api.Repositories;
using api.Repositories.Common.Exceptions;
using api.Repositories.Common.Interfaces;
using Xunit;
using static UnitTest.Repository.Common.RepositoryUtilities;


namespace UnitTest.Repository;

public class PaymentConfirmationTokenRepositoryTests
{
    [Fact]
    public async Task CanGetByValue()
    {
        // Arrange
        var paymentConfirmationToken = new PaymentConfirmationToken
        {
            Id = Guid.NewGuid(),
            Value = "token value"
        };

        var repository = await GetRepository();

        await repository.Insert(paymentConfirmationToken);

        // Act
        var result = await repository.GetByValue(paymentConfirmationToken.Value);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(result.Id, paymentConfirmationToken.Id);
        Assert.Equal(result.Value, paymentConfirmationToken.Value);
    }

    [Fact]
    public async Task GetByValueThrowsWhenEntityMissing()
    {
        // Arrange
        var repository = await GetRepository();

        // Act, Assert
        await Assert.ThrowsAsync<EntityNotFoundException<PaymentConfirmationToken>>(
            () => repository.GetByValue("bad value"));
    }

    private static async Task<IPaymentConfirmationTokenRepository> GetRepository()
        => new PaymentConfirmationTokenRepository(await GetContext());
}