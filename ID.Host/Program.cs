using Blazored.LocalStorage;
using ID.Host;
using ID.Host.Infrastracture;
using ID.UI.Core.ApiResources;
using ID.UI.Core.ApiResources.Abstractions;
using ID.UI.Core.ApiScopes;
using ID.UI.Core.ApiScopes.Abstractions;
using ID.UI.Core.Clients;
using ID.UI.Core.Clients.Abstractions;
using ID.UI.Core.Options;
using ID.UI.Core.State;
using ID.UI.Core.State.Abstractions;
using ID.UI.Core.Users;
using ID.UI.Core.Users.Abstractions;
using ID.UI.Providers.API.ID.ApiResources;
using ID.UI.Providers.API.ID.ApiScopes;
using ID.UI.Providers.API.ID.Clients;
using ID.UI.Providers.API.ID.Users;
using Microsoft.AspNetCore.Components.Authorization;
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
builder.Services.AddScoped<IUserProvider, UserProvider>();

builder.Services.AddScoped<IApiResourceService, ApiResourceService>();
builder.Services.AddScoped<IApiScopeService, ApiScopeService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IDStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(opt => opt.GetRequiredService<IDStateProvider>());
builder.Services.AddScoped<IStateService, StateService>();

builder.Services.Configure<StateOptions>(options =>
{
    builder.Configuration.GetSection(StateOptions.StateKey).Bind(options);
});
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddOptions();

builder.Services.AddMudServices(opt =>
{
    opt.SnackbarConfiguration.MaxDisplayedSnackbars = 5;
    opt.SnackbarConfiguration.ShowTransitionDuration = 0;
    opt.SnackbarConfiguration.VisibleStateDuration = 3000;
    opt.SnackbarConfiguration.HideTransitionDuration = 1000;
    opt.SnackbarConfiguration.SnackbarVariant = MudBlazor.Variant.Outlined;
    opt.SnackbarConfiguration.PreventDuplicates = false;
});

await builder.Build().RunAsync();
