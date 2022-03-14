namespace api.Models.Options;

public class PaymentOptions
{
    public TimeSpan ExternalPaymentProviderRequestExpiry { get; set; }
    public string ExternalPaymentProviderUrlFormat { get; set; } = default!;
}