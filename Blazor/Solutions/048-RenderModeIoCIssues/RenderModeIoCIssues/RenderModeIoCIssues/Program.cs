using Blazr.RenderState.Server;
using RenderModeIoCIssues.Components;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddBlazrRenderStateServerServices();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

WebApplication app = builder.Build();

app.UseWebAssemblyDebugging();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(RenderModeIoCIssues.Client._Imports).Assembly);

app.Run();
