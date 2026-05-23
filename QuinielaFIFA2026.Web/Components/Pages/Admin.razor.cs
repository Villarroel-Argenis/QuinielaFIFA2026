namespace QuinielaFIFA2026.Web.Components.Pages;

public partial class Admin
{
    [Inject] private SessionService Session { get; set; } = null!;
    [Inject] private QuinielaService QuinielaService { get; set; } = null!;
    [Inject] private NavigationManager Nav { get; set; } = null!;

    private int _cantidad = 1;
    private bool _generando = false;
    private List<Lote> _lotes = new();
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
}