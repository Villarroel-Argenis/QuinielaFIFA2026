namespace QuinielaFIFA2026.Web.Components.Pages;

public partial class TablaGeneral
{
    [Inject] private SessionService Session { get; set; } = null!;
    [Inject] private QuinielaService QuinielaService { get; set; } = null!;
    [Inject] private NavigationManager Nav { get; set; } = null!;
    [Inject] private IConfiguration Config { get; set; } = null!;

    private List<LeaderboardEntry>? _entries;

    protected override async Task OnInitializedAsync()
    {
        if (!Session.IsLoggedIn)
        {
            Nav.NavigateTo("/");
            return;
        }
        _entries = await QuinielaService.GetTablaAsync(Config);
    }
    
    private int GetPosicion(LeaderboardEntry entry) => 
        (_entries?.IndexOf(entry) ?? 0) + 1;
}