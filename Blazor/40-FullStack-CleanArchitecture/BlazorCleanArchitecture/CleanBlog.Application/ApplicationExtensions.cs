using Microsoft.Extensions.DependencyInjection;

namespace CleanBlog.Application;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationExtensions(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(ApplicationExtensions).Assembly);
        });

        return services;
    }
}
