namespace QuinielaFIFA2026.Web.Services;

public class QuinielaService(AppDbContext db)
{
    public async Task<User> GetOrCreateUserAsync(string username)
    {
        var user = await db.Users
            .FirstOrDefaultAsync(u => u.Username == username.Trim());

        if (user is not null) return user;
        
        user = new User { Username = username.Trim() };
        db.Users.Add(user);
        await db.SaveChangesAsync();

        return user;
    }
    
   
    public async Task<List<Planilla>> GetUserPlanillasAsync(int userId)
    {
        return await db.Planillas
            .Where(p => p.UserId == userId)
            .Include(p => p.User)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
    }

    public async Task<List<Planilla>> GetPlanillasAsignadasAsync()
    {
        return await db.Planillas
            .Include(p => p.User)
            .Where(p => p.UserId != null)
            .OrderByDescending(p => p.AssignedAt)
            .ToListAsync();
    }
    
    public async Task<(bool Exito, string Mensaje)> VincularPlanillaAsync(string codigo, int userId)
    {
        var planilla = await db.Planillas
            .FirstOrDefaultAsync(p => p.Codigo == codigo);

        if (planilla is null)
            return (false, "Código no encontrado. Verifica e intenta de nuevo.");

        if (planilla.IsAssigned)
            return (false, "Esta planilla ya está vinculada a otro usuario.");

        planilla.UserId = userId;
        planilla.AssignedAt = DateTime.UtcNow;
        await db.SaveChangesAsync();

        return (true, "");
    }

  
    public async Task<Lote> GenerarLoteAsync(int cantidad)
    {
        var lote = new Lote
        {
            Codigo = $"L-{Random.Shared.Next(10000000, 99999999)}",
            Cantidad = cantidad
        };
        db.Lotes.Add(lote);
        await db.SaveChangesAsync();

        var planillas = new List<Planilla>();
        for (int i = 0; i < cantidad; i++)
        {
            string codigo;
            do { codigo = GenerarCodigo(); }
            while (await db.Planillas.AnyAsync(p => p.Codigo == codigo));

            planillas.Add(new Planilla
            {
                Codigo = codigo,
                LoteId = lote.Id
            });
        }
        db.Planillas.AddRange(planillas);
        await db.SaveChangesAsync();

        lote.Planillas = planillas;
        return lote;
    }

    public async Task<List<Lote>> GetLotesAsync()
    {
        return await db.Lotes
            .Include(l => l.Planillas)
            .OrderByDescending(l => l.CreatedAt)
            .ToListAsync();
    }

    private static string GenerarCodigo()
    {
        var numero = Random.Shared.Next(10000000, 99999999);
        return $"P-{numero}";
    }
    
    
    public async Task DesvincularPlanillaAsync(int planillaId)
    {
        var planilla = await db.Planillas
            .Include(p => p.Predictions)
            .FirstOrDefaultAsync(p => p.Id == planillaId);
        if (planilla is null) return;
        db.Predictions.RemoveRange(planilla.Predictions);
        planilla.UserId = null;
        planilla.AssignedAt = null;
        await db.SaveChangesAsync();
    }
    
    public async Task<(bool Exito, string Mensaje)> EliminarLoteAsync(int loteId)
    {
        var lote = await db.Lotes
            .Include(l => l.Planillas)
            .FirstOrDefaultAsync(l => l.Id == loteId);

        if (lote is null) return (false, "Lote no encontrado.");

        if (lote.Planillas.Any(p => p.IsAssigned))
            return (false, "No se puede eliminar el lote porque tiene planillas asignadas.");

        db.Planillas.RemoveRange(lote.Planillas);
        db.Lotes.Remove(lote);
        await db.SaveChangesAsync();

        return (true, "Lote eliminado correctamente.");
    }
    
    public bool IsQuinielaBloqueada(IConfiguration config)
    {
        var fechaStr = config["QuinielaSettings:FechaBloqueo"];
        if (DateTime.TryParse(fechaStr, out var fecha))
            return DateTime.UtcNow >= fecha;
        return false;
    }

    public async Task<List<(Match Match, Prediction? Pred)>> GetPlanillaMatchesAsync(int planillaId)
    {
        var matches = await db.Matches
            .Include(m => m.Result)
            .OrderBy(m => m.Stage)
            .ThenBy(m => m.MatchDateUtc)
            .ToListAsync();

        var preds = await db.Predictions
            .Where(p => p.PlanillaId == planillaId)
            .ToDictionaryAsync(p => p.MatchId);

        return matches
            .Select(m => (m, preds.TryGetValue(m.Id, out var p) ? p : null))
            .ToList();
    }

    public async Task SavePredictionAsync(int planillaId, int matchId, string result)
    {
        var pred = await db.Predictions
            .FirstOrDefaultAsync(p => p.PlanillaId == planillaId && p.MatchId == matchId);

        if (pred is null)
        {
            pred = new Prediction { PlanillaId = planillaId, MatchId = matchId };
            db.Predictions.Add(pred);
        }

        pred.PredictedResult = result;
        pred.UpdatedAt = DateTime.UtcNow;
        await db.SaveChangesAsync();
    }
    
    public async Task<Planilla?> GetPlanillaAsync(int planillaId, int userId)
    {
        return await db.Planillas
            .FirstOrDefaultAsync(p => p.Id == planillaId && p.UserId == userId);
    }
}