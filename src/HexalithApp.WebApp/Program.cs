namespace HexalithApp.Client;

using Hexalith.Infrastructure.ClientAppOnWasm.Helpers;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

/// <summary>
/// Represents a client application.
/// </summary>
public static class Program
{
    /// <summary>
    /// The entry point of the application.
    /// </summary>
    /// <param name="args">Arguments.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    public static async Task Main(string[] args)
    {
        WebAssemblyHostBuilder builder = WebAssemblyClientHelper.CreateHexalithWasmClient(args);
        WebAssemblyHost app = builder.Build();
        await app.UseHexalithUserDefinedCultureAsync().ConfigureAwait(false);
        await app.RunAsync().ConfigureAwait(false);
    }
}