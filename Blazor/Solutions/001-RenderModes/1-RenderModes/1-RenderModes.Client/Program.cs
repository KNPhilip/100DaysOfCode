global using System.Net.Http.Json;
global using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
global using _1_RenderModes.Client.Services;
global using _1_RenderModes.Shared.UseCases;
global using _1_RenderModes.Shared.Entities;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<IGameService, GameService>();

builder.Services.AddScoped(http => new HttpClient 
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) 
});

await builder.Build().RunAsync();
