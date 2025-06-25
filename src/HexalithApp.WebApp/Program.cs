// <copyright file="Program.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace HexalithApp.WebApp;

using Hexalith.Application.Modules;
using Hexalith.Infrastructure.ClientApp;
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
        _ = builder.Services
            .AddSingleton<HexalithClientRouteProvider>();

        _ = builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
            .CreateClient(ClientConstants.FrontApiName));

        WebAssemblyHost app = builder.Build();

        await app.UseHexalithUserDefinedCultureAsync().ConfigureAwait(false);
        await app.RunAsync().ConfigureAwait(false);
    }
}