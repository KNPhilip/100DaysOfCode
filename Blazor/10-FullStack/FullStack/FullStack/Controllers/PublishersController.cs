namespace FullStack.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class PublishersController(IPublisherInteractor publisherInteractor) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Publisher>>> GetAllPublishersAsync()
    {
        return Ok(await publisherInteractor.GetAllPublishersAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Publisher>> GetPublisherByIdAsync(int id)
    {
        return Ok(await publisherInteractor.GetPublisherByIdAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult> CreatePublisherAsync(Publisher publisherToCreate)
    {
        await publisherInteractor.CreatePublisherAsync(publisherToCreate);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdatePublisherAsync(int id, Publisher publisher)
    {
        await publisherInteractor.UpdatePublisherAsync(id, publisher);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeletePublisherByIdAsync(int id)
    {
        await publisherInteractor.DeletePublisherByIdAsync(id);
        return NoContent();
    }
}
