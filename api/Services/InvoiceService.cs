using api.Models.Entities;
using api.Models.Enums;
using api.Models.Dtos;
using api.Models.Exceptions;
using api.Repositories.Common.Interfaces;
using api.Services.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Services;

public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IExternalPaymentProviderService _externalPaymentProviderService;
    private readonly IDateTimeService _dateTimeService;
    private readonly IIdentityService _identityService;
    private readonly IAccountRepository _accountRepository;
    private readonly IPaymentConfirmationTokenRepository _paymentConfirmationTokenRepository;

    public InvoiceService(
        IIdentityService identityService,
        IExternalPaymentProviderService externalPaymentProviderService,
        IDateTimeService dateTimeService,
        IAccountRepository accountRepository,
        IInvoiceRepository invoiceRepository,
        IPaymentConfirmationTokenRepository paymentConfirmationTokenRepository)
    {
        _identityService = identityService;
        _externalPaymentProviderService = externalPaymentProviderService;
        _dateTimeService = dateTimeService;
        _accountRepository = accountRepository;
        _invoiceRepository = invoiceRepository;
        _paymentConfirmationTokenRepository = paymentConfirmationTokenRepository;
    }

    public async Task<ViewInvoiceDto[]> GetInvoices()
    {
        var invoices = await _invoiceRepository.GetAll(x => x
            .Include(x => x.Account)
            .Include(x => x.Bills));

        var currentUser = await _accountRepository.Get(_identityService.GetCurrentAccountId());

        if (currentUser.Role != Role.TollOperator)
        {
            invoices = invoices.Where(x => x.AccountId == currentUser.Id);
        }

        return await invoices.Select(x => x.AdaptToViewDto()).ToArrayAsync();
    }

    public async Task<Uri> Pay(Guid invoiceId)
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

    public async Task ConfirmPayment(string tokenValue)
    {
        var token = await _paymentConfirmationTokenRepository.GetByValue(
            tokenValue,
            x => x.Include(x => x.Invoice));
        await _paymentConfirmationTokenRepository.Delete(token.Id);

        var now = _dateTimeService.Now();

        if (token.Expires < now) { return; }

        var invoice = token.Invoice;

        invoice.PaymentConfirmationId = Guid.NewGuid();
        invoice.PaymentConfirmation = new PaymentConfirmation
        {
            Id = invoice.PaymentConfirmationId.Value,
            Method = PaymentMethod.Portal,
            PaidAt = now,
            Identifier = Guid.NewGuid().ToString()
        };

        await _invoiceRepository.Update(invoice);
    }

    public async Task<ViewInvoiceDto> GetInvoice(Guid invoiceId)
    {
        var invoice = await _invoiceRepository.Get(invoiceId, x => x
            .Include(x => x.Account)
            .Include(x => x.Bills));

        var currentUser = await _accountRepository.Get(_identityService.GetCurrentAccountId());

        if (currentUser.Role == Role.TollOperator)
        {
            return invoice.AdaptToViewDto();
        }

        if (currentUser.Id != invoice.AccountId)
        {
            throw new AuthorizationException("Cannot view another user's Invoice");
        }

        return invoice.AdaptToViewDto();
    }
}