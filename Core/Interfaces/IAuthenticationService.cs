public interface IAuthenticationService
{
    /// <summary>
    /// Registers a new user with a username and password.
    /// </summary>
    /// <param name="username">The username for the new user.</param>
    /// <param name="password">The password for the new user.</param>
    /// <returns>True if registration is successful, false otherwise.</returns>
    bool Register(string username, string password);

    /// <summary>
    /// Logs in a user with a username and password.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    /// <param name="password">The password of the user.</param>
    /// <returns>True if login is successful, false otherwise.</returns>
    bool Login(string username, string password);

    /// <summary>
    /// Logs out the currently authenticated user.
    /// </summary>
    void Logout();

    /// <summary>
    /// Checks if a user is currently authenticated.
    /// </summary>
    /// <returns>True if a user is authenticated, false otherwise.</returns>
    bool IsAuthenticated();
}
