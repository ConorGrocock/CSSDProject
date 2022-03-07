using System.Text;
using api.Models.Common;

namespace api.Models.Entities;

public class PaymentConfirmationToken : BaseEntity, IToken
{
    public string Value { get; set; } = default!;
    public DateTime Expires { get; set; }

    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; } = default!;

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Value: {Value}");
        sb.AppendLine($"Expires: {Expires}");
        sb.AppendLine($"Invoice Id {InvoiceId}");

        return sb.ToString();
    }
}