using api.Models.Dtos;
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

    [HttpPost]
    public async Task<ObjectResult> Post(CreateAccountDto dto)
    {
        await _identityService.CreateAccount(dto);

        return Created("", null);
    }
}