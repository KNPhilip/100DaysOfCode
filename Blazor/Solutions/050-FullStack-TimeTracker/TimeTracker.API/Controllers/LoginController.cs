using Microsoft.AspNetCore.Mvc;
using TimeTracker.API.Services;
using TimeTracker.Domain.Dtos.Login;

namespace TimeTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class LoginController(ILoginService loginService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginRequestDto request)
        {
            return Ok(await loginService.Login(request));
        }
    }
}
