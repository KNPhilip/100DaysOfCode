using CleanBlog.Presentation.Server.Components;
using CleanBlog.Application;
using CleanBlog.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents();

builder.Services.AddApplicationExtensions();

builder.Services.AddInfrastructureExtensions(builder.Configuration);

WebApplication app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();
