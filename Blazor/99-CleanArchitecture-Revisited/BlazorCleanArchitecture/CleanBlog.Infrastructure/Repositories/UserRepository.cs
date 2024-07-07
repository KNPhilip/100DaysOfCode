using CleanBlog.Domain.Users;
using CleanBlog.Infrastructure.Authentication;
using Microsoft.AspNetCore.Identity;

namespace CleanBlog.Infrastructure.Repositories;

public sealed class UserRepository(UserManager<User> userManager) : IUserRepository
{
    private readonly UserManager<User> _userManager = userManager;

    public async Task<IUser?> GetUserByIdAsync(string userId)
    {
        return await _userManager.FindByIdAsync(userId);
    }
}
