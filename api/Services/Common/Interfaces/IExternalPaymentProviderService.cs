using System.Security.Policy;
using api.Models.Entities;

namespace api.Services.Common.Interfaces;

public interface IExternalPaymentProviderService
{
    /// <returns>Redirect URL to provider's payment page</returns>
    public Task<Uri> RequestPayment(Invoice invoice);
}