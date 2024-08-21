using ComponentCommunication.Components;
using ComponentCommunication.States;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents();

builder.Services.AddScoped<SharedMessageState>();

WebApplication app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();
