using api.Models;
using api.Models.Dtos;
using api.Models.Options;
using api.Services.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : NorTollControllerBase
{
    private readonly IIdentityService _identityService;

    public AuthController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpGet("signIn")]
    public async Task<RedirectResult> SignIn([FromQuery] string token)
    {
        await _identityService.SignIn(token);

        return Redirect(""); // TODO add frontend url
    }

    [HttpPost("signIn")]
    public async Task<OkResult> RequestSignIn([FromQuery] string email)
    {
        await _identityService.RequestSignIn(email);

        return Ok();
    }

    [HttpPost("register")]
    public async Task<CreatedResult> Register(CreateAccountDto dto)
    {
        await _identityService.CreateAccount(dto);

        return Created("", null);
    }
}