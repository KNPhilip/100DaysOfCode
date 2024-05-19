using TimeTracker.Domain.Dtos.Account;
using TimeTracker.Domain.Dtos.Login;

namespace TimeTracker.UI.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(AccountRegistrationRequestDto request);
        Task Login(LoginRequestDto request);
        Task Logout();
    }
}
