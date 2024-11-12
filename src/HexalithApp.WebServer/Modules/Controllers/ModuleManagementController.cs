namespace HexalithApp.WebServer.Modules.Controllers;

using System.ComponentModel.DataAnnotations;

using HexalithApp.SharedAssets.Models;
using HexalithApp.SharedAssets.Modules;
using HexalithApp.SharedAssets.Services;

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
    private readonly string _applicationModuleName;
    private readonly Dictionary<string, IModuleService> _modules;

    /// <summary>
    /// Initializes a new instance of the <see cref="ModuleManagementController"/> class.
    /// </summary>
    /// <param name="modules">The collection of module services.</param>
    public ModuleManagementController(IEnumerable<IModuleService> modules)
    {
        ArgumentNullException.ThrowIfNull(modules);
        _modules = modules.ToDictionary(m => m.Name, p => p);
        List<IModuleService> applications = _modules.Values.Where(m => m.IsApplicationModule).ToList();
        if (applications.Count < 1)
        {
            throw new InvalidOperationException("No application module found.");
        }

        if (applications.Count > 1)
        {
            throw new InvalidOperationException("More than one application module found: " + string.Join("; ", applications.Select(p => p.Name)));
        }

        _applicationModuleName = applications[0].Name;
    }

    /// <summary>
    /// Gets the application information.
    /// </summary>
    /// <returns>The application information.</returns>
    [HttpGet]
    [Route(ModuleConstants.ApplicationInformationApi)]
    public Results<BadRequest<ModelStateDictionary>, NotFound<string>, Ok<ModuleInformation>> GetApplicationInformation()
        => GetModuleInformation(_applicationModuleName);

    /// <summary>
    /// Gets the module information.
    /// </summary>
    /// <param name="name">The name of the module.</param>
    /// <returns>The module information.</returns>
    [HttpGet]
    [Route(ModuleConstants.ModuleInformationApi)]
    public Results<BadRequest<ModelStateDictionary>, NotFound<string>, Ok<ModuleInformation>> GetModuleInformation([Required] string name)
    {
        return !ModelState.IsValid
            ? (Results<BadRequest<ModelStateDictionary>, NotFound<string>, Ok<ModuleInformation>>)TypedResults.BadRequest(ModelState)
            : !_modules.TryGetValue(name, out IModuleService? module)
            ? TypedResults.NotFound(
                $"Module {name} not found. Valid module names are: {string.Join("; ", _modules.Select(p => p.Key))}.")
            : TypedResults.Ok(new ModuleInformation(
                module.Name,
                module.Description,
                module.Version,
                module.IsApplicationModule));
    }
}