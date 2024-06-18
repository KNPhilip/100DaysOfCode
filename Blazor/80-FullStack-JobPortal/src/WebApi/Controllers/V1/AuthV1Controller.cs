using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers.V1;

public sealed class AuthV1Controller(AuthService authService) : V1ControllerTemplate
{
    private readonly AuthService _authService = authService;

    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginDto request)
    {
        string? response = await _authService.LoginAsync(request);
        if (response is null)
        {
            return BadRequest("Incorrect username or password.");
        }
        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register(RegisterDto request)
    {
        bool response = await _authService.RegisterAsync(request);
        if (response is false)
        {
            return BadRequest();
        }
        return NoContent();
    }
}
