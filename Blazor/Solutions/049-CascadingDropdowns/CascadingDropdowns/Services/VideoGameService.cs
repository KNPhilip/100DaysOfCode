using CascadingDropdowns.Models;

namespace CascadingDropdowns.Services;

public sealed class VideoGameService : IVideoGameService
{
    private readonly List<Platform> platforms = [
        new() { Id = 1, Name = "PC" },
        new() { Id = 2, Name = "PlayStation 5" },
        new() { Id = 3, Name = "Xbox Series X" }
    ];

    private readonly List<Genre> genres = [
        new() { Id = 1, Name = "Action", PlatformId = 1 },
        new() { Id = 2, Name = "RPG", PlatformId = 1 },
        new() { Id = 3, Name = "Sports", PlatformId = 2 },
        new() { Id = 4, Name = "Adventure", PlatformId = 3 },
    ];

    private readonly List<VideoGame> videoGames = [
        new() { Id = 1, Name = "Cyberpunk 2077", PlatformId = 1, GenreId = 2 },
        new() { Id = 2, Name = "FIFA 21", PlatformId = 2, GenreId = 3 },
        new() { Id = 3, Name = "Assassin's Creed Valhalla", PlatformId = 3, GenreId = 1 },
        new() { Id = 4, Name = "The Witcher 3: Wild Hunt", PlatformId = 1, GenreId = 2 },
        new() { Id = 5, Name = "F1 2020", PlatformId = 2, GenreId = 3 },
        new() { Id = 6, Name = "Forza Horizon 4", PlatformId = 3, GenreId = 3 },
        new() { Id = 7, Name = "Red Dead Redemption 2", PlatformId = 1, GenreId = 1 },
        new() { Id = 8, Name = "NBA 2K21", PlatformId = 2, GenreId = 3 },
        new() { Id = 9, Name = "Gears 5", PlatformId = 3, GenreId = 1 },
        new() { Id = 10, Name = "The Elder Scrolls V: Skyrim", PlatformId = 1, GenreId = 2 },
        new() { Id = 11, Name = "Madden NFL 21", PlatformId = 2, GenreId = 3 },
        new() { Id = 12, Name = "Halo: The Master Chief Collection", PlatformId = 3, GenreId = 1 },
        new() { Id = 13, Name = "Grand Theft Auto V", PlatformId = 1, GenreId = 1 },
        new() { Id = 14, Name = "NHL 21", PlatformId = 2, GenreId = 3 },
        new() { Id = 15, Name = "Sea of Thieves", PlatformId = 3, GenreId = 4 }
    ];

    public Task<List<Platform>> GetAllPlatformsAsync()
    {
        return Task.FromResult(platforms);
    }

    public Task<List<Genre>> GetAllGenresByPlatformIdAsync(int platformId)
    {
        List<Genre> filteredGenres = genres.Where(g => g.PlatformId == platformId).ToList();
        return Task.FromResult(filteredGenres);
    }

    public Task<List<VideoGame>> GetAllVideoGamesByPlatformAndGenreAsync(int platformId, int genreId)
    {
        List<VideoGame> filteredVideoGames = videoGames.Where(vg => vg.PlatformId == platformId && vg.GenreId == genreId).ToList();
        return Task.FromResult(filteredVideoGames);
    }
}
