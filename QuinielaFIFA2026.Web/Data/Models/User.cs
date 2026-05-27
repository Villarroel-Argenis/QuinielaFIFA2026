namespace QuinielaFIFA2026.Web.Data.Models;

public enum UserRole { Common, Admin }

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = "";
    public string PasswordHash { get; set; } = "";
    public UserRole Role { get; set; } = UserRole.Common;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<Planilla> Planillas { get; set; } = [];
}