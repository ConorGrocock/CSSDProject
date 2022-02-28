namespace api.Models.Options;

public class AuthenticationOptions
{
    public TimeSpan SignInTokenExpiry { get; set; }
    public string SignInUrl { get; set; } = default!;
}