using CascadingDropdowns.Models;

namespace CascadingDropdowns.Services;

public interface IVideoGameService
{
    Task<List<Platform>> GetAllPlatformsAsync();
    Task<List<Genre>> GetAllGenresByPlatformIdAsync(int platformId);
    Task<List<VideoGame>> GetAllVideoGamesByPlatformAndGenreAsync(int platformId, int genreId);
}
