namespace api.Models.Common;

public interface IToken
{
    public string Value { get; set; }
    public DateTime Expires { get; set; }
}