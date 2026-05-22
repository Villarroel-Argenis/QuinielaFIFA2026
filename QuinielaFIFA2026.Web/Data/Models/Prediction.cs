namespace QuinielaFIFA2026.Web.Data.Models;

public class Prediction
{
    public int Id { get; set; }
    public int PlanillaId { get; set; }
    public Planilla Planilla { get; set; } = null!;
    public int MatchId { get; set; }
    public Match Match { get; set; } = null!;
    public string? PredictedResult { get; set; }   // "home" | "draw" | "away"
    public DateTime? UpdatedAt { get; set; }
}