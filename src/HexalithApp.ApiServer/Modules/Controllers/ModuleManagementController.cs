namespace HexalithApp.ApiServer.Modules.Controllers;

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
    public Results<BadRequest<ModelStateDictionary>, NotFound<string>, Ok<ModuleInformation>> GetApplicationInformation()
        => TypedResults.Ok(new ModuleInformation(
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
    public Results<BadRequest<ModelStateDictionary>, NotFound<string>, Ok<ModuleInformation>> GetModuleInformation([Required] string id)
    {
        return !ModelState.IsValid
            ? (Results<BadRequest<ModelStateDictionary>, NotFound<string>, Ok<ModuleInformation>>)TypedResults.BadRequest(ModelState)
            : !_modules.TryGetValue(id, out IApplicationModule? module)
            ? TypedResults.NotFound(
                $"Module {id} not found. Valid module names are: {string.Join("; ", _modules.Select(p => p.Key))}.")
            : TypedResults.Ok(new ModuleInformation(
                module.Name,
                module.Description,
                module.Version,
                false));
    }
}