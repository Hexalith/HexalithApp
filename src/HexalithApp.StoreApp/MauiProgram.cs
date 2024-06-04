namespace HexalithApp.StoreApp;

using System.Security.Claims;

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