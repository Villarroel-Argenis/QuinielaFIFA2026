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
    private List<PrediccionClasificacion> _prediccionesClasificacion = new();
    private List<string> _stages = new();
    private bool _bloqueada = false;

    private bool _showConfirmReinicio = false;
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
        _prediccionesClasificacion = await QuinielaService.GetPrediccionesClasificacionAsync(PlanillaId);

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
        StateHasChanged();
    }

    private async Task SaveClasificacion(string slot, string equipo)
    {
        if (_bloqueada) return;
        await QuinielaService.SavePrediccionClasificacionAsync(PlanillaId, slot, equipo);
        _prediccionesClasificacion = await QuinielaService.GetPrediccionesClasificacionAsync(PlanillaId);
        _matchData = await QuinielaService.GetPlanillaMatchesAsync(PlanillaId);
        StateHasChanged();
    }

    private string? GetClasificacion(string? slot) =>
        slot is null ? null : _prediccionesClasificacion.FirstOrDefault(p => p.Slot == slot)?.EquipoElegido;

    private List<string> GetEquiposPorSlot(string? slot)
    {
        if (slot is null) return new();
        if (slot.StartsWith("W") || slot.StartsWith("RU")) return new();
        return SlotService.GetEquiposPosibles(slot);
    }

    private string ResolverEquipo(string? slot)
    {
        if (string.IsNullOrEmpty(slot)) return "TBD";

        if (!slot.StartsWith("W") && !slot.StartsWith("RU"))
            return GetClasificacion(slot) ?? SlotService.GetDescripcion(slot);

        if (slot.StartsWith("W"))
        {
            var matchNum = $"M{slot.Substring(1)}";
            var matchEntry = _matchData.FirstOrDefault(m => m.Match.MatchNumber == matchNum);
            if (matchEntry.Match is null) return $"Gan. {matchNum}";

            var home = ResolverEquipo(matchEntry.Match.HomeSlot);
            var away = ResolverEquipo(matchEntry.Match.AwaySlot);
            var pred = matchEntry.Pred?.PredictedResult;

            if (pred == "home") return home;
            if (pred == "away") return away;

            // Si no hay predicción aún, mostrar referencia al partido
            return $"Gan. {matchNum}";
        }

        if (slot.StartsWith("RU"))
        {
            var matchNum = $"M{slot.Substring(2)}";
            var matchEntry = _matchData.FirstOrDefault(m => m.Match.MatchNumber == matchNum);
            if (matchEntry.Match is null) return $"Per. {matchNum}";

            var home = ResolverEquipo(matchEntry.Match.HomeSlot);
            var away = ResolverEquipo(matchEntry.Match.AwaySlot);
            var pred = matchEntry.Pred?.PredictedResult;

            if (pred == "home") return away;
            if (pred == "away") return home;

            return $"Per. {matchNum}";
        }

        return "TBD";
    }
    private async Task ResetPredecir(int matchId)
    {
        if (_bloqueada) return;
        await QuinielaService.SavePredictionAsync(PlanillaId, matchId, null);
        _matchData = await QuinielaService.GetPlanillaMatchesAsync(PlanillaId);
        StateHasChanged();
    }

    private async Task ResetClasificacion(string slot)
    {
        if (_bloqueada) return;
        await QuinielaService.SavePrediccionClasificacionAsync(PlanillaId, slot, null);
        _prediccionesClasificacion = await QuinielaService.GetPrediccionesClasificacionAsync(PlanillaId);
        _matchData = await QuinielaService.GetPlanillaMatchesAsync(PlanillaId);
        StateHasChanged();
    }

    private async Task EjecutarReinicio()
    {
        if (_bloqueada) return;
        await QuinielaService.ReiniciarPlanillaAsync(PlanillaId);
        _matchData = await QuinielaService.GetPlanillaMatchesAsync(PlanillaId);
        _prediccionesClasificacion = await QuinielaService.GetPrediccionesClasificacionAsync(PlanillaId);
        _showConfirmReinicio = false;
        StateHasChanged();
    }
}