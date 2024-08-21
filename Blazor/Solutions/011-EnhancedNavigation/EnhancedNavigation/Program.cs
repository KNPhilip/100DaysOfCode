WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents();

builder.Services.AddSingleton<IDataStateProvider, DataStateProvider>();

WebApplication app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();
