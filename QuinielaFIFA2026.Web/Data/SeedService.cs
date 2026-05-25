namespace QuinielaFIFA2026.Web.Data;

public static class SeedService
{
    public static async Task SeedAsync(AppDbContext db)
    {
        if (db.Matches.Any()) return;
        var matches = GetMatches();
        db.Matches.AddRange(matches);
        await db.SaveChangesAsync();
    }

    public static async Task UpdateSlotsAsync(AppDbContext db)
    {
        var slots = new Dictionary<string, (string Home, string Away)>
        {
            // Dieciseisavos
            ["M73"] = ("2A", "2B"),
            ["M74"] = ("1E", "3ABCDF"),
            ["M75"] = ("1F", "2C"),
            ["M76"] = ("1C", "2F"),
            ["M77"] = ("1I", "3CDFGH"),
            ["M78"] = ("2E", "2I"),
            ["M79"] = ("1A", "3CEFHI"),
            ["M80"] = ("1L", "3EHIJK"),
            ["M81"] = ("1D", "3BEFIJ"),
            ["M82"] = ("1G", "3AEHIJ"),
            ["M83"] = ("2K", "2L"),
            ["M84"] = ("1H", "2J"),
            ["M85"] = ("1B", "3EFGIJ"),
            ["M86"] = ("1J", "2H"),
            ["M87"] = ("1K", "3DEIJL"),
            ["M88"] = ("2D", "2G"),
            // Octavos
            ["M89"] = ("W74", "W77"),
            ["M90"] = ("W73", "W75"),
            ["M91"] = ("W76", "W78"),
            ["M92"] = ("W79", "W80"),
            ["M93"] = ("W83", "W84"),
            ["M94"] = ("W81", "W82"),
            ["M95"] = ("W86", "W88"),
            ["M96"] = ("W85", "W87"),
            // Cuartos
            ["M97"] = ("W89", "W90"),
            ["M98"] = ("W93", "W94"),
            ["M99"] = ("W91", "W92"),
            ["M100"] = ("W95", "W96"),
            // Semifinales
            ["M101"] = ("W97", "W98"),
            ["M102"] = ("W99", "W100"),
            // Tercer lugar y Final
            ["M103"] = ("RU101", "RU102"),
            ["M104"] = ("W101", "W102"),
        };

        foreach (var (matchNumber, (home, away)) in slots)
        {
            var match = await db.Matches.FirstOrDefaultAsync(m => m.MatchNumber == matchNumber);
            if (match is null) continue;
            match.HomeSlot = home;
            match.AwaySlot = away;
        }

        await db.SaveChangesAsync();
    }

