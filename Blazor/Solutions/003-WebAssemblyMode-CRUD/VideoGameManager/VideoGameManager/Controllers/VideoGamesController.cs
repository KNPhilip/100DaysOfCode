namespace VideoGameManager.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class VideoGamesController(DataContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<VideoGame>>> GetVideoGamesAsync()
    {
        return Ok(await dbContext.VideoGames.ToListAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<VideoGame>> GetGameByIdAsync(int id)
    {
        return Ok(await dbContext.VideoGames.FindAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult> CreateVideoGameAsync(VideoGame gameToCreate)
    {
        await dbContext.AddAsync(gameToCreate);
        return await dbContext.SaveChangesAsync() > 0 
            ? Ok() : BadRequest();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateVideoGameAsync(int id, VideoGame replacingVideoGame)
    {
        VideoGame? videoGameToUpdate = await dbContext.VideoGames.FindAsync(id);

        videoGameToUpdate!.Title = replacingVideoGame.Title;
        videoGameToUpdate!.Publisher = replacingVideoGame.Publisher;
        videoGameToUpdate!.ReleaseYear = replacingVideoGame.ReleaseYear;
        
        return await dbContext.SaveChangesAsync() > 0
            ? NoContent() : BadRequest();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> DeleteVideoGameAsync(int id)
    {
        VideoGame? videoGameToDelete = await dbContext.VideoGames.FindAsync(id);
        dbContext.VideoGames.Remove(videoGameToDelete!);
        return Ok(await dbContext.SaveChangesAsync() > 0);
    }
}
