namespace QuinielaFIFA2026.Web.Data.Models;

public class Planilla
{
    public int Id { get; set; }
    public string Codigo { get; set; } = "";        // P-12345678
    public int? UserId { get; set; }                // null hasta que se asigne
    public User? User { get; set; }
    public bool IsAssigned => UserId != null;
    public int? LoteId { get; set; }
    public Lote? Lote { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? AssignedAt { get; set; }
    public DateTime? ActivatedAt { get; set; }
    public ICollection<Prediction> Predictions { get; set; } = new List<Prediction>();
    public ICollection<PrediccionClasificacion> PrediccionesClasificacion { get; set; } = new List<PrediccionClasificacion>();
}