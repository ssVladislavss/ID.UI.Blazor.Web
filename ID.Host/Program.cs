using ID.Host;
using ID.UI.Core.ApiResources;
using ID.UI.Core.ApiResources.Abstractions;
using ID.UI.Core.ApiScopes;
using ID.UI.Core.ApiScopes.Abstractions;
using ID.UI.Core.Clients;
using ID.UI.Core.Clients.Abstractions;
using ID.UI.Providers.API.ID.ApiResources;
using ID.UI.Providers.API.ID.ApiScopes;
using ID.UI.Providers.API.ID.Clients;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient();

builder.Services.AddScoped<IApiResorceProvider, ApiResourceProvider>();
builder.Services.AddScoped<IApiScopeProvider, ApiScopeProvider>();
builder.Services.AddScoped<IClientProvider, ClientProvider>();

builder.Services.AddScoped<IApiResourceService, ApiResourceService>();
builder.Services.AddScoped<IApiScopeService, ApiScopeService>();
builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();
