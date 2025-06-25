// <copyright file="Program.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace HexalithApp.WebServer;

using Hexalith.Application.Modules.Applications;
using Hexalith.Infrastructure.ClientAppOnServer.Helpers;

/// <summary>
/// The entry point of the application.
/// </summary>
/// <exception cref="InvalidOperationException">Thrown when the WebServerApplication is not defined.</exception>
public static class Program
{
    /// <summary>
    /// The entry point of the application.
    /// </summary>
    /// <param name="args">The arguments.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the WebServerApplication is not defined.</exception>
    public static async Task Main(string[] args)
    {
        IWebServerApplication application = HexalithApplication.WebServerApplication ?? throw new InvalidOperationException("WebServerApplication is not defined");
        WebApplicationBuilder builder = ServerSideClientAppHelper.CreateServerSideClientApplication(
            application.Name,
            (_) => { },
            application.SessionCookieName,
            "1.0.0",
            args);
        WebApplication app = builder.Build();
        _ = app.UseHexalithWebApplication<App>();
        await app.RunAsync().ConfigureAwait(false);
    }
}