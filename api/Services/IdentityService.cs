using api.Models;
using api.Models.Dtos;
using api.Models.Entities;
using api.Models.Exceptions;
using api.Models.Options;
using api.Repositories.Common.Interfaces;
using api.Services.Common.Interfaces;
using api.Services.Common.Validators.Entities;

namespace api.Services;
public class IdentityService : IIdentityService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ISignInTokenRepository _signInRepository;
    private readonly IEmailService _emailService;
    private readonly IDateTimeService _dateTimeService;
    private readonly AuthenticationOptions _authenticationOptions;

    public IdentityService(
        IAccountRepository accountRepository,
        ISignInTokenRepository signInRepository,
        IEmailService emailService,
        IDateTimeService dateTimeService,
        AuthenticationOptions authenticationOptions)
    {
        _accountRepository = accountRepository;
        _signInRepository = signInRepository;
        _emailService = emailService;
        _dateTimeService = dateTimeService;
        _authenticationOptions = authenticationOptions;
    }

    public async Task RequestSignIn(string email)
    {
        var account = await _accountRepository.GetByEmail(email);

        var signInToken = new SignInToken
        {
            Value = Guid.NewGuid().ToString(),
            Expires = _dateTimeService.Now().Add(_authenticationOptions.SignInTokenExpiry),
            AccountId = account.Id
        };

        await _signInRepository.Insert(signInToken);
        await _signInRepository.Save();

        var signInUrl = $"{_authenticationOptions.SignInUrl}?token={signInToken.Value}";

        _emailService.Send(new EmailItem
        {
            To = email,
            Message = $"Click here to sign in to your NorToll account: {signInUrl}"
        });
    }

    public async Task SignIn(string value)
    {
        var signInToken = await _signInRepository.GetByValue(value);

        if (signInToken.Expires < _dateTimeService.Now())
        {
            throw new AuthenticationException("Sign-in token has expired");
        }

        // TODO generate JWT
    }

    public async Task CreateAccount(CreateAccountDto dto)
    {
        var account = dto.AdaptToAccount();

        await new AccountValidator(_accountRepository).ValidateAsync(account);

        await _accountRepository.Insert(account);
        await _accountRepository.Save();
    }
}