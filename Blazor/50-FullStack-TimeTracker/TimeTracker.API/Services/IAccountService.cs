using TimeTracker.Domain.Dtos.Account;

namespace TimeTracker.API.Services
{
    public interface IAccountService
    {
        Task<AccountRegistrationResponseDto> RegisterAsync(AccountRegistrationRequestDto request);
        Task AssignRole(string userName, string roleName);
    }
}
