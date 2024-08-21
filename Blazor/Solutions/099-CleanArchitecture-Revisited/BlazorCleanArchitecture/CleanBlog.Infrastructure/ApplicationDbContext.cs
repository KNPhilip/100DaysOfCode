using CleanBlog.Domain.Articles;
using CleanBlog.Infrastructure.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanBlog.Infrastructure;

public sealed class ApplicationDbContext(DbContextOptions options) 
    : IdentityDbContext<User>(options)
{
    public DbSet<Article> Articles { get; set; } 
}
