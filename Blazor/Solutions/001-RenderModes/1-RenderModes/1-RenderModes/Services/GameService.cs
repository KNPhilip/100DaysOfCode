namespace _1_RenderModes.Services;

public sealed class GameService(DataContext dbContext) : IGameService
{
    public async Task<Game> AddGame(Game game)
    {
        dbContext.Games.Add(game);
        await dbContext.SaveChangesAsync();

        return game;
    }

    public async Task<bool> DeleteGame(int id)
    {
        Game? game = await dbContext.Games.FindAsync(id);

        if (game is null)
        {
            return false;
        }

        dbContext.Games.Remove(game);
        await dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<Game> EditGame(int id, Game game)
    {
        Game? existingGame = await dbContext.Games.FindAsync(id) 
            ?? throw new Exception("Game not found");

        existingGame.Name = game.Name;

        await dbContext.SaveChangesAsync();

        return existingGame;
    }

    public async Task<List<Game>> GetAllGames()
    {
        return await dbContext.Games.ToListAsync();
    }

    public async Task<Game?> GetGameById(int id)
    {
        return await dbContext.Games.FindAsync(id);
    }
}
