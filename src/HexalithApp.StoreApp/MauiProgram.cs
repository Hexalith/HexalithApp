namespace HexalithApp.StoreApp;

using Hexalith.UI.Components;
using Hexalith.UI.Components.Helpers;

using Microsoft.Extensions.Logging;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"));

        builder.Services.AddMauiBlazorWebView();
        _ = builder.Services.AddSingleton(new ApplicationInformation(
                "Hexalith",
                "Hexalith",
                "Hexalith store application",
                "Fiveforty Inc",
                "0.0.1"));
        builder.Services.AddFluentUITheme();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}