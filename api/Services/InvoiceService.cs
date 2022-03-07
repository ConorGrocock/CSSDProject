using api.Models.Entities;
using api.Models.Exceptions;
using api.Repositories.Common.Interfaces;
using api.Services.Common.Interfaces;
using System.Security.Policy;

namespace api.Services;

public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IExternalPaymentProviderService _externalPaymentProviderService;
    private readonly IIdentityService _identityService;
    private readonly IAccountRepository _accountRepository;

    public InvoiceService(
        IIdentityService identityService,
        IExternalPaymentProviderService externalPaymentProviderService,
        IAccountRepository accountRepository,
        IInvoiceRepository invoiceRepository)
    {
        _identityService = identityService;
        _externalPaymentProviderService = externalPaymentProviderService;
        _accountRepository = accountRepository;
        _invoiceRepository = invoiceRepository;
    }

    public async Task<Invoice[]> GetInvoices()
    {
        return (await _invoiceRepository.GetAll()).ToArray();
    }

    public async Task<Uri> Pay(int invoiceId)
    {
        var invoice = await _invoiceRepository.Get(invoiceId);

        if (invoice.PaymentConfirmationId.HasValue)
        {
            throw new AuthorizationException("Cannot pay an Invoice which has already been paid");
        }

        var currentAccountId = _identityService.GetCurrentAccountId();

        if (invoice.AccountId != currentAccountId)
        {
            throw new AuthorizationException($"Cannot pay an Invoice ({invoiceId}) issued to another Account");
        }

        return await _externalPaymentProviderService.RequestPayment(invoice);
    }
}