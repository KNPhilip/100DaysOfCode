using TimeTracker.Domain.Dtos.Login;

namespace TimeTracker.API.Services
{
    public interface ILoginService
    {
        Task<LoginResponseDto> Login(LoginRequestDto request);
    }
}
