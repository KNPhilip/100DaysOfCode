using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using TimeTracker.Client.Services;

namespace TimeTracker.Client.Extensions
{
    public static class Extensions
    {
        public static void AddServicesFromExtensionsClass(this IServiceCollection services, Uri baseAddress)
        {
            services.AddAuthorizationCore();
            services.AddCascadingAuthenticationState();

            services.AddScoped(sp => new HttpClient { BaseAddress = baseAddress });
            services.AddScoped<ITimeEntryService, TimeEntryService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddBlazoredToast();
            services.AddBlazoredLocalStorage();

            services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            services.AddAuthorizationCore();
        }
    }
}
