namespace QuinielaFIFA2026.Web.Components.Pages;

public partial class PlanillaDetalle
{
    [Parameter] public int PlanillaId { get; set; }

    [Inject] private SessionService Session { get; set; } = null!;
    [Inject] private QuinielaService QuinielaService { get; set; } = null!;
    [Inject] private NavigationManager Nav { get; set; } = null!;
    [Inject] private IConfiguration Config { get; set; } = null!;

    private Planilla? _planilla;
    private List<(Match Match, Prediction? Pred)> _matchData = new();
    private List<PrediccionClasificacion> _prediccionesClasificacion = new();
    private List<(DateTime Fecha, List<(Match Match, Prediction? Pred)> Partidos)> _gruposPorFecha = new();
    private List<string> _stagesEliminatorias = new();
    private bool _bloqueada = false;
    private bool _showConfirmReinicio = false;

    private int Completadas => _matchData.Count(m => m.Pred?.PredictedResult != null);
    private int Total => _matchData.Count;
    private int Pct => Total > 0 ? (int)(Completadas * 100.0 / Total) : 0;

    private bool IsAutoSlot(string? slot) =>
            slot != null && (slot.StartsWith("W") || slot.StartsWith("RU"));
            
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

        _gruposPorFecha = _matchData
            .Where(m => m.Match.Stage.StartsWith("Grupo"))
            .GroupBy(m => m.Match.MatchDateUtc.Date)
            .OrderBy(g => g.Key)
            .Select(g => (Fecha: g.Key, Partidos: g.ToList()))
            .ToList();

        var stagesOrden = new List<string>
        {
            "Dieciseisavos", "Octavos", "Cuartos", "Semifinal", "Tercer Lugar", "Final"
        };

        _stagesEliminatorias = _matchData
            .Where(m => !m.Match.Stage.StartsWith("Grupo"))
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

        _gruposPorFecha = _matchData
            .Where(m => m.Match.Stage.StartsWith("Grupo"))
            .GroupBy(m => m.Match.MatchDateUtc.Date)
            .OrderBy(g => g.Key)
            .Select(g => (Fecha: g.Key, Partidos: g.ToList()))
            .ToList();
    }

    private async Task SaveClasificacion(string slot, string equipo)
    {
        if (_bloqueada) return;
        await QuinielaService.SavePrediccionClasificacionAsync(PlanillaId, slot, equipo);
        _prediccionesClasificacion = await QuinielaService.GetPrediccionesClasificacionAsync(PlanillaId);
        _matchData = await QuinielaService.GetPlanillaMatchesAsync(PlanillaId);
    }

    private string? GetClasificacion(string? slot) =>
        slot is null ? null :
        _prediccionesClasificacion.FirstOrDefault(p => p.Slot == slot)?.EquipoElegido;

    private List<string> GetEquiposDisponibles(string slot)
    {
        var usados = _prediccionesClasificacion
            .Where(p => p.Slot != slot && !string.IsNullOrEmpty(p.EquipoElegido))
            .Select(p => p.EquipoElegido!)
            .ToList();

        return SlotService.GetEquiposPosibles(slot, usados);
    }

    private async Task EjecutarReinicio()
    {
        if (_bloqueada) return;
        await QuinielaService.ReiniciarPlanillaAsync(PlanillaId);
        _matchData = await QuinielaService.GetPlanillaMatchesAsync(PlanillaId);
        _prediccionesClasificacion = await QuinielaService.GetPrediccionesClasificacionAsync(PlanillaId);

        _gruposPorFecha = _matchData
            .Where(m => m.Match.Stage.StartsWith("Grupo"))
            .GroupBy(m => m.Match.MatchDateUtc.Date)
            .OrderBy(g => g.Key)
            .Select(g => (Fecha: g.Key, Partidos: g.ToList()))
            .ToList();

        _showConfirmReinicio = false;
        StateHasChanged();
    }

    private string FormatFecha(DateTime fecha)
    {
        var cultura = new CultureInfo("es-ES");
        return fecha.ToString("dddd d 'de' MMMM yyyy", cultura);
    }

    private string FormatHora(DateTime fechaUtc)
    {
        return fechaUtc.ToString("hh:mm tt", new CultureInfo("en-US"));
    }

    private string? ResolveSlot(string? slot)
    {
        if (string.IsNullOrEmpty(slot)) return null;

        // Slot directo seleccionado por el usuario (1A, 2B, 3ABCDF...)
        var directa = GetClasificacion(slot);
        if (!string.IsNullOrEmpty(directa)) return directa;

        // Ganador de partido: W73, W74...
        if (slot.StartsWith("W") && int.TryParse(slot.Substring(1), out var matchNum))
        {
            var matchCode = $"M{matchNum:D2}";
            var match = _matchData.FirstOrDefault(m => m.Match.MatchNumber == matchCode);
            if (match == default) return null;
            var pred = match.Pred?.PredictedResult;
            if (pred == "home") return ResolveSlot(match.Match.HomeSlot);
            if (pred == "away") return ResolveSlot(match.Match.AwaySlot);
        }

        // Perdedor: RU101, RU102
        if (slot.StartsWith("RU") && int.TryParse(slot.Substring(2), out var ruNum))
        {
            var matchCode = $"M{ruNum:D2}";
            var match = _matchData.FirstOrDefault(m => m.Match.MatchNumber == matchCode);
            if (match == default) return null;
            var pred = match.Pred?.PredictedResult;
            if (pred == "home") return ResolveSlot(match.Match.AwaySlot);
            if (pred == "away") return ResolveSlot(match.Match.HomeSlot);
        }

        return null;
    }
}