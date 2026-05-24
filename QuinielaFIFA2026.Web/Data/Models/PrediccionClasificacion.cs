namespace QuinielaFIFA2026.Web.Data.Models;

public class PrediccionClasificacion
{
    public int Id { get; set; }
    public int PlanillaId { get; set; }
    public Planilla Planilla { get; set; } = null!;
    public string Slot { get; set; } = "";      // "1A", "2B", "3ABCDF", "W73"
    public string? EquipoElegido { get; set; }  // "México", "Brasil", etc.
    public DateTime? UpdatedAt { get; set; }
}