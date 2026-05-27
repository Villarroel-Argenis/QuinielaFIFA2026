namespace QuinielaFIFA2026.Web.Auth;

public class PendingLoginService
{
    private readonly Dictionary<string, (ClaimsPrincipal Principal, DateTime Expiry)> _pending = new();

    public string Store(ClaimsPrincipal principal)
    {
        var token = Guid.NewGuid().ToString("N");
        _pending[token] = (principal, DateTime.UtcNow.AddSeconds(30));
        return token;
    }

    public ClaimsPrincipal? Consume(string token)
    {
        if (_pending.TryGetValue(token, out var entry))
        {
            _pending.Remove(token);
            if (entry.Expiry > DateTime.UtcNow)
                return entry.Principal;
        }
        return null;
    }
}