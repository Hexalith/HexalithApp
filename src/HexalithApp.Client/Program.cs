namespace HexalithApp.Client;

using Hexalith.Infrastructure.ClientAppOnWasm.Helpers;
using Hexalith.UI.Components;
using Hexalith.UI.Components.Helpers;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

internal class Program
{
    private static async Task Main(string[] args)
    {
        WebAssemblyHostBuilder builder = WebAssemblyClientHelper.CreateHexalithWasmClient(args);

        // _ = builder.Services.AddAuthorizationCore();
        // _ = builder.Services.AddCascadingAuthenticationState();
        // _ = builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();
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