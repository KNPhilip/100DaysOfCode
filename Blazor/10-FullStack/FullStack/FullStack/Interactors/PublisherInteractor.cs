namespace FullStack.Interactors;

public sealed class PublisherInteractor(DataContext dbContext) : IPublisherInteractor
{
    public async Task<List<Publisher>> GetAllPublishersAsync()
    {
        return await dbContext.Publishers
            .Include(p => p.VideoGames)
            .ToListAsync();
    }

    public async Task<Publisher> GetPublisherByIdAsync(int id)
    {
        return await dbContext.Publishers.FindAsync(id) ?? null!;
    }

    public async Task CreatePublisherAsync(Publisher publisherToCreate)
    {
        await dbContext.Publishers.AddAsync(publisherToCreate);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdatePublisherAsync(int id, Publisher publisherToUpdate)
    {
        Publisher? publisherToEdit = await dbContext.Publishers.FindAsync(id);
        if (publisherToEdit is not null)
        {
            publisherToEdit.Name = publisherToUpdate.Name;
            publisherToEdit.Bio = publisherToUpdate.Bio;

            await dbContext.SaveChangesAsync();
        }
    }

    public async Task DeletePublisherByIdAsync(int id)
    {
        Publisher? publisherToDelete = await dbContext.Publishers.FindAsync(id);
        if (publisherToDelete is not null)
        {
            dbContext.Publishers.Remove(publisherToDelete);
            await dbContext.SaveChangesAsync();
        }
    }
}
