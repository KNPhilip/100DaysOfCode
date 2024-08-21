namespace _1_RenderModes.Client.Services;

public sealed class GameService(HttpClient httpClient) : IGameService
{
    public async Task<Game> AddGame(Game game)
    {
        HttpResponseMessage result = await httpClient
            .PostAsJsonAsync("api/game", game);

        return await result.Content.ReadFromJsonAsync<Game>();
    }

    public async Task<bool> DeleteGame(int id)
    {
        HttpResponseMessage result = await httpClient
            .DeleteAsync($"api/game/{id}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<Game> EditGame(int id, Game game)
    {
        HttpResponseMessage result = await httpClient.PutAsJsonAsync($"api/game/{id}", game);
        return await result.Content.ReadFromJsonAsync<Game>();
    }

    public async Task<List<Game>> GetAllGames()
    {
        return await httpClient.GetFromJsonAsync<List<Game>>("api/game") ?? [];
    }

    public async Task<Game?> GetGameById(int id)
    {
        Game? result = await httpClient
            .GetFromJsonAsync<Game>($"api/game/{id}");

        return result;
    }
}
