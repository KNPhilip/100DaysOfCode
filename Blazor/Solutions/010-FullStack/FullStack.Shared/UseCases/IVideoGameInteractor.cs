using FullStack.Shared.Entities;

namespace FullStack.Shared.UseCases;

public interface IVideoGameInteractor
{
    public Task<List<VideoGame>> GetAllVideoGamesAsync();
    public Task<VideoGame> GetVideoGameByIdAsync(int id);
    public Task CreateVideoGameAsync(VideoGame videoGameToCreate);
    public Task UpdateVideoGameAsync(int id, VideoGame videoGameToUpdate);
    public Task DeleteVideoGameByIdAsync(int id);
}
