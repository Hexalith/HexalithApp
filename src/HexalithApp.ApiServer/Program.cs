namespace HexalithApp.ApiServer;

using Hexalith.Application.Modules.Applications;
using Hexalith.Infrastructure.WebApis.Helpers;

using HexalithApp.ApiServer.Modules.Controllers;

/// <summary>
/// The entry point of the application.
/// </summary>
internal static class Program
{
    // TODO Move to a configuration file
    private static readonly string[] _cultures = ["en-US", "fr-FR"];

    /// <summary>
    /// The entry point of the application.
    /// </summary>
    /// <param name="args">The arguments.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public static async Task Main(string[] args)
    {
        WebApplicationBuilder builder = HexalithWebApi.CreateApplication(
            HexalithApplication.ApiServerApplication?.Name ?? throw new InvalidOperationException("No API Server application found."),
            "1.0.0",
            registerActors: HexalithApplication.ApiServerApplication.RegisterActors,
            args);
        _ = builder.Services.AddSingleton<Hexalith.Application.Modules.HexalithClientRouteProvider>();
        WebApplication app = builder.Build();
        _ = app.UseHexalith<ModuleManagementController>(HexalithApplication.ApiServerApplication.Name);
        _ = app.UseRequestLocalization(new RequestLocalizationOptions()
            .AddSupportedCultures(_cultures)
            .AddSupportedUICultures(_cultures));
        await app.RunAsync().ConfigureAwait(false);
    }
}