namespace VideoGameManager.Client.Interactors;

public sealed class VideoGameInteractor(HttpClient httpClient) : IVideoGameInteractor
{
    public async Task<List<VideoGame>> GetAllVideoGamesAsync()
    {
        return await httpClient.GetFromJsonAsync<List<VideoGame>>("api/videogames") ?? [];
    }

    public async Task<VideoGame> GetVideoGameByIdAsync(int id)
    {
        return await httpClient.GetFromJsonAsync<VideoGame>($"api/videogames/{id}") ?? null!;
    }

    public async Task CreateVideoGameAsync(VideoGame videoGameToCreate)
    {
        await httpClient.PostAsJsonAsync("api/videogames", videoGameToCreate);
    }

    public async Task UpdateVideoGameAsync(int id, VideoGame videoGameToUpdate)
    {
        await httpClient.PutAsJsonAsync($"api/videogames/{id}", videoGameToUpdate);
    }

    public async Task DeleteVideoGameByIdAsync(int id)
    {
        await httpClient.DeleteAsync($"api/videogames/{id}");
    }
}
