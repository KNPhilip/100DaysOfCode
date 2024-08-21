using _1_RenderModes.Shared.Entities;

namespace _1_RenderModes.Shared.UseCases;

public interface IGameService
{
    Task<List<Game>> GetAllGames();
    Task<Game?> GetGameById(int id);
    Task<Game> AddGame(Game game);
    Task<Game> EditGame(int id, Game game);
    Task<bool> DeleteGame(int id);
}
