namespace QuinielaFIFA2026.Web.Services;

public static class SlotService
{
    // Equipos por grupo
    private static readonly Dictionary<string, List<string>> Grupos = new()
    {
        ["A"] = ["México", "Sudáfrica", "Corea del Sur", "Chequia"],
        ["B"] = ["Canadá", "Bosnia-Herzegovina", "Catar", "Suiza"],
        ["C"] = ["Brasil", "Marruecos", "Haití", "Escocia"],
        ["D"] = ["EUA", "Paraguay", "Australia", "Turquía"],
        ["E"] = ["Alemania", "Curazao", "Costa de Marfil", "Ecuador"],
        ["F"] = ["Países Bajos", "Japón", "Suecia", "Túnez"],
        ["G"] = ["Bélgica", "Egipto", "Irán", "Nueva Zelanda"],
        ["H"] = ["España", "Cabo Verde", "Arabia Saudita", "Uruguay"],
        ["I"] = ["Francia", "Senegal", "Irak", "Noruega"],
        ["J"] = ["Argentina", "Argelia", "Austria", "Jordania"],
        ["K"] = ["Portugal", "RD Congo", "Uzbekistán", "Colombia"],
        ["L"] = ["Inglaterra", "Croacia", "Ghana", "Panamá"],
    };

    // Dado un slot devuelve los equipos posibles
    public static List<string> GetEquiposPosibles(string slot)
    {
        if (string.IsNullOrEmpty(slot)) return [];

        // Slot de ganador de partido: W73, W74... → no aplica selección previa
        if (slot.StartsWith("W") || slot.StartsWith("RU")) return [];

        // Slot de 3ro mejor: 3ABCDF → todos los equipos de esos grupos
        if (slot.StartsWith("3"))
        {
            var grupos = slot.Substring(1).ToCharArray();
            return grupos
                .Where(g => Grupos.ContainsKey(g.ToString()))
                .SelectMany(g => Grupos[g.ToString()])
                .Distinct()
                .OrderBy(e => e)
                .ToList();
        }

        // Slot de 1ro o 2do: 1A, 2B → equipos del grupo
        if (slot.Length >= 2)
        {
            var grupo = slot.Substring(1);
            if (Grupos.ContainsKey(grupo))
                return Grupos[grupo].OrderBy(e => e).ToList();
        }

        return [];
    }

    // Descripción legible del slot
    public static string GetDescripcion(string slot)
    {
        if (string.IsNullOrEmpty(slot)) return "TBD";
        if (slot.StartsWith("W")) return $"Ganador M{slot.Substring(1)}";
        if (slot.StartsWith("RU")) return $"Subcampeón M{slot.Substring(2)}";
        if (slot.StartsWith("3")) return $"Mejor 3ro Grupos {slot.Substring(1)}";
        if (slot.Length >= 2)
        {
            var pos = slot[0] == '1' ? "1ro" : "2do";
            return $"{pos} Grupo {slot.Substring(1)}";
        }
        return slot;
    }

    // Fixture completo de dieciseisavos según FIFA
    public static readonly Dictionary<string, (string Home, string Away)> FixtureTBD = new()
    {
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
    };

    private static readonly Dictionary<string, string> Banderas = new()
    {
        ["México"] = "🇲🇽",
        ["Sudáfrica"] = "🇿🇦",
        ["Corea del Sur"] = "🇰🇷",
        ["Chequia"] = "🇨🇿",
        ["Canadá"] = "🇨🇦",
        ["Bosnia-Herzegovina"] = "🇧🇦",
        ["Catar"] = "🇶🇦",
        ["Suiza"] = "🇨🇭",
        ["Brasil"] = "🇧🇷",
        ["Marruecos"] = "🇲🇦",
        ["Haití"] = "🇭🇹",
        ["Escocia"] = "🏴󠁧󠁢󠁳󠁣󠁴󠁿",
        ["EUA"] = "🇺🇸",
        ["Paraguay"] = "🇵🇾",
        ["Australia"] = "🇦🇺",
        ["Turquía"] = "🇹🇷",
        ["Alemania"] = "🇩🇪",
        ["Curazao"] = "🇨🇼",
        ["Costa de Marfil"] = "🇨🇮",
        ["Ecuador"] = "🇪🇨",
        ["Países Bajos"] = "🇳🇱",
        ["Japón"] = "🇯🇵",
        ["Suecia"] = "🇸🇪",
        ["Túnez"] = "🇹🇳",
        ["Bélgica"] = "🇧🇪",
        ["Egipto"] = "🇪🇬",
        ["Irán"] = "🇮🇷",
        ["Nueva Zelanda"] = "🇳🇿",
        ["España"] = "🇪🇸",
        ["Cabo Verde"] = "🇨🇻",
        ["Arabia Saudita"] = "🇸🇦",
        ["Uruguay"] = "🇺🇾",
        ["Francia"] = "🇫🇷",
        ["Senegal"] = "🇸🇳",
        ["Irak"] = "🇮🇶",
        ["Noruega"] = "🇳🇴",
        ["Argentina"] = "🇦🇷",
        ["Argelia"] = "🇩🇿",
        ["Austria"] = "🇦🇹",
        ["Jordania"] = "🇯🇴",
        ["Portugal"] = "🇵🇹",
        ["RD Congo"] = "🇨🇩",
        ["Uzbekistán"] = "🇺🇿",
        ["Colombia"] = "🇨🇴",
        ["Inglaterra"] = "🏴󠁧󠁢󠁥󠁮󠁧󠁿",
        ["Croacia"] = "🇭🇷",
        ["Ghana"] = "🇬🇭",
        ["Panamá"] = "🇵🇦",
    };

    public static string GetBandera(string equipo) =>
        Banderas.TryGetValue(equipo, out var bandera) ? bandera : "🏳";

    public static List<string> GetEquiposPosibles(string slot, IEnumerable<string>? excluir = null)
    {
        var candidatos = GetEquiposPosibles(slot);
        if (excluir == null) return candidatos;
        var set = new HashSet<string>(excluir);
        return candidatos.Where(e => !set.Contains(e)).ToList();
    }
}