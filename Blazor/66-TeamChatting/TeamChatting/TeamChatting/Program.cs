using TeamChatting.Components;
using TeamChatting.Hubs;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSignalR();

WebApplication app = builder.Build();

app.UseWebAssemblyDebugging();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();

app.MapHub<QualityManagementHub>("/qm-chat");
app.MapHub<ManufacturingChat>("/manu-chat");
app.MapHub<ProcurementChat>("/proc-chat");

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(TeamChatting.Client._Imports).Assembly);

app.Run();
