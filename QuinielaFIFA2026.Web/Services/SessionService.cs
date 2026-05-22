namespace QuinielaFIFA2026.Web.Services;

public class SessionService
{
    public User? CurrentUser { get; private set; }
    public bool IsLoggedIn => CurrentUser != null;
    public bool IsAdmin { get; private set; }

    public void SetUser(User user)
    {
        CurrentUser = user;
        IsAdmin = false;
    }

    public void SetAdmin() => IsAdmin = true;

    public void Logout()
    {
        CurrentUser = null;
        IsAdmin = false;
    }
}