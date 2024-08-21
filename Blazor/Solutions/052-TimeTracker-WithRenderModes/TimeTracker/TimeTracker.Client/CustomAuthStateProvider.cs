using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using TimeTracker.Domain.Dtos.Account;

namespace TimeTracker.Client
{
    public sealed class CustomAuthStateProvider(
        PersistentComponentState persistentState) : AuthenticationStateProvider
    {
        private static readonly Task<AuthenticationState> _unauthenticatedTask =
            Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));

        public sealed override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (!persistentState.TryTakeFromJson<UserInfoDto>(nameof(UserInfoDto), out var userInfo) || userInfo is null)
            {
                return _unauthenticatedTask;
            }

            List<Claim> claims = [
                new Claim(ClaimTypes.NameIdentifier, userInfo.UserId),
                new Claim(ClaimTypes.Name, userInfo.Email),
                new Claim(ClaimTypes.Email, userInfo.Email)];

            claims.AddRange(userInfo.Roles.Select(role => new Claim(ClaimTypes.Role, role)));

            return Task.FromResult(
                new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims,
                    authenticationType: nameof(CustomAuthStateProvider)))));
        }
    }
}
