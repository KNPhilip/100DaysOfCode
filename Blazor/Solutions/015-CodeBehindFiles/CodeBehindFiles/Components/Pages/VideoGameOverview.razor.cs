namespace CodeBehindFiles.Components.Pages;

public partial class VideoGameOverview
{
    List<VideoGame> videoGames = [];

    protected sealed override async Task OnInitializedAsync()
    {
        await UpdateVideoGameListAsync();
    }

    private async Task DeleteGameWithIdAsync(int id)
    {
        VideoGame? gameToDelete = await DbContext.VideoGames.FindAsync(id);
        if (gameToDelete is not null)
        {
            DbContext.VideoGames.Remove(gameToDelete);
            await DbContext.SaveChangesAsync();
        }

        await UpdateVideoGameListAsync();
    }

    private async Task UpdateVideoGameListAsync()
    {
        videoGames = await DbContext.VideoGames.ToListAsync();
    }
}
