using api.Models.Dtos;
using api.Repositories.Common.Interfaces;
using api.Services.Common.Interfaces;
using api.Services.Common.Validators.Entities;

namespace api.Services;
public class IdentityService : IIdentityService
{
    private readonly IAccountRepository _accountRepository;

    public IdentityService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    public async Task CreateAccount(CreateAccountDto dto)
    {
        var account = dto.AdaptToAccount();

        await new AccountValidator(_accountRepository).ValidateAsync(account);

        await _accountRepository.Insert(account);
        await _accountRepository.Save();
    }
}