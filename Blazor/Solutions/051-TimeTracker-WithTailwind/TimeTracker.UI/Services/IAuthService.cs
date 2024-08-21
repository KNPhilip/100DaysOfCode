using TimeTracker.Domain.Dtos.Account;
using TimeTracker.Domain.Dtos.Login;

namespace TimeTracker.UI.Services
{
    public interface IAuthService
    {
        Task<AccountRegistrationResponseDto> RegisterAsync(AccountRegistrationRequestDto request);
        Task<LoginResponseDto> Login(LoginRequestDto request);
        Task Logout();
    }
}
