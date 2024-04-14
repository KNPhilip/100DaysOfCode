using Microsoft.AspNetCore.Components;

namespace CodeBehindFiles.Components.Pages;
public partial class EditVideoGame
{
    [Parameter]
    public int? Id { get; set; } = null;

    [SupplyParameterFromForm(FormName = "GameForm")]
    private VideoGame CurrentGame { get; set; } = new();

    private string statusMessage = string.Empty;

    protected sealed override async Task OnParametersSetAsync()
    {
        if (Id is not null)
        {
            VideoGame? game = await DbContext.VideoGames.FindAsync(Id);
            if (game is not null)
            {
                CurrentGame.Title ??= game.Title;
                CurrentGame.Publisher ??= game.Publisher;
                CurrentGame.ReleaseYear ??= game.ReleaseYear;
            }
        }
    }

    private async Task HandleSubmitAsync()
    {
        if (Id is not null)
        {
            await UpdateGameAsync();
        }
        else
        {
            await CreateGameAsync();
        }
    }

    private async Task CreateGameAsync()
    {
        DbContext.VideoGames.Add(CurrentGame);
        bool hasSuccessfullyAddedGame = await DbContext.SaveChangesAsync() > 0;

        if (hasSuccessfullyAddedGame)
        {
            statusMessage = "Game added successfully!";
        }
        else
        {
            statusMessage = "Failed to add game!";
        }
    }

    private async Task UpdateGameAsync()
    {
        VideoGame? gameToUpdate = await DbContext.VideoGames.FindAsync(Id);
        if (gameToUpdate is not null)
        {
            gameToUpdate.Title = CurrentGame.Title;
            gameToUpdate.Publisher = CurrentGame.Publisher;
            gameToUpdate.ReleaseYear = CurrentGame.ReleaseYear;

            bool hasSuccessfullyUpdatedGame = await DbContext.SaveChangesAsync() > 0;

            if (hasSuccessfullyUpdatedGame)
            {
                statusMessage = "Game updated successfully!";
            }
            else
            {
                statusMessage = "Failed to update game!";
            }
        }
    }
}
