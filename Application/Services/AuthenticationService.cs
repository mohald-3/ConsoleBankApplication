using System.Security.Cryptography;
using System.Text;

public class AuthenticationService : IAuthenticationService
{
    private readonly Dictionary<string, string> _users = new(); // Stores username and hashed password
    private string _authenticatedUser = null; // Tracks the currently logged-in user

    /// <summary>
    /// Registers a new user with a hashed password.
    /// </summary>
    public bool Register(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return false;

        if (_users.ContainsKey(username))
            return false; // Username already exists

        var hashedPassword = HashPassword(password);
        _users[username] = hashedPassword;
        return true;
    }

    /// <summary>
    /// Logs in a user by verifying the username and password.
    /// </summary>
    public bool Login(string username, string password)
    {
        if (!_users.ContainsKey(username))
            return false;

        var hashedPassword = _users[username];
        if (VerifyPassword(password, hashedPassword))
        {
            _authenticatedUser = username;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Logs out the current user.
    /// </summary>
    public void Logout()
    {
        _authenticatedUser = null;
    }

    /// <summary>
    /// Checks if a user is currently authenticated.
    /// </summary>
    public bool IsAuthenticated()
    {
        return _authenticatedUser != null;
    }

    // Helper Methods

    /// <summary>
    /// Hashes a password using SHA256.
    /// </summary>
    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }

    /// <summary>
    /// Verifies a password against a stored hash.
    /// </summary>
    private bool VerifyPassword(string password, string storedHash)
    {
        var hashedPassword = HashPassword(password);
        return hashedPassword == storedHash;
    }
}
