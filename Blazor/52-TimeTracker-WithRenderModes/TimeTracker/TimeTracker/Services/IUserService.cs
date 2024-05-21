using TimeTracker.Domain.Entities;

namespace TimeTracker.Server.Services
{
    public interface IUserService
    {
        string? GetUserId();
        Task<User?> GetUserAsync();
    }
}
