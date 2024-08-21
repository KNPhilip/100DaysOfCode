using TimeTracker.Domain.Dtos.Account;

namespace TimeTracker.Server.Services
{
    public interface IAccountService
    {
        Task<AccountRegistrationResponseDto> RegisterAsync(AccountRegistrationRequestDto request);
        Task AssignRole(string userName, string roleName);
    }
}
