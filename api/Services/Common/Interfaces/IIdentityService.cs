using api.Models.Dtos;

namespace api.Services.Common.Interfaces;

public interface IIdentityService
{
    public Task CreateAccount(CreateAccountDto createAccountDto);
    public Task RequestSignIn(string email);
    public Task<string> SignIn(string value);
    public int GetCurrentAccountId();
}