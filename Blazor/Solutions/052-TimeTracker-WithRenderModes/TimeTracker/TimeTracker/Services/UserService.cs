using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Server.Services
{
    public sealed class UserService(UserManager<User> userManager,
        IHttpContextAccessor httpContextAccessor) : IUserService
    {
        public async Task<User?> GetUserAsync()
        {
            ClaimsPrincipal? httpContextUser = httpContextAccessor.HttpContext?.User;
            if (httpContextUser is null)
            {
                return null;
            }

            return await userManager.GetUserAsync(httpContextUser);
        }

        public string? GetUserId()
        {
            return httpContextAccessor.HttpContext?.User
                .FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
