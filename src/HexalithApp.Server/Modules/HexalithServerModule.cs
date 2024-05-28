// <copyright file="HexalithModule.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace HexalithApp.Server.Modules;

using System.Collections.Generic;
using System.Reflection;

using Hexalith.Application.Modules.Modules;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// The Hexalith server module.
/// Implements the <see cref="IApplicationModule" />.
/// </summary>
/// <seealso cref="IApplicationModule" />
public class HexalithServerModule : IServerApplicationModule
{
    /// <inheritdoc/>
    public IEnumerable<string> Dependencies => [];

    /// <inheritdoc/>
    public string Description => "Hexalith server module";

    /// <inheritdoc/>
    public string Id => "Hexalith.Server";

    /// <inheritdoc/>
    public string Name => "Hexalith server";

    /// <inheritdoc/>
    public int OrderWeight => 0;

    /// <inheritdoc/>
    public string Path => "hexalith";

    /// <inheritdoc/>
    public IEnumerable<Assembly> PresentationAssemblies => [GetType().Assembly];

    /// <inheritdoc/>
    public string Version => "1.0.0";

    /// <inheritdoc/>
    public void AddServices(IServiceCollection services, IConfiguration configuration)
        => services.AddSingleton<HexalithServerModule>();
}