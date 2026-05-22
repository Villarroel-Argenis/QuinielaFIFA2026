namespace QuinielaFIFA2026.Web.Data.Models;

public class Match
{
    public int Id { get; set; }
    public string MatchNumber { get; set; } = "";    // M01, M02...
    public string Stage { get; set; } = "";           // "Grupo A", "Dieciseisavos"...
    public string? Group { get; set; }                // A-L, null en eliminatorias
    public string HomeTeam { get; set; } = "";
    public string AwayTeam { get; set; } = "";
    public DateTime MatchDateUtc { get; set; }
    public string Venue { get; set; } = "";
    public bool AllowDraw { get; set; } = true;

    public MatchResult? Result { get; set; }
    public ICollection<Prediction> Predictions { get; set; } = new List<Prediction>();

    public bool IsLocked => DateTime.UtcNow >= MatchDateUtc;
    public bool HasTeams => HomeTeam != "TBD" && AwayTeam != "TBD";
}