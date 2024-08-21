using MusicPadController.MusicPad;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MusicPadController;
using MusicPadController.MusicPad;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<ISoundPlayer, SoundPlayer>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) 
});

await builder.Build().RunAsync();
