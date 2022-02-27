using api.Models.Dtos;
using api.Models.Entities;
using api.Repositories.Common.Interfaces;
using api.Services.Common.Interfaces;
using api.Services.Common.Validators.Entities;
using Mapster;

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
        var account = dto.Adapt<Account>();

        await new AccountValidator(_accountRepository).ValidateAsync(account);

        await _accountRepository.Insert(account);
        await _accountRepository.Save();
    }
}