namespace QuinielaFIFA2026.Web.Components.Theme;

public static class AppTheme
{
    public static MudTheme Theme => new()
    {
        PaletteLight = new PaletteLight
        {
            Primary = "#2E7D32",
            PrimaryDarken = "#1B5E20",
            PrimaryLighten = "#4CAF50",
            AppbarBackground = "#2E7D32",
        }
    };
}