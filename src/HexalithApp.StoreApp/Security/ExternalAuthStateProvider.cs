namespace HexalithApp.StoreApp.Security;

using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components.Authorization;

/// <summary>
/// Provides the authentication state for external authentication.
/// </summary>
public class ExternalAuthStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal _currentUser = new(new ClaimsIdentity());

    /// <summary>
    /// Gets the authentication state asynchronously.
    /// </summary>
    /// <returns>The task representing the asynchronous operation.</returns>
    public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
        Task.FromResult(new AuthenticationState(_currentUser));

    /// <summary>
    /// Logs in the user asynchronously.
    /// </summary>
    /// <returns>The task representing the asynchronous operation.</returns>
    public Task LogInAsync()
    {
        Task<AuthenticationState> loginTask = LogInAsyncCore();
        NotifyAuthenticationStateChanged(loginTask);

        return loginTask;

        async Task<AuthenticationState> LogInAsyncCore()
        {
            ClaimsPrincipal user = await LoginWithExternalProviderAsync();
            _currentUser = user;

            return new AuthenticationState(_currentUser);
        }
    }

    /// <summary>
    /// Logs out the user.
    /// </summary>
    public void Logout()
    {
        _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(
            Task.FromResult(new AuthenticationState(_currentUser)));
    }

    private Task<ClaimsPrincipal> LoginWithExternalProviderAsync()
    {
        /*
            Provide OpenID/MSAL code to authenticate the user. See your identity
            provider's documentation for details.

            Return a new ClaimsPrincipal based on a new ClaimsIdentity.
        */
        ClaimsPrincipal authenticatedUser = new(new ClaimsIdentity());

        return Task.FromResult(authenticatedUser);
    }
}