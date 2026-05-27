namespace QuinielaFIFA2026.Web.Auth;

public class CustomAuthStateProvider(IHttpContextAccessor httpContextAccessor) : AuthenticationStateProvider
{
    private ClaimsPrincipal _currentUser = new(new ClaimsIdentity());

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var httpUser = httpContextAccessor.HttpContext?.User;
        if (_currentUser.Identity?.IsAuthenticated != true && httpUser?.Identity?.IsAuthenticated == true)
            _currentUser = httpUser;
        return Task.FromResult(new AuthenticationState(_currentUser));
    }

    public void NotifyLogin(ClaimsPrincipal principal)
    {
        _currentUser = principal;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public void NotifyLogout()
    {
        _currentUser = new(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}