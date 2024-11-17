namespace HexalithApp.WebServer;

using Hexalith.Application.Modules.Applications;
using Hexalith.Infrastructure.ClientAppOnServer.Helpers;

using HexalithApp.WebServer.Components.Pages;

/// <summary>
/// The entry point of the application.
/// </summary>
public static class Program
{
    // TODO Move to a configuration file
    private static readonly string[] _cultures = ["en-US", "fr-FR"];

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
        _ = app.UseRequestLocalization(new RequestLocalizationOptions()
            .AddSupportedCultures(_cultures)
            .AddSupportedUICultures(_cultures));
        app.Run();
    }
}