namespace QuinielaFIFA2026.Web.Components.Pages;

public partial class MisPlanillas
{
    [Inject] private SessionService Session { get; set; } = null!;
    [Inject] private QuinielaService QuinielaService { get; set; } = null!;
    [Inject] private NavigationManager Nav { get; set; } = null!;

    private List<Planilla>? _planillas;
    private string _codigo = "";
    private string _error = "";
    private string _success = "";
    private bool _loading = false;

    protected override async Task OnInitializedAsync()
    {
        if (!Session.IsLoggedIn)
        {
            Nav.NavigateTo("/");
            return;
        }
        await CargarPlanillasAsync();
    }

    private async Task CargarPlanillasAsync()
    {
        _planillas = await QuinielaService.GetUserPlanillasAsync(Session.CurrentUser!.Id);
    }

    private async Task VincularPlanilla()
    {
        _error = "";
        _success = "";

        if (string.IsNullOrWhiteSpace(_codigo))
        {
            _error = "Ingresa un código de planilla.";
            return;
        }

        _loading = true;
        var resultado = await QuinielaService.VincularPlanillaAsync(_codigo.Trim().ToUpper(), Session.CurrentUser!.Id);

        if (resultado.Exito)
        {
            _success = $"Planilla {_codigo.ToUpper()} vinculada correctamente.";
            _codigo = "";
            await CargarPlanillasAsync();
        }
        else
        {
            _error = resultado.Mensaje;
        }

        _loading = false;
    }
}