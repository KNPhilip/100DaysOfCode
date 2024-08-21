global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using _1_RenderModes.Components;
global using _1_RenderModes.Services;
global using _1_RenderModes.Data;
global using _1_RenderModes.Shared.Entities;
global using _1_RenderModes.Shared.UseCases;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddControllers();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration["BaseUri"]!)
});

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseInMemoryDatabase("RenderModes");
});

builder.Services.AddScoped<IGameService, GameService>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseStaticFiles();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(_1_RenderModes.Client._Imports).Assembly);

app.Run();
