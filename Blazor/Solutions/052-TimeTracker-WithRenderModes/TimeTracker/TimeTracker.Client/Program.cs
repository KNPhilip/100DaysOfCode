using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TimeTracker.Client.Extensions;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

Uri baseAddress = new(builder.HostEnvironment.BaseAddress);

builder.Services.AddServicesFromExtensionsClass(baseAddress);

builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
