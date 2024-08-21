WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<IVideoGameInteractor, VideoGameInteractor>();
builder.Services.AddScoped<IPublisherInteractor, PublisherInteractor>();
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

await builder.Build().RunAsync();
