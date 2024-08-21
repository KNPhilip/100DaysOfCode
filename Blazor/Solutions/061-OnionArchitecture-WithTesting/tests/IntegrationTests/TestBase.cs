using DataAccess.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests;

[Collection(nameof(TestBase))]
public abstract class TestBase : IDisposable
{
    static TestBase()
    {
        Factory = new CustomWebApplicationFactory<Program>();

        using IServiceScope scope = Factory.Services.CreateScope();
        using DataContext dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();

        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
    }

    protected static CustomWebApplicationFactory<Program> Factory { get; }

    public void Dispose()
    {
        Factory.Dispose();
    }
}

public sealed class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
    where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.ReplaceDbContext();
        });
    }
}

public static class TestExtensions
{
    public static IServiceCollection ReplaceDbContext(this IServiceCollection services)
    {
        ServiceDescriptor? descriptor = services.SingleOrDefault(
            d => d.ServiceType ==
                 typeof(DbContextOptions<DataContext>));

        if (descriptor is not null)
        {
            services.Remove(descriptor);
        }

        services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("InMemory"));

        return services;
    }
}
