namespace QuinielaFIFA2026.Web.Components.Pages;

public partial class Login
{
    [Inject] private SessionService Session { get; set; } = null!;
    [Inject] private QuinielaService QuinielaService { get; set; } = null!;
    [Inject] private NavigationManager Nav { get; set; } = null!;
    [Inject] private ProtectedLocalStorage LocalStorage { get; set; } = null!;
    [Inject] private IConfiguration Config { get; set; } = null!;

    private string _username = "";
    private string _adminPass = "";
    private string _error = "";
    private bool _loading = false;
    private bool _showAdmin = false;
    private bool _initialized = false;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && !_initialized)
        {
            _initialized = true;
            try
            {
                var saved = await LocalStorage.GetAsync<string>("qf2026_user");
                if (saved.Success && !string.IsNullOrEmpty(saved.Value))
                {
                    var user = await QuinielaService.GetOrCreateUserAsync(saved.Value);
                    Session.SetUser(user);

                    var isAdmin = await LocalStorage.GetAsync<bool>("qf2026_admin");
                    if (isAdmin.Success && isAdmin.Value) Session.SetAdmin();

                    Nav.NavigateTo("/mis-planillas");
                }
            }
            catch { }
        }
    }

    private async Task HandleLogin()
    {
        _error = "";
        if (string.IsNullOrWhiteSpace(_username)) { _error = "Ingresa tu nombre de usuario."; return; }
        _loading = true;
        var user = await QuinielaService.GetOrCreateUserAsync(_username);
        Session.SetUser(user);
        await LocalStorage.SetAsync("qf2026_user", user.Username);
        await LocalStorage.SetAsync("qf2026_admin", false);
        _loading = false;
        Nav.NavigateTo("/mis-planillas");
    }

    private async Task HandleAdminLogin()
    {
        _error = "";
        if (string.IsNullOrWhiteSpace(_username)) { _error = "Ingresa tu nombre."; return; }
        var expected = Config["AdminSettings:Password"] ?? "Admin@2026";
        if (_adminPass != expected) { _error = "Contraseña incorrecta."; return; }
        _loading = true;
        var user = await QuinielaService.GetOrCreateUserAsync(_username);
        Session.SetUser(user);
        Session.SetAdmin();
        await LocalStorage.SetAsync("qf2026_user", user.Username);
        await LocalStorage.SetAsync("qf2026_admin", true);
        _loading = false;
        Nav.NavigateTo("/admin");
    }

    private async Task OnKeyUp(KeyboardEventArgs e)
    {
        if (e.Key == "Enter")
        {
            if (_showAdmin) await HandleAdminLogin();
            else await HandleLogin();
        }
    }
}