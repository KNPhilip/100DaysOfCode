namespace CleanBlog.Application.Users;

public interface IUserService
{
    Task<string> GetCurrentUserIdAsync();
    Task<bool> IsCurrentUserInRoleAsync(string role);
    Task<bool> CurrentUserCanCreateArticlesAsync();
    Task<bool> CurrentUserCanEditArticleAsync(int articleId);
}
