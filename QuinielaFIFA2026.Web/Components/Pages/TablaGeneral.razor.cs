namespace QuinielaFIFA2026.Web.Components.Pages;

public partial class TablaGeneral
{
    [Inject] private QuinielaService QuinielaService { get; set; } = null!;
    [Inject] private NavigationManager Nav { get; set; } = null!;
    [Inject] private IConfiguration Config { get; set; } = null!;

    [CascadingParameter] private Task<AuthenticationState> AuthState { get; set; } = null!;

    private string _currentUsername = "";

    private List<LeaderboardEntry>? _entries;

    protected override async Task OnInitializedAsync()
    {
        var auth = await AuthState;
        _currentUsername = auth.User.Identity?.Name ?? "";
        _entries = await QuinielaService.GetTablaAsync(Config);
    }
    
    private int GetPosicion(LeaderboardEntry entry) => 
        (_entries?.IndexOf(entry) ?? 0) + 1;
}