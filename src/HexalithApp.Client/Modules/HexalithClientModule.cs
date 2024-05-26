// <copyright file="HexalithModule.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace HexalithApp.Client.Modules;

using System.Collections.Generic;
using System.Reflection;

using Hexalith.Application.Modules.Modules;

using HexalithClient.Shared.Routes;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Represents the HexalithWeb module for customer management.
/// </summary>
public abstract class HexalithModule : IApplicationModule
{
    /// <inheritdoc/>
    public IEnumerable<string> Dependencies => [];

    /// <inheritdoc/>
    public string Description => "Hexalith web client module";

    /// <inheritdoc/>
    public abstract string Id { get; }

    /// <inheritdoc/>
    public abstract ModuleType ModuleType { get; }

    /// <inheritdoc/>
    public string Name => "Hexalith Client";

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
    public void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddSingleton<HexalithModule>();
        _ = services.AddSingleton<HexalithClientRouteProvider>();
    }
}