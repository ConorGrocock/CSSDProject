using api.Models;
using api.Models.Dtos;
using api.Models.Entities;
using api.Models.Exceptions;
using api.Models.Options;
using api.Repositories.Common.Interfaces;
using api.Services.Common.Interfaces;
using api.Services.Common.Validators.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FluentValidation;

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

        var signInUrl = string.Format(_authenticationOptions.SignInUrlFormat, signInToken.Value);

        _emailService.Send(new EmailItem
        {
            To = email,
            Message = $"Click here to sign in to your NorToll account: {signInUrl}"
        });
    }

    public async Task<string> SignIn(string value)
    {
        var signInToken = await _signInRepository.GetByValue(value, x => x.Include(x => x.Account));
        await _signInRepository.Delete(signInToken.Id);

        if (signInToken.Expires < _dateTimeService.Now())
        {
            throw new AuthenticationException("Sign-in token has expired");
        }

        // https://datatracker.ietf.org/doc/html/rfc7519#section-4.1
        // https://www.iana.org/assignments/jwt/jwt.xhtml
        var claims = new[]
        {
            new Claim("sub", signInToken.Account.Id.ToString()),
            new Claim("name", signInToken.Account.Name)
        };

        var signingCredentials = new SigningCredentials(_authenticationOptions.JwtSecretKey, SecurityAlgorithms.HmacSha256);

        var jwt = new JwtSecurityToken(
            issuer: _authenticationOptions.JwtIssuer,
            audience: _authenticationOptions.JwtAudience,
            expires: _dateTimeService.Now().Add(_authenticationOptions.JwtExpiry),
            claims: claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    public async Task CreateAccount(CreateAccountDto dto)
    {
        var account = dto.AdaptToAccount();

        await new AccountValidator(_accountRepository).ValidateAndThrowAsync(account);

        await _accountRepository.Insert(account);
    }
}