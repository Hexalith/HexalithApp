namespace HexalithApp.Server;

using Hexalith.Infrastructure.ClientAppOnServer.Helpers;

using HexalithApp.Server.Components;

public static class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = ServerSideClientAppHelper.CreateServerSideClientApplication(
            "HexalithApp",
            "Hexalith",
            "1.0.0",
            registerActors: _ => { },
            args);
        WebApplication app = builder.Build();
        _ = app.UseHexalithWebApplication<App>();

        app.Run();
    }
}