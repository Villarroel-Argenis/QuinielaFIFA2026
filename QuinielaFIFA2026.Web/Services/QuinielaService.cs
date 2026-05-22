namespace QuinielaFIFA2026.Web.Services;

public class QuinielaService(AppDbContext db)
{
    public async Task<User> GetOrCreateUserAsync(string username)
    {
        var user = await db.Users
            .FirstOrDefaultAsync(u => u.Username == username.Trim());

        if (user is null)
        {
            user = new User { Username = username.Trim() };
            db.Users.Add(user);
            await db.SaveChangesAsync();
        }

        return user;
    }
}