// <copyright file="HexalithClientRouteProvider.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace HexalithClient.Shared.Routes;

using Hexalith.Application.Modules.Routes;

public sealed class HexalithClientRouteProvider : IRouteProvider
{
    /// <inheritdoc/>
    public string MapPath(string path) => string.IsNullOrWhiteSpace(path) ? "/HexalithClient" : path;
}