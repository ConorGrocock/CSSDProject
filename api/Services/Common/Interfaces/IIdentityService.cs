using api.Models.Dtos;
using api.Models.Enums;

namespace api.Services.Common.Interfaces;

public interface IIdentityService
{
    public Task CreateAccount(CreateAccountDto createAccountDto);
    public Task RequestSignIn(string email);
    public Task<string> SignIn(string value);
    public Guid GetCurrentAccountId();
    public bool IsInRole(Role role);
}