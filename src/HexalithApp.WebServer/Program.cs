namespace HexalithApp.WebServer;

using Hexalith.Application.Modules.Applications;
using Hexalith.Infrastructure.ClientAppOnServer.Helpers;

using HexalithApp.WebServer.Components.Pages;

/// <summary>
/// The entry point of the application.
/// </summary>
public static class Program
{
    /// <summary>
    /// The entry point of the application.
    /// </summary>
    /// <param name="args">The arguments.</param>
    public static void Main(string[] args)
    {
        IWebServerApplication application = HexalithApplication.WebServerApplication ?? throw new InvalidOperationException("WebServerApplication is not defined");
        WebApplicationBuilder builder = ServerSideClientAppHelper.CreateServerSideClientApplication(
            application.Name,
            application.SessionCookieName,
            "1.0.0",
            args);
        WebApplication app = builder.Build();
        _ = app.UseHexalithWebApplication<App>();
        app.Run();
    }
}