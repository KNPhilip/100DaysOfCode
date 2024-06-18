using ErrorOr;
using Interactors.User;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1;

public sealed class UserV1Controller(UserInteractor userInteractor) : V1ControllerTemplate
{
    private readonly UserInteractor _userInteractor = userInteractor;

    [HttpGet]
    public async Task<ActionResult<List<Domain.Models.User>>> GetAllUsersAsync()
    {
        return await _userInteractor.GetAllUsersAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Domain.Models.User>> GetUserByIdAsync(int id)
    {
        ErrorOr<Domain.Models.User> user = await _userInteractor.GetUserByIdAsync(id);
        if (user.IsError)
        {
            return NotFound(user.Errors.FirstOrDefault());
        }
        return Ok(user.Value);
    }

    [HttpPost]
    public async Task<ActionResult> CreateUserAsync(Domain.Models.User user)
    {
        ErrorOr<bool> result = await _userInteractor.CreateUserAsync(user);
        if (result.IsError)
        {
            return BadRequest(result.Errors.FirstOrDefault());
        }
        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateUserAsync(Domain.Models.User user)
    {
        ErrorOr<bool> result = await _userInteractor.UpdateUserByIdAsync(user);
        if (result.IsError)
        {
            return BadRequest(result.Errors.FirstOrDefault());
        }
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteUserAsync(int id)
    {
        ErrorOr<bool> result = await _userInteractor.DeleteUserByIdAsync(id);
        if (result.IsError)
        {
            return NotFound(result.Errors.FirstOrDefault());
        }
        return NoContent();
    }
}
