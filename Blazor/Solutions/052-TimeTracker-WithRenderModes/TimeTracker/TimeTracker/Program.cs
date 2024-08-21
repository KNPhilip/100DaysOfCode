using TimeTracker.Server.Extensions;
using TimeTracker.Server.Components;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

Extensions.ConfigureMapster();

// Add services to the container.
builder.Services.AddServicesFromExtensionsClass(builder.Configuration);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
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

app.UseRouting();

app.UseStaticFiles();

app.UseAntiforgery();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(TimeTracker.Client._Imports).Assembly);

app.Run();
