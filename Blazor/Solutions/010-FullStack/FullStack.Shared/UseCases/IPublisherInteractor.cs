using FullStack.Shared.Entities;

namespace FullStack.Shared.UseCases;

public interface IPublisherInteractor
{
    public Task<List<Publisher>> GetAllPublishersAsync();
    public Task<Publisher> GetPublisherByIdAsync(int id);
    public Task CreatePublisherAsync(Publisher publisherToCreate);
    public Task UpdatePublisherAsync(int id, Publisher publisherToUpdate);
    public Task DeletePublisherByIdAsync(int id);
}
