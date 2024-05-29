namespace HexalithApp.Shared.Services;

/// <summary>
/// Represents an module service.
/// </summary>
public interface IModuleService
{
    public string Description { get; }
    public bool IsApplicationModule { get; }
    public string Name { get; }
    public string Version { get; }
}