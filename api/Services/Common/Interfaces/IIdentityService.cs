using api.Models.Dtos;
using api.Models.Entities;

namespace api.Services.Common.Interfaces;

public interface IIdentityService
{
    public Task CreateAccount(CreateAccountDto createAccountDto);
    public Task RequestSignIn(string email);
    public Task SignIn(string value);
}