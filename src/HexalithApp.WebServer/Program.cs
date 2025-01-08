namespace HexalithApp.WebServer;

using Hexalith.Application.Modules.Applications;
using Hexalith.Infrastructure.ClientAppOnServer.Helpers;

/// <summary>
/// The entry point of the application.
/// </summary>
public static class Program
{
    /// <summary>
    /// The entry point of the application.
    /// </summary>
    /// <param name="args">The arguments.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public static async Task Main(string[] args)
    {
        IWebServerApplication application = HexalithApplication.WebServerApplication ?? throw new InvalidOperationException("WebServerApplication is not defined");
        WebApplicationBuilder builder = ServerSideClientAppHelper.CreateServerSideClientApplication(
            application.Name,
            (c) => { },
            application.SessionCookieName,
            "1.0.0",
            args);
        WebApplication app = builder.Build();
        _ = app.UseHexalithWebApplication<HexalithApp.WebServer.App>();
        await app.RunAsync().ConfigureAwait(false);
    }
}