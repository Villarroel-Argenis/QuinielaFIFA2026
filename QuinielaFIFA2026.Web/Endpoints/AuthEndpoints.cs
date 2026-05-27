namespace QuinielaFIFA2026.Web.Auth;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        app.MapGet("/api/auth/signin", SignInAsync).AllowAnonymous();

        app.MapGet("/api/auth/signout", (Delegate)SignOutAsync);
    }
    
    private static async Task<IResult> SignOutAsync(
        HttpContext http)
    {
        await http.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Results.Redirect("/login");
    }

    private static async Task<IResult> SignInAsync(
      string token,
      string returnUrl,
      PendingLoginService pending,
      HttpContext http)
    {
        Console.WriteLine($"[SIGNIN] token={token}, returnUrl={returnUrl}");
        var principal = pending.Consume(token);
        Console.WriteLine($"[SIGNIN] principal={principal?.Identity?.Name ?? "NULL"}");

        if (principal is null)
            return Results.Redirect("/login");

        await http.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal,
            new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
            });

        return Results.Redirect(returnUrl ?? "/");
    }
}