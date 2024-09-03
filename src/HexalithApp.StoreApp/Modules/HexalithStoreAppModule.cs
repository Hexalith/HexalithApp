// <copyright file="HexalithModule.cs" company="Jérôme Piquot">
//     Copyright (c) Jérôme Piquot. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace HexalithApp.StoreApp.Modules;

using System.Collections.Generic;
using System.Reflection;

using Hexalith.Application.Modules.Modules;

using HexalithApp.Shared.Modules;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Represents the HexalithWeb module for customer management.
/// </summary>
public class HexalithStoreAppModule : IStoreAppApplicationModule
{
    /// <inheritdoc/>
    public IEnumerable<string> Dependencies => [];

    /// <inheritdoc/>
    public string Description => "Hexalith store application module";

    /// <inheritdoc/>
    public string Id => "Hexalith.StoreApp";

    /// <inheritdoc/>
    public string Name => "Hexalith store App";

    /// <inheritdoc/>
    public int OrderWeight => 0;

    /// <inheritdoc/>
    public string Path => "hexalith";

    /// <inheritdoc/>
    public IEnumerable<Assembly> PresentationAssemblies
        => [GetType().Assembly];

    /// <inheritdoc/>
    public string Version => "1.0.0";

    /// <inheritdoc/>
    public static void AddServices(IServiceCollection services, IConfiguration configuration) =>
        _ = services.AddSingleton<HexalithClientRouteProvider>();

    public void UseModule(object builder) => throw new NotImplementedException();
}