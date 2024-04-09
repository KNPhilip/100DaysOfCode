namespace FullStack.Interactors;

public sealed class VideoGameInteractor(DataContext dbContext) : IVideoGameInteractor
{
    public async Task<List<VideoGame>> GetAllVideoGamesAsync()
    {
        return await dbContext.VideoGames
            .Include(vg => vg.Publisher)
            .ToListAsync() ?? [];
    }

    public async Task<VideoGame> GetVideoGameByIdAsync(int id)
    {
        return await dbContext.VideoGames
            .Include(vg => vg.Publisher)
            .FirstOrDefaultAsync(vg => vg.Id == id) ?? null!;
    }

    public async Task CreateVideoGameAsync(VideoGame videoGameToCreate)
    {
        await dbContext.VideoGames.AddAsync(videoGameToCreate);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateVideoGameAsync(int id, VideoGame videoGameToUpdate)
    {
        VideoGame? videoGameToEdit = await dbContext.VideoGames.FindAsync(id);
        if (videoGameToEdit is not null)
        {
            videoGameToEdit.Title = videoGameToUpdate.Title;
            videoGameToEdit.Publisher = videoGameToUpdate.Publisher;
            videoGameToEdit.ReleaseYear = videoGameToUpdate.ReleaseYear;

            await dbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteVideoGameByIdAsync(int id)
    {
        VideoGame? videoGameToDelete = await dbContext.VideoGames.FindAsync(id);
        if (videoGameToDelete is not null)
        {
            dbContext.VideoGames.Remove(videoGameToDelete);
            await dbContext.SaveChangesAsync();
        }
    }
}
