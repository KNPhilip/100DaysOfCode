using CleanBlog.Domain.Articles;
using CleanBlog.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace CleanBlog.Infrastructure.Authentication;

public class User : IdentityUser, IUser
{
    public List<Article> Articles { get; set; } = [];
}
