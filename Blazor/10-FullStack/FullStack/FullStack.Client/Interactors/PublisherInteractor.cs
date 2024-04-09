namespace FullStack.Client.Interactors;

public sealed class PublisherInteractor(HttpClient httpClient) : IPublisherInteractor
{
    public async Task<List<Publisher>> GetAllPublishersAsync()
    {
        return await httpClient.GetFromJsonAsync<List<Publisher>>("api/publishers") ?? [];
    }

    public async Task<Publisher> GetPublisherByIdAsync(int id)
    {
        return await httpClient.GetFromJsonAsync<Publisher>($"api/publishers/{id}") ?? null!;
    }

    public async Task CreatePublisherAsync(Publisher publisherToCreate)
    {
        await httpClient.PostAsJsonAsync("api/publishers", publisherToCreate);
    }

    public async Task UpdatePublisherAsync(int id, Publisher publisherToUpdate)
    {
        await httpClient.PutAsJsonAsync($"api/publishers/{id}", publisherToUpdate);
    }

    public async Task DeletePublisherByIdAsync(int id)
    {
        await httpClient.DeleteAsync($"api/publishers/{id}");
    }
}
