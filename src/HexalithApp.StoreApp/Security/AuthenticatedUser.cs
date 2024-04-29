namespace HexalithApp.StoreApp.Security;

using System.Security.Claims;

/// <summary>
/// Represents an authenticated user.
/// </summary>
public class AuthenticatedUser
{
    /// <summary>
    /// Gets or sets the claims principal associated with the authenticated user.
    /// </summary>
    public ClaimsPrincipal Principal { get; set; } = new();
}