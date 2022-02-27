using api.Models.Dtos;

namespace api.Services.Common.Interfaces;

public interface IIdentityService
{
    public Task CreateAccount(CreateAccountDto createAccountDto);
}