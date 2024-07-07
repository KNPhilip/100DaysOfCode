using CleanBlog.Application.Users;
using CleanBlog.Domain.Articles;
using CleanBlog.Infrastructure.Authentication;
using CleanBlog.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace CleanBlog.Infrastructure.Users;

public sealed class UserService(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor,
    IArticleRepository articleRepository) : IUserService
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IArticleRepository _articleRepository = articleRepository;

    public async Task<bool> CurrentUserCanCreateArticlesAsync()
    {
        User? user = await GetCurrentUserAsync();
        if (user is null)
        {
            return false;
        }

        bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        bool isWriter = await _userManager.IsInRoleAsync(user, "Writer");

        bool result = isAdmin || isWriter;
        return result;
    }

    public async Task<bool> CurrentUserCanEditArticleAsync(int articleId)
    {
        User? user = await GetCurrentUserAsync();
        if (user is null)
        {
            return false;
        }

        bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        bool isWriter = await _userManager.IsInRoleAsync(user, "Writer");

        Article? article = await _articleRepository.GetArticleByIdAsync(articleId);
        if (article is null)
        {
            return false;
        }

        bool result = isAdmin || (isWriter && user.Id == article.UserId);
        return result;
    }

    public async Task<string> GetCurrentUserIdAsync()
    {
        User user = await GetCurrentUserAsync() 
            ?? throw new UserNotAuthorizedException();

        return user.Id;
    }

    public async Task<bool> IsCurrentUserInRoleAsync(string role)
    {
        User? user = await GetCurrentUserAsync();
        bool result = user is not null &&
            await _userManager.IsInRoleAsync(user, role);
        return result;
    }

    private async Task<User?> GetCurrentUserAsync()
    {
        HttpContext? httpContext = _httpContextAccessor.HttpContext;
        if (httpContext is null || httpContext.User is null)
        {
            return null;
        }

        User? user = await _userManager.GetUserAsync(httpContext.User);
        return user;
    }
}
