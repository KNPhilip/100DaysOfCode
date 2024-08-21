using CleanBlog.Domain.Articles;
using CleanBlog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanBlog.Infrastructure;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructureExtensions(
        this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                options.UseInMemoryDatabase("InMemoryDb");
            }
            else
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }
        });

        services.AddScoped<IArticleRepository, ArticleRepository>();

        return services;
    }
}
