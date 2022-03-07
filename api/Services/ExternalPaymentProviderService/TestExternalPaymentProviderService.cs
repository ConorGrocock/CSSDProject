using System.Security.Policy;
using api.Models.Entities;
using api.Models.Options;
using api.Repositories.Common.Interfaces;
using api.Services.Common.Interfaces;

namespace api.Services;

public class TestExternalPaymentProviderService : IExternalPaymentProviderService
{
    private readonly IPaymentConfirmationTokenRepository _paymentConfirmationTokenRepository;
    private readonly IDateTimeService _dateTimeService;
    private readonly ILogger _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly PaymentOptions _paymentOptions;

    public TestExternalPaymentProviderService(
        IPaymentConfirmationTokenRepository paymentConfirmationTokenRepository,
        IDateTimeService dateTimeService,
        ILogger<TestExternalPaymentProviderService> logger,
        IHttpContextAccessor httpContextAccessor,
        PaymentOptions paymentOptions)
    {
        _paymentConfirmationTokenRepository = paymentConfirmationTokenRepository;
        _dateTimeService = dateTimeService;
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
        _paymentOptions = paymentOptions;
    }

    public async Task<Uri> RequestPayment(Invoice invoice)
    {
        var token = new PaymentConfirmationToken
        {
            Value = Guid.NewGuid().ToString(),
            Expires = _dateTimeService
                .Now()
                .Add(_paymentOptions.ExternalPaymentProviderRequestExpiry),
            InvoiceId = invoice.Id
        };

        await _paymentConfirmationTokenRepository.Insert(token);

        _logger.LogInformation(token.ToString());

        // redirect to frontend homepage
        return new Uri(_httpContextAccessor.HttpContext?.Request.Headers.Referer);
    }
}