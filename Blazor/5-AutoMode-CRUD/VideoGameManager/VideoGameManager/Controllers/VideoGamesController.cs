namespace VideoGameManager.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class VideoGamesController(IVideoGameInteractor videoGameInteractor) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<VideoGame>>> GetAllVideoGamesAsync()
    {
        return Ok(await videoGameInteractor.GetAllVideoGamesAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<VideoGame>> GetVideoGameByIdAsync(int id)
    {
        return Ok(await videoGameInteractor.GetVideoGameByIdAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult> CreateVideoGameAsync(VideoGame videoGameToCreate)
    {
        await videoGameInteractor.CreateVideoGameAsync(videoGameToCreate);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateVideoGameAsync(int id, VideoGame videoGame)
    {
        await videoGameInteractor.UpdateVideoGameAsync(id, videoGame);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteVideoGameByIdAsync(int id)
    {
        await videoGameInteractor.DeleteVideoGameByIdAsync(id);
        return NoContent();
    }
}
