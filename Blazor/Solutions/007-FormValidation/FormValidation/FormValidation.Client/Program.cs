global using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
global using System.ComponentModel.DataAnnotations;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

await builder.Build().RunAsync();
