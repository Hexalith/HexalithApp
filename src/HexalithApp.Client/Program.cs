namespace HexalithApp;

using Hexalith.UI.Components;
using Hexalith.UI.Components.Helpers;

using HexalithApp.Client;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

internal class Program
{
    private static async Task Main(string[] args)
    {
        WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

        _ = builder.Services.AddAuthorizationCore();
        _ = builder.Services.AddCascadingAuthenticationState();
        _ = builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();
        _ = builder.Services.AddSingleton(new ApplicationInformation(
                "Hexalith",
                "Hexalith",
                "Hexalith web assembly application",
                "Fiveforty Inc",
                "0.0.1"));
        _ = builder.Services.AddFluentUITheme();
        await builder.Build().RunAsync().ConfigureAwait(false);
    }
}