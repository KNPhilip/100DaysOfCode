using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Security.Claims;
using TimeTracker.Domain.Dtos.Account;

namespace TimeTracker.Server
{
    public sealed class ServerAuthStateProvider : ServerAuthenticationStateProvider, IDisposable
    {
        private readonly PersistentComponentState _state;
        private readonly IdentityOptions _options;

        private readonly PersistingComponentStateSubscription _subscription;

        private Task<AuthenticationState>? _authenticationStateTask;

        public ServerAuthStateProvider(
            PersistentComponentState state,
            IOptions<IdentityOptions> options)
            : base()
        {
            _state = state;
            _options = options.Value;

            AuthenticationStateChanged += OnAuthenticationStateChanged;
            _subscription = state.RegisterOnPersisting(OnPersistingAsync, RenderMode.InteractiveWebAssembly);
        }

        private void OnAuthenticationStateChanged(Task<AuthenticationState> task)
        {
            _authenticationStateTask = task;
        }

        private async Task OnPersistingAsync()
        {
            if (_authenticationStateTask is null)
            {
                throw new UnreachableException($"Authentication state not set in {nameof(RevalidatingServerAuthenticationStateProvider)}");
            }

            AuthenticationState authenticationState = 
                await _authenticationStateTask;
            ClaimsPrincipal principal = authenticationState.User;

            if (principal.Identity?.IsAuthenticated is true)
            {
                string? userId = principal
                    .FindFirst(_options.ClaimsIdentity.UserIdClaimType)?.Value;
                string? email = principal
                    .FindFirst(_options.ClaimsIdentity.EmailClaimType)?.Value;
                List<string> roles = principal
                    .FindAll(_options.ClaimsIdentity.RoleClaimType).Select(r => r.Value).ToList();

                if (userId is not null && email is not null)
                {
                    _state.PersistAsJson(nameof(UserInfoDto), new UserInfoDto
                    {
                        UserId = userId,
                        Email = email,
                        Roles = roles
                    });
                }
            }
        }

        void IDisposable.Dispose()
        {
            AuthenticationStateChanged -= OnAuthenticationStateChanged;
        }
    }
}
