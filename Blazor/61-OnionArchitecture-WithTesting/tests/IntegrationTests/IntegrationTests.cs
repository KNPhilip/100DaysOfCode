#nullable disable

using System.Net;

namespace IntegrationTests;

public sealed class IntegrationTests : TestBase
{
    [Fact]
    public async Task GetAllPersonsAsync_WhenCalled_Returns200OK()
    {
        // Arrange  
        HttpClient client = Factory.CreateClient();

        // Act  
        HttpResponseMessage response = await client.GetAsync("api/person");

        // Assert  
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
