using TimeTracker.API.Extensions;

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

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();
