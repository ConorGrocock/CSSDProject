using System.Text;

namespace api.Models;
public class EmailItem
{
    public string From { get; set; } = default!;
    public string To { get; set; } = default!;
    public string Message { get; set; } = default!;

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"From: {From}");
        sb.AppendLine($"To: {To}");
        sb.AppendLine($"Message: {Message}");

        return sb.ToString();
    }
}
