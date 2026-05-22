namespace QuinielaFIFA2026.Web.Data.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<Planilla> Planillas { get; set; } = new List<Planilla>();
}