using QuinielaFIFA2026.Web.Data.Models;

namespace QuinielaFIFA2026.Web.Data;

public static class SeedService
{
    public static async Task SeedAsync(AppDbContext db)
    {
        if (db.Matches.Any()) return;

        var matches = new List<Match>
        {
            // ── GRUPO A ──
            new() { MatchNumber="M01", Stage="Grupo A", Group="A", HomeTeam="México",        HomeFlagEmoji="🇲🇽", AwayTeam="Sudáfrica",     AwayFlagEmoji="🇿🇦", MatchDateUtc=new DateTime(2026,6,11,21,0,0,DateTimeKind.Utc), Venue="Ciudad de México", AllowDraw=true },
            new() { MatchNumber="M02", Stage="Grupo A", Group="A", HomeTeam="Corea del Sur", HomeFlagEmoji="🇰🇷", AwayTeam="Chequia",       AwayFlagEmoji="🇨🇿", MatchDateUtc=new DateTime(2026,6,12, 4,0,0,DateTimeKind.Utc), Venue="Guadalajara",      AllowDraw=true },
            new() { MatchNumber="M03", Stage="Grupo A", Group="A", HomeTeam="Chequia",       HomeFlagEmoji="🇨🇿", AwayTeam="Sudáfrica",     AwayFlagEmoji="🇿🇦", MatchDateUtc=new DateTime(2026,6,18,17,0,0,DateTimeKind.Utc), Venue="Atlanta",           AllowDraw=true },
            new() { MatchNumber="M04", Stage="Grupo A", Group="A", HomeTeam="México",        HomeFlagEmoji="🇲🇽", AwayTeam="Corea del Sur", AwayFlagEmoji="🇰🇷", MatchDateUtc=new DateTime(2026,6,19, 3,0,0,DateTimeKind.Utc), Venue="Guadalajara",      AllowDraw=true },
            new() { MatchNumber="M05", Stage="Grupo A", Group="A", HomeTeam="Chequia",       HomeFlagEmoji="🇨🇿", AwayTeam="México",        AwayFlagEmoji="🇲🇽", MatchDateUtc=new DateTime(2026,6,25, 3,0,0,DateTimeKind.Utc), Venue="Ciudad de México", AllowDraw=true },
            new() { MatchNumber="M06", Stage="Grupo A", Group="A", HomeTeam="Sudáfrica",     HomeFlagEmoji="🇿🇦", AwayTeam="Corea del Sur", AwayFlagEmoji="🇰🇷", MatchDateUtc=new DateTime(2026,6,25, 3,0,0,DateTimeKind.Utc), Venue="Monterrey",        AllowDraw=true },

            // ── GRUPO B ──
            new() { MatchNumber="M07", Stage="Grupo B", Group="B", HomeTeam="Canadá",             HomeFlagEmoji="🇨🇦", AwayTeam="Bosnia-Herzegovina", AwayFlagEmoji="🇧🇦", MatchDateUtc=new DateTime(2026,6,12,20,0,0,DateTimeKind.Utc), Venue="Toronto",      AllowDraw=true },
            new() { MatchNumber="M08", Stage="Grupo B", Group="B", HomeTeam="Catar",              HomeFlagEmoji="🇶🇦", AwayTeam="Suiza",              AwayFlagEmoji="🇨🇭", MatchDateUtc=new DateTime(2026,6,13,23,0,0,DateTimeKind.Utc), Venue="San Francisco", AllowDraw=true },
            new() { MatchNumber="M09", Stage="Grupo B", Group="B", HomeTeam="Suiza",              HomeFlagEmoji="🇨🇭", AwayTeam="Bosnia-Herzegovina", AwayFlagEmoji="🇧🇦", MatchDateUtc=new DateTime(2026,6,18,23,0,0,DateTimeKind.Utc), Venue="Los Ángeles",  AllowDraw=true },
            new() { MatchNumber="M10", Stage="Grupo B", Group="B", HomeTeam="Canadá",             HomeFlagEmoji="🇨🇦", AwayTeam="Catar",              AwayFlagEmoji="🇶🇦", MatchDateUtc=new DateTime(2026,6,19, 2,0,0,DateTimeKind.Utc), Venue="Vancouver",     AllowDraw=true },
            new() { MatchNumber="M11", Stage="Grupo B", Group="B", HomeTeam="Suiza",              HomeFlagEmoji="🇨🇭", AwayTeam="Canadá",             AwayFlagEmoji="🇨🇦", MatchDateUtc=new DateTime(2026,6,24,23,0,0,DateTimeKind.Utc), Venue="Vancouver",     AllowDraw=true },
            new() { MatchNumber="M12", Stage="Grupo B", Group="B", HomeTeam="Bosnia-Herzegovina", HomeFlagEmoji="🇧🇦", AwayTeam="Catar",              AwayFlagEmoji="🇶🇦", MatchDateUtc=new DateTime(2026,6,24,23,0,0,DateTimeKind.Utc), Venue="Seattle",       AllowDraw=true },

            // ── GRUPO C ──
            new() { MatchNumber="M13", Stage="Grupo C", Group="C", HomeTeam="Brasil",    HomeFlagEmoji="🇧🇷", AwayTeam="Marruecos", AwayFlagEmoji="🇲🇦", MatchDateUtc=new DateTime(2026,6,13,23,0,0,DateTimeKind.Utc), Venue="Nueva York/NJ", AllowDraw=true },
            new() { MatchNumber="M14", Stage="Grupo C", Group="C", HomeTeam="Haití",     HomeFlagEmoji="🇭🇹", AwayTeam="Escocia",   AwayFlagEmoji="🏴󠁧󠁢󠁳󠁣󠁴󠁿", MatchDateUtc=new DateTime(2026,6,14, 2,0,0,DateTimeKind.Utc), Venue="Boston",        AllowDraw=true },
            new() { MatchNumber="M15", Stage="Grupo C", Group="C", HomeTeam="Escocia",   HomeFlagEmoji="🏴󠁧󠁢󠁳󠁣󠁴󠁿", AwayTeam="Marruecos", AwayFlagEmoji="🇲🇦", MatchDateUtc=new DateTime(2026,6,19,23,0,0,DateTimeKind.Utc), Venue="Boston",        AllowDraw=true },
            new() { MatchNumber="M16", Stage="Grupo C", Group="C", HomeTeam="Brasil",    HomeFlagEmoji="🇧🇷", AwayTeam="Haití",     AwayFlagEmoji="🇭🇹", MatchDateUtc=new DateTime(2026,6,20, 2,0,0,DateTimeKind.Utc), Venue="Filadelfia",    AllowDraw=true },
            new() { MatchNumber="M17", Stage="Grupo C", Group="C", HomeTeam="Escocia",   HomeFlagEmoji="🏴󠁧󠁢󠁳󠁣󠁴󠁿", AwayTeam="Brasil",    AwayFlagEmoji="🇧🇷", MatchDateUtc=new DateTime(2026,6,24,23,0,0,DateTimeKind.Utc), Venue="Miami",         AllowDraw=true },
            new() { MatchNumber="M18", Stage="Grupo C", Group="C", HomeTeam="Marruecos", HomeFlagEmoji="🇲🇦", AwayTeam="Haití",     AwayFlagEmoji="🇭🇹", MatchDateUtc=new DateTime(2026,6,24,23,0,0,DateTimeKind.Utc), Venue="Atlanta",       AllowDraw=true },

            // ── GRUPO D ──
            new() { MatchNumber="M19", Stage="Grupo D", Group="D", HomeTeam="EUA",       HomeFlagEmoji="🇺🇸", AwayTeam="Paraguay",  AwayFlagEmoji="🇵🇾", MatchDateUtc=new DateTime(2026,6,13, 5,0,0,DateTimeKind.Utc), Venue="Los Ángeles",   AllowDraw=true },
            new() { MatchNumber="M20", Stage="Grupo D", Group="D", HomeTeam="Australia", HomeFlagEmoji="🇦🇺", AwayTeam="Turquía",   AwayFlagEmoji="🇹🇷", MatchDateUtc=new DateTime(2026,6,14, 8,0,0,DateTimeKind.Utc), Venue="Vancouver",     AllowDraw=true },
            new() { MatchNumber="M21", Stage="Grupo D", Group="D", HomeTeam="EUA",       HomeFlagEmoji="🇺🇸", AwayTeam="Australia", AwayFlagEmoji="🇦🇺", MatchDateUtc=new DateTime(2026,6,19,23,0,0,DateTimeKind.Utc), Venue="Seattle",       AllowDraw=true },
            new() { MatchNumber="M22", Stage="Grupo D", Group="D", HomeTeam="Turquía",   HomeFlagEmoji="🇹🇷", AwayTeam="Paraguay",  AwayFlagEmoji="🇵🇾", MatchDateUtc=new DateTime(2026,6,20, 8,0,0,DateTimeKind.Utc), Venue="San Francisco", AllowDraw=true },
            new() { MatchNumber="M23", Stage="Grupo D", Group="D", HomeTeam="Turquía",   HomeFlagEmoji="🇹🇷", AwayTeam="EUA",       AwayFlagEmoji="🇺🇸", MatchDateUtc=new DateTime(2026,6,26, 6,0,0,DateTimeKind.Utc), Venue="Los Ángeles",   AllowDraw=true },
            new() { MatchNumber="M24", Stage="Grupo D", Group="D", HomeTeam="Paraguay",  HomeFlagEmoji="🇵🇾", AwayTeam="Australia", AwayFlagEmoji="🇦🇺", MatchDateUtc=new DateTime(2026,6,26, 6,0,0,DateTimeKind.Utc), Venue="San Francisco", AllowDraw=true },

            // ── GRUPO E ──
            new() { MatchNumber="M25", Stage="Grupo E", Group="E", HomeTeam="Alemania",        HomeFlagEmoji="🇩🇪", AwayTeam="Curazao",         AwayFlagEmoji="🇨🇼", MatchDateUtc=new DateTime(2026,6,14,19,0,0,DateTimeKind.Utc), Venue="Houston",       AllowDraw=true },
            new() { MatchNumber="M26", Stage="Grupo E", Group="E", HomeTeam="Costa de Marfil", HomeFlagEmoji="🇨🇮", AwayTeam="Ecuador",         AwayFlagEmoji="🇪🇨", MatchDateUtc=new DateTime(2026,6,15, 0,0,0,DateTimeKind.Utc), Venue="Filadelfia",    AllowDraw=true },
            new() { MatchNumber="M27", Stage="Grupo E", Group="E", HomeTeam="Alemania",        HomeFlagEmoji="🇩🇪", AwayTeam="Costa de Marfil", AwayFlagEmoji="🇨🇮", MatchDateUtc=new DateTime(2026,6,20,21,0,0,DateTimeKind.Utc), Venue="Toronto",       AllowDraw=true },
            new() { MatchNumber="M28", Stage="Grupo E", Group="E", HomeTeam="Ecuador",         HomeFlagEmoji="🇪🇨", AwayTeam="Curazao",         AwayFlagEmoji="🇨🇼", MatchDateUtc=new DateTime(2026,6,21, 4,0,0,DateTimeKind.Utc), Venue="Kansas City",   AllowDraw=true },
            new() { MatchNumber="M29", Stage="Grupo E", Group="E", HomeTeam="Ecuador",         HomeFlagEmoji="🇪🇨", AwayTeam="Alemania",        AwayFlagEmoji="🇩🇪", MatchDateUtc=new DateTime(2026,6,25,21,0,0,DateTimeKind.Utc), Venue="Nueva York/NJ", AllowDraw=true },
            new() { MatchNumber="M30", Stage="Grupo E", Group="E", HomeTeam="Curazao",         HomeFlagEmoji="🇨🇼", AwayTeam="Costa de Marfil", AwayFlagEmoji="🇨🇮", MatchDateUtc=new DateTime(2026,6,25,21,0,0,DateTimeKind.Utc), Venue="Filadelfia",    AllowDraw=true },

            // ── GRUPO F ──
            new() { MatchNumber="M31", Stage="Grupo F", Group="F", HomeTeam="Países Bajos", HomeFlagEmoji="🇳🇱", AwayTeam="Japón",        AwayFlagEmoji="🇯🇵", MatchDateUtc=new DateTime(2026,6,14,22,0,0,DateTimeKind.Utc), Venue="Dallas",      AllowDraw=true },
            new() { MatchNumber="M32", Stage="Grupo F", Group="F", HomeTeam="Suecia",       HomeFlagEmoji="🇸🇪", AwayTeam="Túnez",        AwayFlagEmoji="🇹🇳", MatchDateUtc=new DateTime(2026,6,15, 4,0,0,DateTimeKind.Utc), Venue="Monterrey",   AllowDraw=true },
            new() { MatchNumber="M33", Stage="Grupo F", Group="F", HomeTeam="Países Bajos", HomeFlagEmoji="🇳🇱", AwayTeam="Suecia",       AwayFlagEmoji="🇸🇪", MatchDateUtc=new DateTime(2026,6,20,19,0,0,DateTimeKind.Utc), Venue="Houston",     AllowDraw=true },
            new() { MatchNumber="M34", Stage="Grupo F", Group="F", HomeTeam="Túnez",        HomeFlagEmoji="🇹🇳", AwayTeam="Japón",        AwayFlagEmoji="🇯🇵", MatchDateUtc=new DateTime(2026,6,21, 6,0,0,DateTimeKind.Utc), Venue="Monterrey",   AllowDraw=true },
            new() { MatchNumber="M35", Stage="Grupo F", Group="F", HomeTeam="Japón",        HomeFlagEmoji="🇯🇵", AwayTeam="Suecia",       AwayFlagEmoji="🇸🇪", MatchDateUtc=new DateTime(2026,6,26, 1,0,0,DateTimeKind.Utc), Venue="Dallas",      AllowDraw=true },
            new() { MatchNumber="M36", Stage="Grupo F", Group="F", HomeTeam="Túnez",        HomeFlagEmoji="🇹🇳", AwayTeam="Países Bajos", AwayFlagEmoji="🇳🇱", MatchDateUtc=new DateTime(2026,6,26, 1,0,0,DateTimeKind.Utc), Venue="Kansas City", AllowDraw=true },

            // ── GRUPO G ──
            new() { MatchNumber="M37", Stage="Grupo G", Group="G", HomeTeam="Bélgica",       HomeFlagEmoji="🇧🇪", AwayTeam="Egipto",        AwayFlagEmoji="🇪🇬", MatchDateUtc=new DateTime(2026,6,15,23,0,0,DateTimeKind.Utc), Venue="Vancouver",   AllowDraw=true },
            new() { MatchNumber="M38", Stage="Grupo G", Group="G", HomeTeam="Irán",          HomeFlagEmoji="🇮🇷", AwayTeam="Nueva Zelanda", AwayFlagEmoji="🇳🇿", MatchDateUtc=new DateTime(2026,6,16, 5,0,0,DateTimeKind.Utc), Venue="Los Ángeles", AllowDraw=true },
            new() { MatchNumber="M39", Stage="Grupo G", Group="G", HomeTeam="Bélgica",       HomeFlagEmoji="🇧🇪", AwayTeam="Irán",          AwayFlagEmoji="🇮🇷", MatchDateUtc=new DateTime(2026,6,21,23,0,0,DateTimeKind.Utc), Venue="Los Ángeles", AllowDraw=true },
            new() { MatchNumber="M40", Stage="Grupo G", Group="G", HomeTeam="Nueva Zelanda", HomeFlagEmoji="🇳🇿", AwayTeam="Egipto",        AwayFlagEmoji="🇪🇬", MatchDateUtc=new DateTime(2026,6,22, 5,0,0,DateTimeKind.Utc), Venue="Vancouver",   AllowDraw=true },
            new() { MatchNumber="M41", Stage="Grupo G", Group="G", HomeTeam="Nueva Zelanda", HomeFlagEmoji="🇳🇿", AwayTeam="Bélgica",       AwayFlagEmoji="🇧🇪", MatchDateUtc=new DateTime(2026,6,27, 7,0,0,DateTimeKind.Utc), Venue="Vancouver",   AllowDraw=true },
            new() { MatchNumber="M42", Stage="Grupo G", Group="G", HomeTeam="Egipto",        HomeFlagEmoji="🇪🇬", AwayTeam="Irán",          AwayFlagEmoji="🇮🇷", MatchDateUtc=new DateTime(2026,6,27, 7,0,0,DateTimeKind.Utc), Venue="Seattle",     AllowDraw=true },

            // ── GRUPO H ──
            new() { MatchNumber="M43", Stage="Grupo H", Group="H", HomeTeam="España",         HomeFlagEmoji="🇪🇸", AwayTeam="Cabo Verde",     AwayFlagEmoji="🇨🇻", MatchDateUtc=new DateTime(2026,6,15,17,0,0,DateTimeKind.Utc), Venue="Atlanta",     AllowDraw=true },
            new() { MatchNumber="M44", Stage="Grupo H", Group="H", HomeTeam="Arabia Saudita", HomeFlagEmoji="🇸🇦", AwayTeam="Uruguay",        AwayFlagEmoji="🇺🇾", MatchDateUtc=new DateTime(2026,6,15,23,0,0,DateTimeKind.Utc), Venue="Miami",       AllowDraw=true },
            new() { MatchNumber="M45", Stage="Grupo H", Group="H", HomeTeam="España",         HomeFlagEmoji="🇪🇸", AwayTeam="Arabia Saudita", AwayFlagEmoji="🇸🇦", MatchDateUtc=new DateTime(2026,6,21,17,0,0,DateTimeKind.Utc), Venue="Atlanta",     AllowDraw=true },
            new() { MatchNumber="M46", Stage="Grupo H", Group="H", HomeTeam="Uruguay",        HomeFlagEmoji="🇺🇾", AwayTeam="Cabo Verde",     AwayFlagEmoji="🇨🇻", MatchDateUtc=new DateTime(2026,6,21,23,0,0,DateTimeKind.Utc), Venue="Miami",       AllowDraw=true },
            new() { MatchNumber="M47", Stage="Grupo H", Group="H", HomeTeam="Cabo Verde",     HomeFlagEmoji="🇨🇻", AwayTeam="Arabia Saudita", AwayFlagEmoji="🇸🇦", MatchDateUtc=new DateTime(2026,6,27, 2,0,0,DateTimeKind.Utc), Venue="Houston",     AllowDraw=true },
            new() { MatchNumber="M48", Stage="Grupo H", Group="H", HomeTeam="Uruguay",        HomeFlagEmoji="🇺🇾", AwayTeam="España",         AwayFlagEmoji="🇪🇸", MatchDateUtc=new DateTime(2026,6,27, 2,0,0,DateTimeKind.Utc), Venue="Guadalajara", AllowDraw=true },

            // ── GRUPO I ──
            new() { MatchNumber="M49", Stage="Grupo I", Group="I", HomeTeam="Francia", HomeFlagEmoji="🇫🇷", AwayTeam="Senegal", AwayFlagEmoji="🇸🇳", MatchDateUtc=new DateTime(2026,6,16,20,0,0,DateTimeKind.Utc), Venue="Nueva York/NJ", AllowDraw=true },
            new() { MatchNumber="M50", Stage="Grupo I", Group="I", HomeTeam="Irak",    HomeFlagEmoji="🇮🇶", AwayTeam="Noruega", AwayFlagEmoji="🇳🇴", MatchDateUtc=new DateTime(2026,6,16,23,0,0,DateTimeKind.Utc), Venue="Boston",        AllowDraw=true },
            new() { MatchNumber="M51", Stage="Grupo I", Group="I", HomeTeam="Francia", HomeFlagEmoji="🇫🇷", AwayTeam="Irak",    AwayFlagEmoji="🇮🇶", MatchDateUtc=new DateTime(2026,6,22,22,0,0,DateTimeKind.Utc), Venue="Filadelfia",    AllowDraw=true },
            new() { MatchNumber="M52", Stage="Grupo I", Group="I", HomeTeam="Noruega", HomeFlagEmoji="🇳🇴", AwayTeam="Senegal", AwayFlagEmoji="🇸🇳", MatchDateUtc=new DateTime(2026,6,23, 1,0,0,DateTimeKind.Utc), Venue="Nueva York/NJ", AllowDraw=true },
            new() { MatchNumber="M53", Stage="Grupo I", Group="I", HomeTeam="Noruega", HomeFlagEmoji="🇳🇴", AwayTeam="Francia", AwayFlagEmoji="🇫🇷", MatchDateUtc=new DateTime(2026,6,26,20,0,0,DateTimeKind.Utc), Venue="Boston",        AllowDraw=true },
            new() { MatchNumber="M54", Stage="Grupo I", Group="I", HomeTeam="Senegal", HomeFlagEmoji="🇸🇳", AwayTeam="Irak",    AwayFlagEmoji="🇮🇶", MatchDateUtc=new DateTime(2026,6,26,20,0,0,DateTimeKind.Utc), Venue="Toronto",       AllowDraw=true },

            // ── GRUPO J ──
            new() { MatchNumber="M55", Stage="Grupo J", Group="J", HomeTeam="Argentina", HomeFlagEmoji="🇦🇷", AwayTeam="Argelia",   AwayFlagEmoji="🇩🇿", MatchDateUtc=new DateTime(2026,6,17, 3,0,0,DateTimeKind.Utc), Venue="Kansas City",   AllowDraw=true },
            new() { MatchNumber="M56", Stage="Grupo J", Group="J", HomeTeam="Austria",   HomeFlagEmoji="🇦🇹", AwayTeam="Jordania",  AwayFlagEmoji="🇯🇴", MatchDateUtc=new DateTime(2026,6,17, 8,0,0,DateTimeKind.Utc), Venue="San Francisco", AllowDraw=true },
            new() { MatchNumber="M57", Stage="Grupo J", Group="J", HomeTeam="Argentina", HomeFlagEmoji="🇦🇷", AwayTeam="Austria",   AwayFlagEmoji="🇦🇹", MatchDateUtc=new DateTime(2026,6,22,19,0,0,DateTimeKind.Utc), Venue="Dallas",        AllowDraw=true },
            new() { MatchNumber="M58", Stage="Grupo J", Group="J", HomeTeam="Jordania",  HomeFlagEmoji="🇯🇴", AwayTeam="Argelia",   AwayFlagEmoji="🇩🇿", MatchDateUtc=new DateTime(2026,6,23, 7,0,0,DateTimeKind.Utc), Venue="San Francisco", AllowDraw=true },
            new() { MatchNumber="M59", Stage="Grupo J", Group="J", HomeTeam="Argelia",   HomeFlagEmoji="🇩🇿", AwayTeam="Austria",   AwayFlagEmoji="🇦🇹", MatchDateUtc=new DateTime(2026,6,28, 4,0,0,DateTimeKind.Utc), Venue="Kansas City",   AllowDraw=true },
            new() { MatchNumber="M60", Stage="Grupo J", Group="J", HomeTeam="Jordania",  HomeFlagEmoji="🇯🇴", AwayTeam="Argentina", AwayFlagEmoji="🇦🇷", MatchDateUtc=new DateTime(2026,6,28, 4,0,0,DateTimeKind.Utc), Venue="Dallas",        AllowDraw=true },

            // ── GRUPO K ──
            new() { MatchNumber="M61", Stage="Grupo K", Group="K", HomeTeam="Portugal",   HomeFlagEmoji="🇵🇹", AwayTeam="RD Congo",   AwayFlagEmoji="🇨🇩", MatchDateUtc=new DateTime(2026,6,17,19,0,0,DateTimeKind.Utc), Venue="Houston",          AllowDraw=true },
            new() { MatchNumber="M62", Stage="Grupo K", Group="K", HomeTeam="Uzbekistán", HomeFlagEmoji="🇺🇿", AwayTeam="Colombia",   AwayFlagEmoji="🇨🇴", MatchDateUtc=new DateTime(2026,6,18, 4,0,0,DateTimeKind.Utc), Venue="Ciudad de México", AllowDraw=true },
            new() { MatchNumber="M63", Stage="Grupo K", Group="K", HomeTeam="Portugal",   HomeFlagEmoji="🇵🇹", AwayTeam="Uzbekistán", AwayFlagEmoji="🇺🇿", MatchDateUtc=new DateTime(2026,6,23,19,0,0,DateTimeKind.Utc), Venue="Houston",          AllowDraw=true },
            new() { MatchNumber="M64", Stage="Grupo K", Group="K", HomeTeam="Colombia",   HomeFlagEmoji="🇨🇴", AwayTeam="RD Congo",   AwayFlagEmoji="🇨🇩", MatchDateUtc=new DateTime(2026,6,24, 4,0,0,DateTimeKind.Utc), Venue="Guadalajara",      AllowDraw=true },
            new() { MatchNumber="M65", Stage="Grupo K", Group="K", HomeTeam="Colombia",   HomeFlagEmoji="🇨🇴", AwayTeam="Portugal",   AwayFlagEmoji="🇵🇹", MatchDateUtc=new DateTime(2026,6,28, 2,30,0,DateTimeKind.Utc), Venue="Miami",           AllowDraw=true },
            new() { MatchNumber="M66", Stage="Grupo K", Group="K", HomeTeam="RD Congo",   HomeFlagEmoji="🇨🇩", AwayTeam="Uzbekistán", AwayFlagEmoji="🇺🇿", MatchDateUtc=new DateTime(2026,6,28, 2,30,0,DateTimeKind.Utc), Venue="Atlanta",          AllowDraw=true },

            // ── GRUPO L ──
            new() { MatchNumber="M67", Stage="Grupo L", Group="L", HomeTeam="Inglaterra", HomeFlagEmoji="🏴󠁧󠁢󠁥󠁮󠁧󠁿", AwayTeam="Croacia",    AwayFlagEmoji="🇭🇷", MatchDateUtc=new DateTime(2026,6,17,22,0,0,DateTimeKind.Utc), Venue="Dallas",        AllowDraw=true },
            new() { MatchNumber="M68", Stage="Grupo L", Group="L", HomeTeam="Ghana",      HomeFlagEmoji="🇬🇭", AwayTeam="Panamá",     AwayFlagEmoji="🇵🇦", MatchDateUtc=new DateTime(2026,6,18, 0,0,0,DateTimeKind.Utc), Venue="Toronto",       AllowDraw=true },
            new() { MatchNumber="M69", Stage="Grupo L", Group="L", HomeTeam="Inglaterra", HomeFlagEmoji="🏴󠁧󠁢󠁥󠁮󠁧󠁿", AwayTeam="Ghana",      AwayFlagEmoji="🇬🇭", MatchDateUtc=new DateTime(2026,6,23,21,0,0,DateTimeKind.Utc), Venue="Boston",        AllowDraw=true },
            new() { MatchNumber="M70", Stage="Grupo L", Group="L", HomeTeam="Panamá",     HomeFlagEmoji="🇵🇦", AwayTeam="Croacia",    AwayFlagEmoji="🇭🇷", MatchDateUtc=new DateTime(2026,6,24, 0,0,0,DateTimeKind.Utc), Venue="Toronto",       AllowDraw=true },
            new() { MatchNumber="M71", Stage="Grupo L", Group="L", HomeTeam="Panamá",     HomeFlagEmoji="🇵🇦", AwayTeam="Inglaterra", AwayFlagEmoji="🏴󠁧󠁢󠁥󠁮󠁧󠁿", MatchDateUtc=new DateTime(2026,6,27,22,0,0,DateTimeKind.Utc), Venue="Nueva York/NJ", AllowDraw=true },
            new() { MatchNumber="M72", Stage="Grupo L", Group="L", HomeTeam="Croacia",    HomeFlagEmoji="🇭🇷", AwayTeam="Ghana",      AwayFlagEmoji="🇬🇭", MatchDateUtc=new DateTime(2026,6,27,22,0,0,DateTimeKind.Utc), Venue="Filadelfia",    AllowDraw=true },

            // ── DIECISEISAVOS ──
            new() { MatchNumber="M73",  Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,6,28,23,0,0,DateTimeKind.Utc), Venue="Los Ángeles",      AllowDraw=false },
            new() { MatchNumber="M74",  Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,6,29,19,0,0,DateTimeKind.Utc), Venue="Houston",           AllowDraw=false },
            new() { MatchNumber="M75",  Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,6,29,22,30,0,DateTimeKind.Utc), Venue="Boston",           AllowDraw=false },
            new() { MatchNumber="M76",  Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,6,30, 3,0,0,DateTimeKind.Utc), Venue="Monterrey",         AllowDraw=false },
            new() { MatchNumber="M77",  Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,6,30,19,0,0,DateTimeKind.Utc), Venue="Dallas",            AllowDraw=false },
            new() { MatchNumber="M78",  Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,6,30,22,0,0,DateTimeKind.Utc), Venue="Nueva York/NJ",    AllowDraw=false },
            new() { MatchNumber="M79",  Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7, 1, 3,0,0,DateTimeKind.Utc), Venue="Ciudad de México",  AllowDraw=false },
            new() { MatchNumber="M80",  Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7, 1,17,0,0,DateTimeKind.Utc), Venue="Atlanta",           AllowDraw=false },
            new() { MatchNumber="M81",  Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7, 1,21,0,0,DateTimeKind.Utc), Venue="Seattle",           AllowDraw=false },
            new() { MatchNumber="M82",  Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7, 2, 1,0,0,DateTimeKind.Utc), Venue="San Francisco",     AllowDraw=false },
            new() { MatchNumber="M83",  Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7, 2,23,0,0,DateTimeKind.Utc), Venue="Los Ángeles",      AllowDraw=false },
            new() { MatchNumber="M84",  Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7, 3, 1,0,0,DateTimeKind.Utc), Venue="Toronto",           AllowDraw=false },
            new() { MatchNumber="M85",  Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7, 3, 7,0,0,DateTimeKind.Utc), Venue="Vancouver",         AllowDraw=false },
            new() { MatchNumber="M86",  Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7, 3,21,0,0,DateTimeKind.Utc), Venue="Dallas",            AllowDraw=false },
            new() { MatchNumber="M87",  Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7, 3,23,0,0,DateTimeKind.Utc), Venue="Miami",             AllowDraw=false },
            new() { MatchNumber="M88",  Stage="Dieciseisavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7, 4, 3,30,0,DateTimeKind.Utc), Venue="Kansas City",      AllowDraw=false },

            // ── OCTAVOS ──
            new() { MatchNumber="M89",  Stage="Octavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7, 4,19,0,0,DateTimeKind.Utc), Venue="Houston",       AllowDraw=false },
            new() { MatchNumber="M90",  Stage="Octavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7, 4,22,0,0,DateTimeKind.Utc), Venue="Filadelfia",    AllowDraw=false },
            new() { MatchNumber="M91",  Stage="Octavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7, 5,21,0,0,DateTimeKind.Utc), Venue="Nueva York/NJ", AllowDraw=false },
            new() { MatchNumber="M92",  Stage="Octavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7, 6, 1,0,0,DateTimeKind.Utc), Venue="Ciudad de México", AllowDraw=false },
            new() { MatchNumber="M93",  Stage="Octavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7, 6,21,0,0,DateTimeKind.Utc), Venue="Dallas",        AllowDraw=false },
            new() { MatchNumber="M94",  Stage="Octavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7, 7, 1,0,0,DateTimeKind.Utc), Venue="Seattle",       AllowDraw=false },
            new() { MatchNumber="M95",  Stage="Octavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7, 7,17,0,0,DateTimeKind.Utc), Venue="Atlanta",       AllowDraw=false },
            new() { MatchNumber="M96",  Stage="Octavos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7, 7,21,0,0,DateTimeKind.Utc), Venue="Vancouver",     AllowDraw=false },

            // ── CUARTOS ──
            new() { MatchNumber="M97",  Stage="Cuartos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7, 9,21,0,0,DateTimeKind.Utc), Venue="Boston",      AllowDraw=false },
            new() { MatchNumber="M98",  Stage="Cuartos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7,10,23,0,0,DateTimeKind.Utc), Venue="Los Ángeles", AllowDraw=false },
            new() { MatchNumber="M99",  Stage="Cuartos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7,11,22,0,0,DateTimeKind.Utc), Venue="Miami",       AllowDraw=false },
            new() { MatchNumber="M100", Stage="Cuartos", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7,12, 3,0,0,DateTimeKind.Utc), Venue="Kansas City", AllowDraw=false },

            // ── SEMIFINALES ──
            new() { MatchNumber="M101", Stage="Semifinal", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7,14,21,0,0,DateTimeKind.Utc), Venue="Dallas",  AllowDraw=false },
            new() { MatchNumber="M102", Stage="Semifinal", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7,15,20,0,0,DateTimeKind.Utc), Venue="Atlanta", AllowDraw=false },

            // ── TERCER LUGAR Y FINAL ──
            new() { MatchNumber="M103", Stage="Tercer Lugar", HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7,18,22,0,0,DateTimeKind.Utc), Venue="Miami",          AllowDraw=false },
            new() { MatchNumber="M104", Stage="Final",        HomeTeam="TBD", HomeFlagEmoji="🏳", AwayTeam="TBD", AwayFlagEmoji="🏳", MatchDateUtc=new DateTime(2026,7,19,20,0,0,DateTimeKind.Utc), Venue="Nueva York/NJ",  AllowDraw=false },
        };

        db.Matches.AddRange(matches);
        await db.SaveChangesAsync();
    }
}