using CleanBlog.Application.Authentication;
using CleanBlog.Application.Users;
using CleanBlog.Domain.Articles;
using CleanBlog.Domain.Users;
using CleanBlog.Infrastructure.Authentication;
using CleanBlog.Infrastructure.Repositories;
using CleanBlog.Infrastructure.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
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
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        });

        AddAuthentication(services);

        services.AddHttpContextAccessor();

        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }

    private static void AddAuthentication(IServiceCollection services)
    {
        services.AddSingleton<IAuthorizationMiddlewareResultHandler, AuthorizationMiddlewareResultHandler>();

        services.AddScoped<IAuthenticationService, AuthenticationService>();

        services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

        services.AddCascadingAuthenticationState();

        services.AddAuthorization();
        services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        })
        .AddIdentityCookies();

        services.AddIdentityCore<User>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();
    }
}
