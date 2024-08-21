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
        NavigationManager navigationManager, ILocalStorageService localStorageService,
        AuthenticationStateProvider authStateProvider) : IAuthService
    {
        public async Task<LoginResponseDto> Login(LoginRequestDto request)
        {
            HttpResponseMessage result = await httpClient
                .PostAsJsonAsync("api/login", request);

            if (result is not null)
            {
                var response = await result.Content
                    .ReadFromJsonAsync<LoginResponseDto>();
                if (response.IsSuccessful)
                {
                    if (response.Token is not null)
                    {
                        await localStorageService.SetItemAsStringAsync("authToken", response.Token);
                        await authStateProvider.GetAuthenticationStateAsync();
                    }
                    navigationManager.NavigateTo("timeentries");
                }
                return response;
            }
            return new LoginResponseDto(false);
        }

        public async Task Logout()
        {
            await localStorageService.RemoveItemAsync("authToken");
            await authStateProvider.GetAuthenticationStateAsync();
            navigationManager.NavigateTo("/login");
        }

        public async Task<AccountRegistrationResponseDto> RegisterAsync(AccountRegistrationRequestDto request)
        {
            HttpResponseMessage result = await httpClient
                .PostAsJsonAsync("api/account/register", request);

            if (result is not null)
            {
                return await result.Content
                    .ReadFromJsonAsync<AccountRegistrationResponseDto>();
            }
            return new AccountRegistrationResponseDto(false);
        }
    }
}
