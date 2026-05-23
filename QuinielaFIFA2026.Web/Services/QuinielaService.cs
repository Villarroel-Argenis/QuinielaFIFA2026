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
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<List<Planilla>> GetUserPlanillasAsync(int userId)
    {
        return await db.Planillas
            .Where(p => p.UserId == userId)
            .OrderByDescending(p => p.CreatedAt)
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

    public async Task<Planilla> CreatePlanillaAsync(int userId)
    {
        var count = await db.Planillas.CountAsync(p => p.UserId == userId);
        var planilla = new Planilla
        {
            Codigo = GenerarCodigo(),
        };
        db.Planillas.Add(planilla);
        await db.SaveChangesAsync();

        // Crear 104 predicciones en blanco
        var matchIds = await db.Matches.Select(m => m.Id).ToListAsync();
        var predictions = matchIds.Select(mid => new Prediction
        {
            PlanillaId = planilla.Id,
            MatchId = mid
        }).ToList();
        db.Predictions.AddRange(predictions);
        await db.SaveChangesAsync();

        return planilla;
    }
    
    private static string GenerarCodigo()
    {
        var numero = Random.Shared.Next(10000000, 99999999);
        return $"P-{numero}";
    }
}