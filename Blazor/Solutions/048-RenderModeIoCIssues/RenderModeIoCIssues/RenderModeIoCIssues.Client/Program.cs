using Blazr.RenderState.WASM;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.AddBlazrRenderStateWASMServices();

await builder.Build().RunAsync();
