// <copyright file="ModuleManagementController.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace HexalithApp.WebServer.Modules.Controllers;

using System.ComponentModel.DataAnnotations;

using Hexalith.Application.Modules;
using Hexalith.Application.Modules.Applications;
using Hexalith.Application.Modules.Models;
using Hexalith.Application.Modules.Modules;
using Hexalith.Application.Modules.Services;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

/// <summary>
/// Module management controller.
/// Implements the <see cref="ControllerBase" />
/// Implements the <see cref="IModuleManagementService" />.
/// </summary>
/// <seealso cref="ControllerBase" />
/// <seealso cref="IModuleManagementService" />
[ApiController]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S6931:ASP.NET controller actions should not have a route template starting with \"/\"", Justification = "Specific")]
public class ModuleManagementController : ControllerBase
{
    private readonly IApplication _application;
    private readonly Dictionary<string, IApplicationModule> _modules;

    /// <summary>
    /// Initializes a new instance of the <see cref="ModuleManagementController"/> class.
    /// </summary>
    /// <param name="modules">The collection of module services.</param>
    /// <param name="application">The application instance.</param>
    public ModuleManagementController(IEnumerable<IApplicationModule> modules, IApplication application)
    {
        ArgumentNullException.ThrowIfNull(modules);
        _modules = modules.ToDictionary(m => m.Id, p => p);
        _application = application;
    }

    /// <summary>
    /// Gets the application information.
    /// </summary>
    /// <returns>The application information.</returns>
    [HttpGet]
    [Route(ModuleConstants.ApplicationInformationApi)]
    public Results<BadRequest<ModelStateDictionary>, NotFound<string>, Ok<ModuleInformation>> GetApplicationInformation() => TypedResults.Ok(new ModuleInformation(
                    _application.Name,
                    _application.Description,
                    _application.Version,
                    true));

    /// <summary>
    /// Gets the module information.
    /// </summary>
    /// <param name="id">The ID of the module.</param>
    /// <returns>The module information.</returns>
    [HttpGet]
    [Route(ModuleConstants.ModuleInformationApi)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "avoid complexity")]
    public Results<BadRequest<ModelStateDictionary>, NotFound<string>, Ok<ModuleInformation>> GetModuleInformation([Required] string id)
    {
        if (!ModelState.IsValid)
        {
            return TypedResults.BadRequest(ModelState);
        }

        return !_modules.TryGetValue(id, out IApplicationModule? module)
            ? (Results<BadRequest<ModelStateDictionary>, NotFound<string>, Ok<ModuleInformation>>)TypedResults.NotFound(
                $"Module {id} not found. Valid module names are: {string.Join("; ", _modules.Select(p => p.Key))}.")
            : (Results<BadRequest<ModelStateDictionary>, NotFound<string>, Ok<ModuleInformation>>)TypedResults.Ok(new ModuleInformation(
            module.Name,
            module.Description,
            module.Version,
            false));
    }
}