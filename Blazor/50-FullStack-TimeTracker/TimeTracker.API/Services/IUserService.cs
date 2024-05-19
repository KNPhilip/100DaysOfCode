using TimeTracker.Domain.Entities;

namespace TimeTracker.API.Services
{
    public interface IUserService
    {
        string? GetUserId();
        Task<User?> GetUserAsync();
    }
}
