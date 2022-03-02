using api.Models.Dtos;
using api.Models.Options;
using api.Services.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class AuthController : NorTollControllerBase
{
    private readonly IIdentityService _identityService;
    private readonly AuthenticationOptions _authenticationOptions;

    public AuthController(
        IIdentityService identityService,
        AuthenticationOptions authenticationOptions)
    {
        _identityService = identityService;
        _authenticationOptions = authenticationOptions;
    }

    [HttpPost("request")]
    public async Task<ActionResult> RequestSignIn([FromQuery] string email)
    {
        await _identityService.RequestSignIn(email);

        return Ok();
    }

    [HttpPost("verify")]
    public async Task<ActionResult> SignIn([FromQuery] string token)
    {
        var authToken = await _identityService.SignIn(token);

        var response = new TokenDto { Token = authToken };

        return Ok(response);
    }
}