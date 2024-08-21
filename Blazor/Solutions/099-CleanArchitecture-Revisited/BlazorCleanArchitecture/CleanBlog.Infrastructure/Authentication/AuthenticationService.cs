using CleanBlog.Application.Authentication;
using Microsoft.AspNetCore.Identity;

namespace CleanBlog.Infrastructure.Authentication;

public sealed class AuthenticationService(UserManager<User> userManager,
    SignInManager<User> signInManager) : IAuthenticationService
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly SignInManager<User> _signInManager = signInManager;

    public async Task<bool> LoginUserAsync(string username, string password)
    {
        SignInResult result = await _signInManager
            .PasswordSignInAsync(username, password, false, false);
        return result.Succeeded;
    }

    public async Task<RegisterUserResponse> RegisterUserAsync(string username,
        string email, string password)
    {
        User user = new()
        {
            UserName = username,
            Email = email,
            EmailConfirmed = true
        };
        IdentityResult result = await _userManager.CreateAsync(user, password);

        await _userManager.AddToRoleAsync(user, "Reader");

        RegisterUserResponse response = new()
        {
            Succeeded = result.Succeeded,
            Errors = result.Errors.Select(e => e.Description).ToList()
        };
        return response;
    }
}
