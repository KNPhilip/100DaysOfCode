namespace _1_RenderModes.Controller;

[Route("api/[controller]")]
[ApiController]
public sealed class GameController(IGameService gameService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Game>> GetGame(int id)
    {
        return Ok(await gameService.GetGameById(id));
    }

    [HttpPost]
    public async Task<ActionResult<Game>> AddGame(Game game)
    {
        return Ok(await gameService.AddGame(game));
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Game>> EditGame(int id, Game game)
    {
        return Ok(await gameService.EditGame(id, game));
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Game>> DeleteGame(int id)
    {
        return Ok(await gameService.DeleteGame(id));
    }
}
