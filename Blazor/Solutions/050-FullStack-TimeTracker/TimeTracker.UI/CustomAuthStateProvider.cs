using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace TimeTracker.UI
{
    public sealed class CustomAuthStateProvider(HttpClient httpClient,
        ILocalStorageService localStorageService) : AuthenticationStateProvider
    {
        public async sealed override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string? authToken = await localStorageService.GetItemAsStringAsync("authToken");
            AuthenticationState authState;

            if (string.IsNullOrWhiteSpace(authToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = null;
                authState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
            else
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", authToken);

                authState = new AuthenticationState(new ClaimsPrincipal(
                    new ClaimsIdentity(ParseClaimsFromJwt(authToken), "jwt")));
            }

            NotifyAuthenticationStateChanged(Task.FromResult(authState));

            return authState;
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

        private static List<Claim>? ParseClaimsFromJwt(string authToken)
        {
            string payload = authToken.Split('.')[1];
            byte[] jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer
                .Deserialize<Dictionary<string, object>>(jsonBytes);

            List<Claim> claims = [];
            foreach (KeyValuePair<string, object> kvp in keyValuePairs!)
            {
                if (kvp.Value is JsonElement jsonElement 
                    && jsonElement.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement item in jsonElement.EnumerateArray())
                    {
                        claims.Add(new Claim(kvp.Key, item.ToString()));
                    }
                }
                else
                {
                    claims.Add(new Claim(kvp.Key, kvp.Value.ToString()!));
                }
            }

            return claims;
        }
    }
}
