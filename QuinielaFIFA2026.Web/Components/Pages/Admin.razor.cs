namespace QuinielaFIFA2026.Web.Components.Pages;

public partial class Admin
{
    [Inject] private SessionService Session { get; set; } = null!;
    [Inject] private QuinielaService QuinielaService { get; set; } = null!;
    [Inject] private NavigationManager Nav { get; set; } = null!;

    private List<(Match Match, MatchResult? Result)> _allMatches = [];

    private int _cantidad = 1;
    private bool _generando = false;
    private List<Lote> _lotes = [];
    private Lote? _ultimoLote;
    private List<Planilla>? _planillasAsignadas;
    private bool _showConfirm = false;
    private Planilla? _planillaSeleccionada;

    private bool _showConfirmLote = false;
    private Lote? _loteSeleccionado;
    private string _errorLote = "";
    
    private void ConfirmarEliminarLote(Lote lote)
    {
        _loteSeleccionado = lote;
        _showConfirmLote = true;
    }
    
    private async Task EjecutarEliminarLote()
    {
        if (_loteSeleccionado is null) return;
        var resultado = await QuinielaService.EliminarLoteAsync(_loteSeleccionado.Id);
        if (resultado.Exito)
        {
            _lotes = await QuinielaService.GetLotesAsync();
            _showConfirmLote = false;
            _loteSeleccionado = null;
            _errorLote = "";
        }
        else
        {
            _errorLote = resultado.Mensaje;
        }
    }
    
    protected override async Task OnInitializedAsync()
    {
        if (!Session.IsLoggedIn || !Session.IsAdmin)
        {
            Nav.NavigateTo("/");
            return;
        }
        _lotes = await QuinielaService.GetLotesAsync();
        _allMatches = await QuinielaService.GetAllMatchesWithResultsAsync();

        await CargarPlanillasAsignadasAsync();
    }

    private async Task CargarPlanillasAsignadasAsync()
    {
        _planillasAsignadas = await QuinielaService.GetPlanillasAsignadasAsync();
    }

    private async Task GenerarPlanillas()
    {
        _generando = true;
        _ultimoLote = await QuinielaService.GenerarLoteAsync(_cantidad);
        _lotes = await QuinielaService.GetLotesAsync();
        _generando = false;
    }

    private void ConfirmarDesvincular(Planilla planilla)
    {
        _planillaSeleccionada = planilla;
        _showConfirm = true;
    }

    private async Task EjecutarDesvincular()
    {
        if (_planillaSeleccionada is null) return;
        await QuinielaService.DesvincularPlanillaAsync(_planillaSeleccionada.Id);
        _showConfirm = false;
        _planillaSeleccionada = null;
        await CargarPlanillasAsignadasAsync();
    }

    private async Task GuardarResultado(int matchId, string result)
    {
        await QuinielaService.SaveMatchResultAsync(matchId, result);
        _allMatches = await QuinielaService.GetAllMatchesWithResultsAsync();
    }

    private async Task AsignarEquipo(int matchId, bool isHome, string equipo)
    {
        await QuinielaService.UpdateMatchTeamAsync(matchId, isHome, equipo);
        _allMatches = await QuinielaService.GetAllMatchesWithResultsAsync();
    }

    private List<string> GetEquiposSlot(string? slot)
        => string.IsNullOrEmpty(slot) ? new() : SlotService.GetEquiposPosibles(slot);

    private IEnumerable<string> GetStagesOrdenados() =>
        _allMatches.Select(m => m.Match.Stage).Distinct()
            .OrderBy(s => new List<string>
            {
            "Grupo A","Grupo B","Grupo C","Grupo D","Grupo E","Grupo F",
            "Grupo G","Grupo H","Grupo I","Grupo J","Grupo K","Grupo L",
            "Dieciseisavos","Octavos","Cuartos","Semifinal","Tercer Lugar","Final"
            }.IndexOf(s));

    private string? ResolveOfficialTeam(string? slot)
    {
        if (string.IsNullOrEmpty(slot)) return null;

        if (slot.StartsWith("W") && int.TryParse(slot.Substring(1), out var matchNum))
        {
            var entry = _allMatches.FirstOrDefault(m => m.Match.MatchNumber == $"M{matchNum:D2}");
            if (entry == default) return null;
            return entry.Result?.Result switch
            {
                "home" => entry.Match.HomeTeam != "TBD" ? entry.Match.HomeTeam : ResolveOfficialTeam(entry.Match.HomeSlot),
                "away" => entry.Match.AwayTeam != "TBD" ? entry.Match.AwayTeam : ResolveOfficialTeam(entry.Match.AwaySlot),
                _ => null
            };
        }

        if (slot.StartsWith("RU") && int.TryParse(slot.Substring(2), out var ruNum))
        {
            var entry = _allMatches.FirstOrDefault(m => m.Match.MatchNumber == $"M{ruNum:D2}");
            if (entry == default) return null;
            return entry.Result?.Result switch
            {
                "home" => entry.Match.AwayTeam != "TBD" ? entry.Match.AwayTeam : ResolveOfficialTeam(entry.Match.AwaySlot),
                "away" => entry.Match.HomeTeam != "TBD" ? entry.Match.HomeTeam : ResolveOfficialTeam(entry.Match.HomeSlot),
                _ => null
            };
        }

        return null;
    }

    private string GetDisplayTeam(Match match, bool isHome) =>
        isHome
            ? (match.HomeTeam != "TBD" ? match.HomeTeam
                : ResolveOfficialTeam(match.HomeSlot) ?? SlotService.GetDescripcion(match.HomeSlot))
            : (match.AwayTeam != "TBD" ? match.AwayTeam
                : ResolveOfficialTeam(match.AwaySlot) ?? SlotService.GetDescripcion(match.AwaySlot));

    private string GetDisplayFlagUrl(Match match, bool isHome)
    {
        if (isHome)
        {
            if (match.HomeTeam != "TBD") return SlotService.GetFlagUrl(match.HomeTeam);
            var t = ResolveOfficialTeam(match.HomeSlot);
            return SlotService.GetFlagUrl(t ?? "");
        }
        if (match.AwayTeam != "TBD") return SlotService.GetFlagUrl(match.AwayTeam);
        var t2 = ResolveOfficialTeam(match.AwaySlot);
        return SlotService.GetFlagUrl(t2 ?? "");
    }

    private bool _showConfirmResetAll = false;

    private async Task ResetearResultado(int matchId)
    {
        await QuinielaService.ResetearResultadoAsync(matchId);
        _allMatches = await QuinielaService.GetAllMatchesWithResultsAsync();
    }

    private async Task ResetearTodosLosResultados()
    {
        await QuinielaService.ResetearTodosLosResultadosAsync();
        _allMatches = await QuinielaService.GetAllMatchesWithResultsAsync();
        _showConfirmResetAll = false;
    }
}