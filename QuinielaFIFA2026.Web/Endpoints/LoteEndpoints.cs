namespace QuinielaFIFA2026.Web.Endpoints;

public static class LoteEndpoints
{
    public static void MapLoteEndpoints(this WebApplication app)
    {
        app.MapGet("/api/lote/{loteId}/pdf", async (int loteId, AppDbContext db, PlanillaPdfService pdfService) =>
        {
            var lote = await db.Lotes
                .Include(l => l.Planillas)
                .FirstOrDefaultAsync(l => l.Id == loteId);

            if (lote is null) return Results.NotFound();

            var partidos = await db.Matches
                .OrderBy(m => m.MatchDateUtc)
                .ToListAsync();

            var pdf = pdfService.GenerarLotePdf(lote, partidos);

            return Results.File(pdf, "application/pdf", $"Lote-{lote.Codigo}.pdf");
        });
    }
}