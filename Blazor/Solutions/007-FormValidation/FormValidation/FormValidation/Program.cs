using FormValidation.Components;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

WebApplication app = builder.Build();

app.UseWebAssemblyDebugging();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(FormValidation.Client._Imports).Assembly);

app.Run();
