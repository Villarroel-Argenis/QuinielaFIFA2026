namespace QuinielaFIFA2026.Web.Components.Pages;

public partial class Login
{
    [Inject] private AuthService AuthService { get; set; } = null!;
    [Inject] private PendingLoginService PendingLogin { get; set; } = null!;
    [Inject] private NavigationManager Nav { get; set; } = null!;

    private string _username = "";
    private string _password = "";
    private string _confirmPassword = "";
    private string _error = "";
    private bool _loading = false;
    private bool _isRegister = false;

    private async Task HandleSubmit()
    {
        _error = "";

        if (string.IsNullOrWhiteSpace(_username) || !IsValidEmail(_username.Trim()))
        {
            _error = "Ingresa un correo electrónico válido.";
            return;
        }

        if (string.IsNullOrWhiteSpace(_password) || _password.Length < 4)
        {
            _error = "La contraseña debe tener al menos 4 caracteres.";
            return;
        }

        _loading = true;

        if (_isRegister)
            await HandleRegister();
        else
            await HandleLogin();

        _loading = false;
    }

    private static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    private async Task HandleLogin()
    {
        var user = await AuthService.LoginAsync(_username, _password);
        if (user is null)
        {
            _error = "Usuario o contraseña incorrectos.";
            return;
        }

        var principal = AuthService.BuildPrincipal(user);
        var token = PendingLogin.Store(principal);
        Nav.NavigateTo($"/api/auth/signin?token={token}&returnUrl=%2Fmis-planillas", forceLoad: true);
    }

    private async Task HandleRegister()
    {
        if (_password != _confirmPassword)
        {
            _error = "Las contraseñas no coinciden.";
            return;
        }

        var (success, error) = await AuthService.RegisterAsync(_username, _password);
        if (!success)
        {
            _error = error ?? "Error al registrar.";
            return;
        }

        var user = await AuthService.LoginAsync(_username, _password);
        if (user is null) return;

        var principal = AuthService.BuildPrincipal(user);
        var token = PendingLogin.Store(principal);
        Nav.NavigateTo($"/api/auth/signin?token={token}&returnUrl=%2Fmis-planillas", forceLoad: true);
    }

    private async Task OnKeyUp(KeyboardEventArgs e)
    {
        if (e.Key == "Enter")
            await HandleSubmit();
    }
}