using CascadingDropdowns.Components;
using CascadingDropdowns.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IVideoGameService, VideoGameService>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

WebApplication app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
