namespace QuinielaFIFA2026.Web.Data.Models;

public class MatchResult
{
    public int Id { get; set; }
    public int MatchId { get; set; }
    public Match Match { get; set; } = null!;
    public string Result { get; set; } = "";    // "home" | "draw" | "away"
    public int? HomeScore { get; set; }
    public int? AwayScore { get; set; }
    public DateTime EnteredAt { get; set; } = DateTime.UtcNow;
}