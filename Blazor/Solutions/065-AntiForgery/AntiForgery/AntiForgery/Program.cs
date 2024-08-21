using AntiForgery.Components;
using AntiForgery.Components.Data;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SandboxDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

WebApplication app = builder.Build();

app.UseWebAssemblyDebugging();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(AntiForgery.Client._Imports).Assembly);

app.Run();
