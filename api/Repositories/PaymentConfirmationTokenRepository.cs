using api.Models.Entities;
using api.Repositories.Common;
using api.Repositories.Common.Exceptions;
using api.Repositories.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class PaymentConfirmationTokenRepository
    : BaseRepository<PaymentConfirmationToken>, IPaymentConfirmationTokenRepository
{
    public PaymentConfirmationTokenRepository(NorTollDbContext norTollDbContext)
        : base(norTollDbContext) { }

    public async Task<PaymentConfirmationToken> GetByValue(
        string value,
         Func<IQueryable<PaymentConfirmationToken>, IQueryable<PaymentConfirmationToken>>? query = null)
    {
        return await
            ApplyQuery(query)
            .SingleOrDefaultAsync(x => x.Value == value)
            ?? throw new EntityNotFoundException<PaymentConfirmationToken>(nameof(SignInToken.Value), value);
    }
}