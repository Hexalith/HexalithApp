// <copyright file="HexalithClientRouteProvider.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace HexalithApp.Shared.Modules.Models;

using Hexalith.Application.Modules.Routes;

/// <summary>
/// Represents the route provider for the HexalithClient module.
/// </summary>
public sealed class HexalithClientRouteProvider : IRouteProvider
{
    /// <inheritdoc/>
    public string MapPath(string path)
        => string.IsNullOrWhiteSpace(path) ? "/hexalith" : path;
}