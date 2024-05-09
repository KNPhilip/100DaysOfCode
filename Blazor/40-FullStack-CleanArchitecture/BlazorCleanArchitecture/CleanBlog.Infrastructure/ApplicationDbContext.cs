using CleanBlog.Domain.Articles;
using Microsoft.EntityFrameworkCore;

namespace CleanBlog.Infrastructure;

public sealed class ApplicationDbContext(DbContextOptions options) 
    : DbContext(options)
{
    public DbSet<Article> Articles { get; set; } 
}
