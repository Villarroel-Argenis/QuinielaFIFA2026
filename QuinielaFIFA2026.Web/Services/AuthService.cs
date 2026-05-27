namespace QuinielaFIFA2026.Web.Services;

public class AuthService(AppDbContext db)
{
    public async Task<User?> LoginAsync(string username, string password)
    {
        var user = await db.Users.FirstOrDefaultAsync(u => u.Username == username.Trim());
        if (user is null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            return null;
        return user;
    }

    public async Task<(bool Success, string? Error)> RegisterAsync(string username, string password)
    {
        var exists = await db.Users.AnyAsync(u => u.Username == username.Trim());
        if (exists)
            return (false, "El nombre de usuario ya está en uso.");

        db.Users.Add(new User
        {
            Username = username.Trim(),
            PasswordHash = HashPassword(password),
            Role = UserRole.Common
        });
        await db.SaveChangesAsync();
        return (true, null);
    }

    public async Task ResetPasswordAsync(int userId, string newPassword)
    {
        var user = await db.Users.FindAsync(userId);
        if (user is null) return;
        user.PasswordHash = HashPassword(newPassword);
        await db.SaveChangesAsync();
    }

    public static string HashPassword(string password) =>
        BCrypt.Net.BCrypt.HashPassword(password);

    public static ClaimsPrincipal BuildPrincipal(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Username),
            new(ClaimTypes.Role, user.Role.ToString())
        };
        var identity = new ClaimsIdentity(claims, "cookie");
        return new ClaimsPrincipal(identity);
    }
}