    private static List<Match> GetMatches() => new()
    {
        // ── GRUPO A ──
        new() { MatchNumber="M01", Stage="Grupo A", Group="A", HomeTeam="México",        HomeFlagEmoji="🇲🇽", AwayTeam="Sudáfrica",     AwayFlagEmoji="🇿🇦", MatchDateUtc=new DateTime(2026,6,11,15, 0,0,DateTimeKind.Utc), Venue="Ciudad de México", AllowDraw=true },
        new() { MatchNumber="M02", Stage="Grupo A", Group="A", HomeTeam="Corea del Sur", HomeFlagEmoji="🇰🇷", AwayTeam="República Checa",       AwayFlagEmoji="🇨🇿", MatchDateUtc=new DateTime(2026,6,11,22, 0,0,DateTimeKind.Utc), Venue="Guadalajara",      AllowDraw=true },
        new() { MatchNumber="M03", Stage="Grupo A", Group="A", HomeTeam="República Checa",       HomeFlagEmoji="🇨🇿", AwayTeam="Sudáfrica",     AwayFlagEmoji="🇿🇦", MatchDateUtc=new DateTime(2026,6,18,12, 0,0,DateTimeKind.Utc), Venue="Atlanta",          AllowDraw=true },
        new() { MatchNumber="M04", Stage="Grupo A", Group="A", HomeTeam="México",        HomeFlagEmoji="🇲🇽", AwayTeam="Corea del Sur", AwayFlagEmoji="🇰🇷", MatchDateUtc=new DateTime(2026,6,18,21, 0,0,DateTimeKind.Utc), Venue="Guadalajara",      AllowDraw=true },
        new() { MatchNumber="M05", Stage="Grupo A", Group="A", HomeTeam="República Checa",       HomeFlagEmoji="🇨🇿", AwayTeam="México",        AwayFlagEmoji="🇲🇽", MatchDateUtc=new DateTime(2026,6,24,21, 0,0,DateTimeKind.Utc), Venue="Ciudad de México", AllowDraw=true },
        new() { MatchNumber="M06", Stage="Grupo A", Group="A", HomeTeam="Sudáfrica",     HomeFlagEmoji="🇿🇦", AwayTeam="Corea del Sur", AwayFlagEmoji="🇰🇷", MatchDateUtc=new DateTime(2026,6,24,21, 0,0,DateTimeKind.Utc), Venue="Monterrey",        AllowDraw=true },

        // ── GRUPO B ──
        new() { MatchNumber="M07", Stage="Grupo B", Group="B", HomeTeam="Canadá",             HomeFlagEmoji="🇨🇦", AwayTeam="Bosnia-Herzegovina", AwayFlagEmoji="🇧🇦", MatchDateUtc=new DateTime(2026,6,12,15, 0,0,DateTimeKind.Utc), Venue="Toronto",      AllowDraw=true },
        new() { MatchNumber="M08", Stage="Grupo B", Group="B", HomeTeam="Catar",              HomeFlagEmoji="🇶🇦", AwayTeam="Suiza",              AwayFlagEmoji="🇨🇭", MatchDateUtc=new DateTime(2026,6,13,15, 0,0,DateTimeKind.Utc), Venue="San Francisco", AllowDraw=true },
        new() { MatchNumber="M09", Stage="Grupo B", Group="B", HomeTeam="Suiza",              HomeFlagEmoji="🇨🇭", AwayTeam="Bosnia-Herzegovina", AwayFlagEmoji="🇧🇦", MatchDateUtc=new DateTime(2026,6,18,15, 0,0,DateTimeKind.Utc), Venue="Los Ángeles",   AllowDraw=true },
        new() { MatchNumber="M10", Stage="Grupo B", Group="B", HomeTeam="Canadá",             HomeFlagEmoji="🇨🇦", AwayTeam="Catar",              AwayFlagEmoji="🇶🇦", MatchDateUtc=new DateTime(2026,6,18,18, 0,0,DateTimeKind.Utc), Venue="Vancouver",     AllowDraw=true },
        new() { MatchNumber="M11", Stage="Grupo B", Group="B", HomeTeam="Suiza",              HomeFlagEmoji="🇨🇭", AwayTeam="Canadá",             AwayFlagEmoji="🇨🇦", MatchDateUtc=new DateTime(2026,6,24,15, 0,0,DateTimeKind.Utc), Venue="Vancouver",     AllowDraw=true },
        new() { MatchNumber="M12", Stage="Grupo B", Group="B", HomeTeam="Bosnia-Herzegovina", HomeFlagEmoji="🇧🇦", AwayTeam="Catar",              AwayFlagEmoji="🇶🇦", MatchDateUtc=new DateTime(2026,6,24,15, 0,0,DateTimeKind.Utc), Venue="Seattle",       AllowDraw=true },

        // ── GRUPO C ──
        new() { MatchNumber="M13", Stage="Grupo C", Group="C", HomeTeam="Brasil",    HomeFlagEmoji="🇧🇷", AwayTeam="Marruecos", AwayFlagEmoji="🇲🇦", MatchDateUtc=new DateTime(2026,6,13,18, 0,0,DateTimeKind.Utc), Venue="Nueva York/NJ", AllowDraw=true },
        new() { MatchNumber="M14", Stage="Grupo C", Group="C", HomeTeam="Haití",     HomeFlagEmoji="🇭🇹", AwayTeam="Escocia",   AwayFlagEmoji="🏴󠁧󠁢󠁳󠁣󠁴󠁿", MatchDateUtc=new DateTime(2026,6,13,21, 0,0,DateTimeKind.Utc), Venue="Boston",        AllowDraw=true },
        new() { MatchNumber="M15", Stage="Grupo C", Group="C", HomeTeam="Escocia",   HomeFlagEmoji="🏴󠁧󠁢󠁳󠁣󠁴󠁿", AwayTeam="Marruecos", AwayFlagEmoji="🇲🇦", MatchDateUtc=new DateTime(2026,6,19,18, 0,0,DateTimeKind.Utc), Venue="Boston",        AllowDraw=true },
        new() { MatchNumber="M16", Stage="Grupo C", Group="C", HomeTeam="Brasil",    HomeFlagEmoji="🇧🇷", AwayTeam="Haití",     AwayFlagEmoji="🇭🇹", MatchDateUtc=new DateTime(2026,6,19,20,30,0,DateTimeKind.Utc), Venue="Filadelfia",    AllowDraw=true },
        new() { MatchNumber="M17", Stage="Grupo C", Group="C", HomeTeam="Escocia",   HomeFlagEmoji="🏴󠁧󠁢󠁳󠁣󠁴󠁿", AwayTeam="Brasil",    AwayFlagEmoji="🇧🇷", MatchDateUtc=new DateTime(2026,6,24,18, 0,0,DateTimeKind.Utc), Venue="Miami",         AllowDraw=true },
        new() { MatchNumber="M18", Stage="Grupo C", Group="C", HomeTeam="Marruecos", HomeFlagEmoji="🇲🇦", AwayTeam="Haití",     AwayFlagEmoji="🇭🇹", MatchDateUtc=new DateTime(2026,6,24,18, 0,0,DateTimeKind.Utc), Venue="Atlanta",       AllowDraw=true },

        // ── GRUPO D ──
        new() { MatchNumber="M19", Stage="Grupo D", Group="D", HomeTeam="EUA",       HomeFlagEmoji="🇺🇸", AwayTeam="Paraguay",  AwayFlagEmoji="🇵🇾", MatchDateUtc=new DateTime(2026,6,12,21, 0,0,DateTimeKind.Utc), Venue="Los Ángeles",   AllowDraw=true },
        new() { MatchNumber="M20", Stage="Grupo D", Group="D", HomeTeam="Australia", HomeFlagEmoji="🇦🇺", AwayTeam="Turquía",   AwayFlagEmoji="🇹🇷", MatchDateUtc=new DateTime(2026,6,14, 0, 0,1,DateTimeKind.Utc), Venue="Vancouver",     AllowDraw=true },
        new() { MatchNumber="M21", Stage="Grupo D", Group="D", HomeTeam="EUA",       HomeFlagEmoji="🇺🇸", AwayTeam="Australia", AwayFlagEmoji="🇦🇺", MatchDateUtc=new DateTime(2026,6,19,15, 0,0,DateTimeKind.Utc), Venue="Seattle",       AllowDraw=true },
        new() { MatchNumber="M22", Stage="Grupo D", Group="D", HomeTeam="Turquía",   HomeFlagEmoji="🇹🇷", AwayTeam="Paraguay",  AwayFlagEmoji="🇵🇾", MatchDateUtc=new DateTime(2026,6,19,23, 0,0,DateTimeKind.Utc), Venue="San Francisco", AllowDraw=true },
        new() { MatchNumber="M23", Stage="Grupo D", Group="D", HomeTeam="Turquía",   HomeFlagEmoji="🇹🇷", AwayTeam="EUA",       AwayFlagEmoji="🇺🇸", MatchDateUtc=new DateTime(2026,6,25,22, 0,0,DateTimeKind.Utc), Venue="Los Ángeles",   AllowDraw=true },
        new() { MatchNumber="M24", Stage="Grupo D", Group="D", HomeTeam="Paraguay",  HomeFlagEmoji="🇵🇾", AwayTeam="Australia", AwayFlagEmoji="🇦🇺", MatchDateUtc=new DateTime(2026,6,25,22, 0,0,DateTimeKind.Utc), Venue="San Francisco", AllowDraw=true },

        // ── GRUPO E ──
        new() { MatchNumber="M25", Stage="Grupo E", Group="E", HomeTeam="Alemania",        HomeFlagEmoji="🇩🇪", AwayTeam="Curazao",         AwayFlagEmoji="🇨🇼", MatchDateUtc=new DateTime(2026,6,14,13, 0,0,DateTimeKind.Utc), Venue="Houston",       AllowDraw=true },
        new() { MatchNumber="M26", Stage="Grupo E", Group="E", HomeTeam="Costa de Marfil", HomeFlagEmoji="🇨🇮", AwayTeam="Ecuador",         AwayFlagEmoji="🇪🇨", MatchDateUtc=new DateTime(2026,6,14,19, 0,0,DateTimeKind.Utc), Venue="Filadelfia",    AllowDraw=true },
        new() { MatchNumber="M27", Stage="Grupo E", Group="E", HomeTeam="Alemania",        HomeFlagEmoji="🇩🇪", AwayTeam="Costa de Marfil", AwayFlagEmoji="🇨🇮", MatchDateUtc=new DateTime(2026,6,20,16, 0,0,DateTimeKind.Utc), Venue="Toronto",       AllowDraw=true },
        new() { MatchNumber="M28", Stage="Grupo E", Group="E", HomeTeam="Ecuador",         HomeFlagEmoji="🇪🇨", AwayTeam="Curazao",         AwayFlagEmoji="🇨🇼", MatchDateUtc=new DateTime(2026,6,20,20, 0,0,DateTimeKind.Utc), Venue="Kansas City",   AllowDraw=true },
        new() { MatchNumber="M29", Stage="Grupo E", Group="E", HomeTeam="Ecuador",         HomeFlagEmoji="🇪🇨", AwayTeam="Alemania",        AwayFlagEmoji="🇩🇪", MatchDateUtc=new DateTime(2026,6,25,16, 0,0,DateTimeKind.Utc), Venue="Nueva York/NJ", AllowDraw=true },
        new() { MatchNumber="M30", Stage="Grupo E", Group="E", HomeTeam="Curazao",         HomeFlagEmoji="🇨🇼", AwayTeam="Costa de Marfil", AwayFlagEmoji="🇨🇮", MatchDateUtc=new DateTime(2026,6,25,16, 0,0,DateTimeKind.Utc), Venue="Filadelfia",    AllowDraw=true },

        // ── GRUPO F ──
        new() { MatchNumber="M31", Stage="Grupo F", Group="F", HomeTeam="Países Bajos", HomeFlagEmoji="🇳🇱", AwayTeam="Japón",        AwayFlagEmoji="🇯🇵", MatchDateUtc=new DateTime(2026,6,14,16, 0,0,DateTimeKind.Utc), Venue="Dallas",      AllowDraw=true },
        new() { MatchNumber="M32", Stage="Grupo F", Group="F", HomeTeam="Suecia",       HomeFlagEmoji="🇸🇪", AwayTeam="Túnez",        AwayFlagEmoji="🇹🇳", MatchDateUtc=new DateTime(2026,6,14,22, 0,0,DateTimeKind.Utc), Venue="Monterrey",   AllowDraw=true },
        new() { MatchNumber="M33", Stage="Grupo F", Group="F", HomeTeam="Países Bajos", HomeFlagEmoji="🇳🇱", AwayTeam="Suecia",       AwayFlagEmoji="🇸🇪", MatchDateUtc=new DateTime(2026,6,20,13, 0,0,DateTimeKind.Utc), Venue="Houston",     AllowDraw=true },
        new() { MatchNumber="M34", Stage="Grupo F", Group="F", HomeTeam="Túnez",        HomeFlagEmoji="🇹🇳", AwayTeam="Japón",        AwayFlagEmoji="🇯🇵", MatchDateUtc=new DateTime(2026,6,21, 0, 0,0,DateTimeKind.Utc), Venue="Monterrey",   AllowDraw=true },
        new() { MatchNumber="M35", Stage="Grupo F", Group="F", HomeTeam="Japón",        HomeFlagEmoji="🇯🇵", AwayTeam="Suecia",       AwayFlagEmoji="🇸🇪", MatchDateUtc=new DateTime(2026,6,25,19, 0,0,DateTimeKind.Utc), Venue="Dallas",      AllowDraw=true },
        new() { MatchNumber="M36", Stage="Grupo F", Group="F", HomeTeam="Túnez",        HomeFlagEmoji="🇹🇳", AwayTeam="Países Bajos", AwayFlagEmoji="🇳🇱", MatchDateUtc=new DateTime(2026,6,25,19, 0,0,DateTimeKind.Utc), Venue="Kansas City", AllowDraw=true },

        // ── GRUPO G ──
        new() { MatchNumber="M37", Stage="Grupo G", Group="G", HomeTeam="Bélgica",       HomeFlagEmoji="🇧🇪", AwayTeam="Egipto",        AwayFlagEmoji="🇪🇬", MatchDateUtc=new DateTime(2026,6,15,15, 0,0,DateTimeKind.Utc), Venue="Seattle",     AllowDraw=true },
        new() { MatchNumber="M38", Stage="Grupo G", Group="G", HomeTeam="Irán",          HomeFlagEmoji="🇮🇷", AwayTeam="Nueva Zelanda", AwayFlagEmoji="🇳🇿", MatchDateUtc=new DateTime(2026,6,15,21, 0,0,DateTimeKind.Utc), Venue="Los Ángeles", AllowDraw=true },
        new() { MatchNumber="M39", Stage="Grupo G", Group="G", HomeTeam="Bélgica",       HomeFlagEmoji="🇧🇪", AwayTeam="Irán",          AwayFlagEmoji="🇮🇷", MatchDateUtc=new DateTime(2026,6,21,15, 0,0,DateTimeKind.Utc), Venue="Los Ángeles", AllowDraw=true },
        new() { MatchNumber="M40", Stage="Grupo G", Group="G", HomeTeam="Nueva Zelanda", HomeFlagEmoji="🇳🇿", AwayTeam="Egipto",        AwayFlagEmoji="🇪🇬", MatchDateUtc=new DateTime(2026,6,21,21, 0,0,DateTimeKind.Utc), Venue="Vancouver",   AllowDraw=true },
        new() { MatchNumber="M41", Stage="Grupo G", Group="G", HomeTeam="Nueva Zelanda", HomeFlagEmoji="🇳🇿", AwayTeam="Bélgica",       AwayFlagEmoji="🇧🇪", MatchDateUtc=new DateTime(2026,6,26,23, 0,0,DateTimeKind.Utc), Venue="Vancouver",   AllowDraw=true },
        new() { MatchNumber="M42", Stage="Grupo G", Group="G", HomeTeam="Egipto",        HomeFlagEmoji="🇪🇬", AwayTeam="Irán",          AwayFlagEmoji="🇮🇷", MatchDateUtc=new DateTime(2026,6,26,23, 0,0,DateTimeKind.Utc), Venue="Seattle",     AllowDraw=true },

        // ── GRUPO H ──
        new() { MatchNumber="M43", Stage="Grupo H", Group="H", HomeTeam="España",         HomeFlagEmoji="🇪🇸", AwayTeam="Cabo Verde",     AwayFlagEmoji="🇨🇻", MatchDateUtc=new DateTime(2026,6,15,12, 0,0,DateTimeKind.Utc), Venue="Atlanta",     AllowDraw=true },
        new() { MatchNumber="M44", Stage="Grupo H", Group="H", HomeTeam="Arabia Saudita", HomeFlagEmoji="🇸🇦", AwayTeam="Uruguay",        AwayFlagEmoji="🇺🇾", MatchDateUtc=new DateTime(2026,6,15,18, 0,0,DateTimeKind.Utc), Venue="Miami",       AllowDraw=true },
        new() { MatchNumber="M45", Stage="Grupo H", Group="H", HomeTeam="España",         HomeFlagEmoji="🇪🇸", AwayTeam="Arabia Saudita", AwayFlagEmoji="🇸🇦", MatchDateUtc=new DateTime(2026,6,21,12, 0,0,DateTimeKind.Utc), Venue="Atlanta",     AllowDraw=true },
        new() { MatchNumber="M46", Stage="Grupo H", Group="H", HomeTeam="Uruguay",        HomeFlagEmoji="🇺🇾", AwayTeam="Cabo Verde",     AwayFlagEmoji="🇨🇻", MatchDateUtc=new DateTime(2026,6,21,18, 0,0,DateTimeKind.Utc), Venue="Miami",       AllowDraw=true },
        new() { MatchNumber="M47", Stage="Grupo H", Group="H", HomeTeam="Cabo Verde",     HomeFlagEmoji="🇨🇻", AwayTeam="Arabia Saudita", AwayFlagEmoji="🇸🇦", MatchDateUtc=new DateTime(2026,6,26,20, 0,0,DateTimeKind.Utc), Venue="Houston",     AllowDraw=true },
        new() { MatchNumber="M48", Stage="Grupo H", Group="H", HomeTeam="Uruguay",        HomeFlagEmoji="🇺🇾", AwayTeam="España",         AwayFlagEmoji="🇪🇸", MatchDateUtc=new DateTime(2026,6,26,20, 0,0,DateTimeKind.Utc), Venue="Guadalajara", AllowDraw=true },

        // ── GRUPO I ──
        new() { MatchNumber="M49", Stage="Grupo I", Group="I", HomeTeam="Francia", HomeFlagEmoji="🇫🇷", AwayTeam="Senegal", AwayFlagEmoji="🇸🇳", MatchDateUtc=new DateTime(2026,6,16,15, 0,0,DateTimeKind.Utc), Venue="Nueva York/NJ", AllowDraw=true },
        new() { MatchNumber="M50", Stage="Grupo I", Group="I", HomeTeam="Irak",    HomeFlagEmoji="🇮🇶", AwayTeam="Noruega", AwayFlagEmoji="🇳🇴", MatchDateUtc=new DateTime(2026,6,16,18, 0,0,DateTimeKind.Utc), Venue="Boston",        AllowDraw=true },
        new() { MatchNumber="M51", Stage="Grupo I", Group="I", HomeTeam="Francia", HomeFlagEmoji="🇫🇷", AwayTeam="Irak",    AwayFlagEmoji="🇮🇶", MatchDateUtc=new DateTime(2026,6,22,17, 0,0,DateTimeKind.Utc), Venue="Filadelfia",    AllowDraw=true },
        new() { MatchNumber="M52", Stage="Grupo I", Group="I", HomeTeam="Noruega", HomeFlagEmoji="🇳🇴", AwayTeam="Senegal", AwayFlagEmoji="🇸🇳", MatchDateUtc=new DateTime(2026,6,22,20, 0,0,DateTimeKind.Utc), Venue="Nueva York/NJ", AllowDraw=true },
        new() { MatchNumber="M53", Stage="Grupo I", Group="I", HomeTeam="Noruega", HomeFlagEmoji="🇳🇴", AwayTeam="Francia", AwayFlagEmoji="🇫🇷", MatchDateUtc=new DateTime(2026,6,26,15, 0,0,DateTimeKind.Utc), Venue="Boston",        AllowDraw=true },
        new() { MatchNumber="M54", Stage="Grupo I", Group="I", HomeTeam="Senegal", HomeFlagEmoji="🇸🇳", AwayTeam="Irak",    AwayFlagEmoji="🇮🇶", MatchDateUtc=new DateTime(2026,6,26,15, 0,0,DateTimeKind.Utc), Venue="Toronto",       AllowDraw=true },

        // ── GRUPO J ──
        new() { MatchNumber="M55", Stage="Grupo J", Group="J", HomeTeam="Argentina", HomeFlagEmoji="🇦🇷", AwayTeam="Argelia",   AwayFlagEmoji="🇩🇿", MatchDateUtc=new DateTime(2026,6,16,21, 0,0,DateTimeKind.Utc), Venue="Kansas City",   AllowDraw=true },
        new() { MatchNumber="M56", Stage="Grupo J", Group="J", HomeTeam="Austria",   HomeFlagEmoji="🇦🇹", AwayTeam="Jordania",  AwayFlagEmoji="🇯🇴", MatchDateUtc=new DateTime(2026,6,17, 0, 0,0,DateTimeKind.Utc), Venue="San Francisco", AllowDraw=true },
        new() { MatchNumber="M57", Stage="Grupo J", Group="J", HomeTeam="Argentina", HomeFlagEmoji="🇦🇷", AwayTeam="Austria",   AwayFlagEmoji="🇦🇹", MatchDateUtc=new DateTime(2026,6,22,13, 0,0,DateTimeKind.Utc), Venue="Dallas",        AllowDraw=true },
        new() { MatchNumber="M58", Stage="Grupo J", Group="J", HomeTeam="Jordania",  HomeFlagEmoji="🇯🇴", AwayTeam="Argelia",   AwayFlagEmoji="🇩🇿", MatchDateUtc=new DateTime(2026,6,22,23, 0,0,DateTimeKind.Utc), Venue="San Francisco", AllowDraw=true },
        new() { MatchNumber="M59", Stage="Grupo J", Group="J", HomeTeam="Argelia",   HomeFlagEmoji="🇩🇿", AwayTeam="Austria",   AwayFlagEmoji="🇦🇹", MatchDateUtc=new DateTime(2026,6,27,22, 0,0,DateTimeKind.Utc), Venue="Kansas City",   AllowDraw=true },
        new() { MatchNumber="M60", Stage="Grupo J", Group="J", HomeTeam="Jordania",  HomeFlagEmoji="🇯🇴", AwayTeam="Argentina", AwayFlagEmoji="🇦🇷", MatchDateUtc=new DateTime(2026,6,27,22, 0,0,DateTimeKind.Utc), Venue="Dallas",        AllowDraw=true },

        // ── GRUPO K ──
        new() { MatchNumber="M61", Stage="Grupo K", Group="K", HomeTeam="Portugal",   HomeFlagEmoji="🇵🇹", AwayTeam="RD Congo",   AwayFlagEmoji="🇨🇩", MatchDateUtc=new DateTime(2026,6,17,13, 0,0,DateTimeKind.Utc), Venue="Houston",          AllowDraw=true },
        new() { MatchNumber="M62", Stage="Grupo K", Group="K", HomeTeam="Uzbekistán", HomeFlagEmoji="🇺🇿", AwayTeam="Colombia",   AwayFlagEmoji="🇨🇴", MatchDateUtc=new DateTime(2026,6,17,22, 0,0,DateTimeKind.Utc), Venue="Ciudad de México", AllowDraw=true },
        new() { MatchNumber="M63", Stage="Grupo K", Group="K", HomeTeam="Portugal",   HomeFlagEmoji="🇵🇹", AwayTeam="Uzbekistán", AwayFlagEmoji="🇺🇿", MatchDateUtc=new DateTime(2026,6,23,13, 0,0,DateTimeKind.Utc), Venue="Houston",          AllowDraw=true },
        new() { MatchNumber="M64", Stage="Grupo K", Group="K", HomeTeam="Colombia",   HomeFlagEmoji="🇨🇴", AwayTeam="RD Congo",   AwayFlagEmoji="🇨🇩", MatchDateUtc=new DateTime(2026,6,23,22, 0,0,DateTimeKind.Utc), Venue="Guadalajara",      AllowDraw=true },
        new() { MatchNumber="M65", Stage="Grupo K", Group="K", HomeTeam="Colombia",   HomeFlagEmoji="🇨🇴", AwayTeam="Portugal",   AwayFlagEmoji="🇵🇹", MatchDateUtc=new DateTime(2026,6,27,19,30,0,DateTimeKind.Utc), Venue="Miami",           AllowDraw=true },
        new() { MatchNumber="M66", Stage="Grupo K", Group="K", HomeTeam="RD Congo",   HomeFlagEmoji="🇨🇩", AwayTeam="Uzbekistán", AwayFlagEmoji="🇺🇿", MatchDateUtc=new DateTime(2026,6,27,19,30,0,DateTimeKind.Utc), Venue="Atlanta",          AllowDraw=true },

        // ── GRUPO L ──
        new() { MatchNumber="M67", Stage="Grupo L", Group="L", HomeTeam="Inglaterra", HomeFlagEmoji="🏴󠁧󠁢󠁥󠁮󠁧󠁿", AwayTeam="Croacia",    AwayFlagEmoji="🇭🇷", MatchDateUtc=new DateTime(2026,6,17,16, 0,0,DateTimeKind.Utc), Venue="Dallas",        AllowDraw=true },
        new() { MatchNumber="M68", Stage="Grupo L", Group="L", HomeTeam="Ghana",      HomeFlagEmoji="🇬🇭", AwayTeam="Panamá",     AwayFlagEmoji="🇵🇦", MatchDateUtc=new DateTime(2026,6,17,19, 0,0,DateTimeKind.Utc), Venue="Toronto",       AllowDraw=true },
        new() { MatchNumber="M69", Stage="Grupo L", Group="L", HomeTeam="Inglaterra", HomeFlagEmoji="🏴󠁧󠁢󠁥󠁮󠁧󠁿", AwayTeam="Ghana",      AwayFlagEmoji="🇬🇭", MatchDateUtc=new DateTime(2026,6,23,16, 0,0,DateTimeKind.Utc), Venue="Boston",        AllowDraw=true },
        new() { MatchNumber="M70", Stage="Grupo L", Group="L", HomeTeam="Panamá",     HomeFlagEmoji="🇵🇦", AwayTeam="Croacia",    AwayFlagEmoji="🇭🇷", MatchDateUtc=new DateTime(2026,6,23,19, 0,0,DateTimeKind.Utc), Venue="Toronto",       AllowDraw=true },
        new() { MatchNumber="M71", Stage="Grupo L", Group="L", HomeTeam="Panamá",     HomeFlagEmoji="🇵🇦", AwayTeam="Inglaterra", AwayFlagEmoji="🏴󠁧󠁢󠁥󠁮󠁧󠁿", MatchDateUtc=new DateTime(2026,6,27,17, 0,0,DateTimeKind.Utc), Venue="Nueva York/NJ", AllowDraw=true },
        new() { MatchNumber="M72", Stage="Grupo L", Group="L", HomeTeam="Croacia",    HomeFlagEmoji="🇭🇷", AwayTeam="Ghana",      AwayFlagEmoji="🇬🇭", MatchDateUtc=new DateTime(2026,6,27,17, 0,0,DateTimeKind.Utc), Venue="Filadelfia",    AllowDraw=true },

        // ── DIECISEISAVOS ──
        new() { MatchNumber="M73", Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="2A",     AwaySlot="2B",     MatchDateUtc=new DateTime(2026,6,28,15, 0,0,DateTimeKind.Utc), Venue="Los Ángeles",      AllowDraw=false },
        new() { MatchNumber="M74", Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="1E",     AwaySlot="3ABCDF", MatchDateUtc=new DateTime(2026,6,29,16,30,0,DateTimeKind.Utc), Venue="Boston",           AllowDraw=false },
        new() { MatchNumber="M75", Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="1F",     AwaySlot="2C",     MatchDateUtc=new DateTime(2026,6,29,21, 0,0,DateTimeKind.Utc), Venue="Monterrey",         AllowDraw=false },
        new() { MatchNumber="M76", Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="1C",     AwaySlot="2F",     MatchDateUtc=new DateTime(2026,6,29,13, 0,0,DateTimeKind.Utc), Venue="Houston",           AllowDraw=false },
        new() { MatchNumber="M77", Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="1I",     AwaySlot="3CDFGH", MatchDateUtc=new DateTime(2026,6,30,17, 0,0,DateTimeKind.Utc), Venue="Nueva York/NJ",    AllowDraw=false },
        new() { MatchNumber="M78", Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="2E",     AwaySlot="2I",     MatchDateUtc=new DateTime(2026,6,30,13, 0,0,DateTimeKind.Utc), Venue="Dallas",            AllowDraw=false },
        new() { MatchNumber="M79", Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="1A",     AwaySlot="3CEFHI", MatchDateUtc=new DateTime(2026,6,30,21, 0,0,DateTimeKind.Utc), Venue="Ciudad de México",  AllowDraw=false },
        new() { MatchNumber="M80", Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="1L",     AwaySlot="3EHIJK", MatchDateUtc=new DateTime(2026,7, 1,12, 0,0,DateTimeKind.Utc), Venue="Atlanta",           AllowDraw=false },
        new() { MatchNumber="M81", Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="1D",     AwaySlot="3BEFIJ", MatchDateUtc=new DateTime(2026,7, 1,20, 0,0,DateTimeKind.Utc), Venue="Seattle",           AllowDraw=false },
        new() { MatchNumber="M82", Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="1G",     AwaySlot="3AEHIJ", MatchDateUtc=new DateTime(2026,7, 1,16, 0,0,DateTimeKind.Utc), Venue="San Francisco",     AllowDraw=false },
        new() { MatchNumber="M83", Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="2K",     AwaySlot="2L",     MatchDateUtc=new DateTime(2026,7, 2,19, 0,0,DateTimeKind.Utc), Venue="Los Ángeles",      AllowDraw=false },
        new() { MatchNumber="M84", Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="1H",     AwaySlot="2J",     MatchDateUtc=new DateTime(2026,7, 2,15, 0,0,DateTimeKind.Utc), Venue="Toronto",           AllowDraw=false },
        new() { MatchNumber="M85", Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="1B",     AwaySlot="3EFGIJ", MatchDateUtc=new DateTime(2026,7, 2,23, 0,0,DateTimeKind.Utc), Venue="Vancouver",         AllowDraw=false },
        new() { MatchNumber="M86", Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="1J",     AwaySlot="2H",     MatchDateUtc=new DateTime(2026,7, 3,18, 0,0,DateTimeKind.Utc), Venue="Dallas",            AllowDraw=false },
        new() { MatchNumber="M87", Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="1K",     AwaySlot="3DEIJL", MatchDateUtc=new DateTime(2026,7, 3,21,30,0,DateTimeKind.Utc), Venue="Miami",             AllowDraw=false },
        new() { MatchNumber="M88", Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="2D",     AwaySlot="2G",     MatchDateUtc=new DateTime(2026,7, 3,14, 0,0,DateTimeKind.Utc), Venue="Kansas City",      AllowDraw=false },

        // ── OCTAVOS ──
        new() { MatchNumber="M89",  Stage="Octavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="W74", AwaySlot="W77", MatchDateUtc=new DateTime(2026,7, 4,17,0,0,DateTimeKind.Utc), Venue="Filadelfia",       AllowDraw=false },
        new() { MatchNumber="M90",  Stage="Octavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="W73", AwaySlot="W75", MatchDateUtc=new DateTime(2026,7, 4,13,0,0,DateTimeKind.Utc), Venue="Houston",          AllowDraw=false },
        new() { MatchNumber="M91",  Stage="Octavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="W76", AwaySlot="W78", MatchDateUtc=new DateTime(2026,7, 5,16,0,0,DateTimeKind.Utc), Venue="Nueva York/NJ",    AllowDraw=false },
        new() { MatchNumber="M92",  Stage="Octavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="W79", AwaySlot="W80", MatchDateUtc=new DateTime(2026,7, 5,20,0,0,DateTimeKind.Utc), Venue="Ciudad de México", AllowDraw=false },
        new() { MatchNumber="M93",  Stage="Octavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="W83", AwaySlot="W84", MatchDateUtc=new DateTime(2026,7, 6,15,0,0,DateTimeKind.Utc), Venue="Dallas",           AllowDraw=false },
        new() { MatchNumber="M94",  Stage="Octavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="W81", AwaySlot="W82", MatchDateUtc=new DateTime(2026,7, 6,20,0,0,DateTimeKind.Utc), Venue="Seattle",          AllowDraw=false },
        new() { MatchNumber="M95",  Stage="Octavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="W86", AwaySlot="W88", MatchDateUtc=new DateTime(2026,7, 7,12,0,0,DateTimeKind.Utc), Venue="Atlanta",          AllowDraw=false },
        new() { MatchNumber="M96",  Stage="Octavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="W85", AwaySlot="W87", MatchDateUtc=new DateTime(2026,7, 7,16,0,0,DateTimeKind.Utc), Venue="Vancouver",        AllowDraw=false },

        // ── CUARTOS ──
        new() { MatchNumber="M97",  Stage="Cuartos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="W89", AwaySlot="W90", MatchDateUtc=new DateTime(2026,7, 9,16,0,0,DateTimeKind.Utc), Venue="Boston",      AllowDraw=false },
        new() { MatchNumber="M98",  Stage="Cuartos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="W93", AwaySlot="W94", MatchDateUtc=new DateTime(2026,7,10,15,0,0,DateTimeKind.Utc), Venue="Los Ángeles", AllowDraw=false },
        new() { MatchNumber="M99",  Stage="Cuartos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="W91", AwaySlot="W92", MatchDateUtc=new DateTime(2026,7,11,17,0,0,DateTimeKind.Utc), Venue="Miami",       AllowDraw=false },
        new() { MatchNumber="M100", Stage="Cuartos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="W95", AwaySlot="W96", MatchDateUtc=new DateTime(2026,7,11,21,0,0,DateTimeKind.Utc), Venue="Kansas City", AllowDraw=false },

        // ── SEMIFINALES ──
        new() { MatchNumber="M101", Stage="Semifinal", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="W97",  AwaySlot="W98",  MatchDateUtc=new DateTime(2026,7,14,15,0,0,DateTimeKind.Utc), Venue="Dallas",  AllowDraw=false },
        new() { MatchNumber="M102", Stage="Semifinal", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="W99",  AwaySlot="W100", MatchDateUtc=new DateTime(2026,7,15,15,0,0,DateTimeKind.Utc), Venue="Atlanta", AllowDraw=false },

        // ── TERCER LUGAR Y FINAL ──
        new() { MatchNumber="M103", Stage="Tercer Lugar", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="RU101", AwaySlot="RU102", MatchDateUtc=new DateTime(2026,7,18,17,0,0,DateTimeKind.Utc), Venue="Miami",          AllowDraw=false },
        new() { MatchNumber="M104", Stage="Final",        HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", HomeSlot="W101",  AwaySlot="W102",  MatchDateUtc=new DateTime(2026,7,19,15,0,0,DateTimeKind.Utc), Venue="Nueva York/NJ",  AllowDraw=false },
    };
}