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
}