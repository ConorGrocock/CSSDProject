using api.Models.Entities;

namespace api.Repositories.Common.Interfaces;

public interface IPaymentConfirmationTokenRepository
    : IBaseRepository<PaymentConfirmationToken>, ITokenRepository<PaymentConfirmationToken>
{ }