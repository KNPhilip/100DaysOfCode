
namespace CustomHeaders.Client.HttpHandlers;

public sealed class CustomHeaderHandler() : DelegatingHandler(new HttpClientHandler())
{
    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("X-Custom-Header", "CustomHeaderValue");
        return base.SendAsync(request, cancellationToken);
    }
}
