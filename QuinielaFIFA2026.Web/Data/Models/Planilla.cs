namespace QuinielaFIFA2026.Web.Data.Models;

public class Planilla
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public string Nombre { get; set; } = "";
    public bool IsActive { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ActivatedAt { get; set; }
    public ICollection<Prediction> Predictions { get; set; } = new List<Prediction>();
}