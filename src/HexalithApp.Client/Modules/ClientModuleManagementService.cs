namespace HexalithApp.Client.Modules;

using System.Net.Http.Json;
using System.Threading.Tasks;

using HexalithApp.Shared.Modules;
using HexalithApp.Shared.Modules.Models;
using HexalithApp.Shared.Modules.Services;

/// <summary>
/// Client proxy for module management.
/// Implements the <see cref="IModuleManagementService" />.
/// </summary>
/// <seealso cref="IModuleManagementService" />
public class ClientModuleManagementService : IModuleManagementService
{
    private static ModuleInformation? _applicationInformation;
    private readonly HttpClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientModuleManagementService"/> class.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    public ClientModuleManagementService(HttpClient client)
    {
        ArgumentNullException.ThrowIfNull(client);
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<ModuleInformation> GetApplicationInformationAsync()
        => _applicationInformation
            ??= await _client
                .GetFromJsonAsync<ModuleInformation>(ModuleConstants.ApplicationInformationApi)
                .ConfigureAwait(false)
            ?? throw new HttpRequestException("Invalid empty response from " + ModuleConstants.ApplicationInformationApi);

    /// <inheritdoc/>
    public async Task<ModuleInformation> GetModuleInformationAsync(string name)
        => await _client.GetFromJsonAsync<ModuleInformation>(ModuleConstants.ModuleInformationApi).ConfigureAwait(false)
            ?? throw new HttpRequestException("Invalid empty response from " + ModuleConstants.ModuleInformationApi);
}