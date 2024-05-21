using TimeTracker.Domain.Dtos.Login;

namespace TimeTracker.Server.Services
{
    public interface ILoginService
    {
        Task<LoginResponseDto> Login(LoginRequestDto request);
    }
}
