using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.API.Services;
using TimeTracker.Domain.Dtos.Account;

namespace TimeTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAccountService accountService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<AccountRegistrationResponseDto>> 
            Register(AccountRegistrationRequestDto request)
        {
            return Ok(await accountService.RegisterAsync(request));
        }

        [HttpPost("role")]
        public async Task<IActionResult> AssignRole(string userName, string roleName)
        {
            await accountService.AssignRole(userName, roleName);
            return NoContent();
        }
    }
}
