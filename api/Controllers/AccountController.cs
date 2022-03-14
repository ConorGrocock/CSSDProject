using api.Models.Dtos;
using api.Services.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class AccountController : NorTollControllerBase
{
    private readonly IIdentityService _identityService;
    public AccountController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost]
    public async Task<ActionResult> Post(CreateAccountDto dto)
    {
        await _identityService.CreateAccount(dto);

        return Created("", null);
    }
}