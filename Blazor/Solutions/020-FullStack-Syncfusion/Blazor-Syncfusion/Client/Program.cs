using BlazorSyncfusion.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
using Mapster;
using BlazorSyncfusion.Shared.Dtos;
using BlazorSyncfusion.Shared.Entities;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("BlazorSyncfusion.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorSyncfusion.ServerAPI"));
builder.Services.AddSyncfusionBlazor();

ConfigureMapster();

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(" *Your License key here* ");

await builder.Build().RunAsync();

static void ConfigureMapster()
{
    var config = TypeAdapterConfig.GlobalSettings;

    config.ForType<NoteDto, Note>()
        .Map(dest => dest.Employee!.NickName, src => src.EmployeeNickName)
        .Map(dest => dest.Employee!.Id, src => src.EmployeeId)
        .Map(dest => dest.Text, src => src.Text)
        .Map(dest => dest, src => src)
        .IgnoreNonMapped(true);
}