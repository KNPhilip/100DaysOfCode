using PDFGenerator.Components;
using PDFGenerator.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

WebApplication app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
