global using SSRForms.Components;
global using SSRForms.Models;
global using SSRForms.Services;
global using System.ComponentModel.DataAnnotations;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents();

builder.Services.AddSingleton<IDataStateService, DataStateService>();

WebApplication app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();
