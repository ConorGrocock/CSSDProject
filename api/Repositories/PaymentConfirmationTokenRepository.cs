using api.Models.Entities;
using api.Repositories.Common;
using api.Repositories.Common.Interfaces;

namespace api.Repositories;

public class PaymentConfirmationTokenRepository
    : BaseRepository<PaymentConfirmationToken>, IPaymentConfirmationTokenRepository
{
    public PaymentConfirmationTokenRepository(NorTollDbContext norTollDbContext)
        : base(norTollDbContext) { }
}