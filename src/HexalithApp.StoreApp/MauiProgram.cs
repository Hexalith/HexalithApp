namespace HexalithApp.StoreApp;

using System.Security.Claims;

using Hexalith.UI.Components;
using Hexalith.UI.Components.Helpers;

using HexalithApp.StoreApp.Security;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection.Extensions;
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

        builder.Services.AddAuthorizationCore();
        builder.Services.TryAddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
        builder.Services.AddSingleton<AuthenticatedUser>();
        MauiApp host = builder.Build();

        AuthenticatedUser authenticatedUser = host.Services.GetRequiredService<AuthenticatedUser>();

        /*
        Provide OpenID/MSAL code to authenticate the user. See your identity provider's
        documentation for details.

        The user is represented by a new ClaimsPrincipal based on a new ClaimsIdentity.
        */
        ClaimsPrincipal user = new(new ClaimsIdentity());

        authenticatedUser.Principal = user;

        return host;
    }
}