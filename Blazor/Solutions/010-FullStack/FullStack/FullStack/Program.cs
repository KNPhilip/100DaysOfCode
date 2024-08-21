WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddControllers();

builder.Services.AddScoped<IVideoGameInteractor, VideoGameInteractor>();
builder.Services.AddScoped<IPublisherInteractor, PublisherInteractor>();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

WebApplication app = builder.Build();

app.MapControllers();

app.UseWebAssemblyDebugging();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(FullStack.Client._Imports).Assembly);

app.Run();
