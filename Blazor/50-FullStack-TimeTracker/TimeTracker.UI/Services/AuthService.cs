using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using TimeTracker.Domain.Dtos.Account;
using TimeTracker.Domain.Dtos.Login;

namespace TimeTracker.UI.Services
{
    public sealed class AuthService(HttpClient httpClient,
        IToastService toastService, NavigationManager navigationManager,
        ILocalStorageService localStorageService, AuthenticationStateProvider authStateProvider) 
        : IAuthService
    {
        public async Task Login(LoginRequestDto request)
        {
            HttpResponseMessage result = await httpClient
                .PostAsJsonAsync("api/login", request);

            if (result is not null)
            {
                var response = await result.Content
                    .ReadFromJsonAsync<LoginResponseDto>();
                if (!response.IsSuccessful && response.Error is not null)
                {
                    toastService.ShowError(response.Error);
                }
                else if (!response.IsSuccessful)
                {
                    toastService.ShowError("An unexpected error occurred.");
                }
                else
                {
                    if (response.Token is not null)
                    {
                        await localStorageService.SetItemAsStringAsync("authToken", response.Token);
                        await authStateProvider.GetAuthenticationStateAsync();
                    }
                    navigationManager.NavigateTo("timeentries");
                }
            }
        }

        public async Task Logout()
        {
            await localStorageService.RemoveItemAsync("authToken");
            await authStateProvider.GetAuthenticationStateAsync();
            navigationManager.NavigateTo("/login");
        }

        public async Task RegisterAsync(AccountRegistrationRequestDto request)
        {
            HttpResponseMessage result = await httpClient
                .PostAsJsonAsync("api/account/register", request);

            if (result is not null)
            {
                var response = await result.Content
                    .ReadFromJsonAsync<AccountRegistrationResponseDto>();
                
                if (!response.IsSuccessful && response.Errors is not null)
                {
                    foreach (string error in response.Errors)
                    {
                        toastService.ShowError(error);
                    }
                }
                else if (!response.IsSuccessful)
                {
                    toastService.ShowError("An unexpected error occurred.");
                }
                else
                {
                    navigationManager.NavigateTo("/login");
                }
            }
        }
    }
}
