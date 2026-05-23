namespace QuinielaFIFA2026.Web.Components.Pages;

public partial class PlanillaDetalle
{
    [Parameter] public int PlanillaId { get; set; }

    [Inject] private SessionService Session { get; set; } = null!;
    [Inject] private QuinielaService QuinielaService { get; set; } = null!;
    [Inject] private NavigationManager Nav { get; set; } = null!;
    [Inject] private IConfiguration Config { get; set; } = null!;

    private int Completadas => _matchData.Count(m => m.Pred?.PredictedResult != null);
    private int Total => _matchData.Count;
    private int Pct => Total > 0 ? (int)(Completadas * 100.0 / Total) : 0;
    
    private Planilla? _planilla;
    private List<(Match Match, Prediction? Pred)> _matchData = new();
    
    private List<string> _stages = new();
    private bool _bloqueada = false;

    protected override async Task OnInitializedAsync()
    {
        if (!Session.IsLoggedIn)
        {
            Nav.NavigateTo("/");
            return;
        }

        _planilla = await QuinielaService.GetPlanillaAsync(PlanillaId, Session.CurrentUser!.Id);
        if (_planilla is null)
        {
            Nav.NavigateTo("/mis-planillas");
            return;
        }

        _bloqueada = QuinielaService.IsQuinielaBloqueada(Config);
        _matchData = await QuinielaService.GetPlanillaMatchesAsync(PlanillaId);
        var stagesOrden = new List<string>
        {
            "Grupo A", "Grupo B", "Grupo C", "Grupo D", "Grupo E", "Grupo F",
            "Grupo G", "Grupo H", "Grupo I", "Grupo J", "Grupo K", "Grupo L",
            "Dieciseisavos", "Octavos", "Cuartos", "Semifinal", "Tercer Lugar", "Final"
        };

        _stages = _matchData
            .Select(m => m.Match.Stage)
            .Distinct()
            .OrderBy(s => stagesOrden.IndexOf(s))
            .ToList();
    }

    private async Task Predecir(int matchId, string result)
    {
        if (_bloqueada) return;
        await QuinielaService.SavePredictionAsync(PlanillaId, matchId, result);
        _matchData = await QuinielaService.GetPlanillaMatchesAsync(PlanillaId);
    }
}