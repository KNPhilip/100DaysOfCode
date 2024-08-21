using ShakespearTranslator.Components;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents();

builder.Services.AddHttpClient();

WebApplication app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();
