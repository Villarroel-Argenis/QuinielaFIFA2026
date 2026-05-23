using Colors = QuestPDF.Helpers.Colors;

namespace QuinielaFIFA2026.Web.Services;

public class PlanillaPdfService
{
    public byte[] GenerarLotePdf(Lote lote, List<Match> partidos)
    {
        return Document.Create(container =>
        {
            foreach (var planilla in lote.Planillas)
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.Letter.Landscape());
                    page.Margin(1, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(7.5f));

                    page.Header().Column(col =>
                    {
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Column(c =>
                            {
                                c.Item().Text("Quiniela FIFA World Cup 2026")
                                    .FontSize(14).Bold();
                                c.Item().Text($"Codigo: {planilla.Codigo}")
                                    .FontSize(11).Bold().FontColor("#2E7D32");
                                c.Item().Text($"Lote: {lote.Codigo}")
                                    .FontSize(8).FontColor("#666666");
                            });
                            row.ConstantItem(200).Column(c =>
                            {
                                c.Item().Text("L = Local   E = Empate   V = Visitante")
                                    .FontSize(8).AlignRight();
                                c.Item().Text("Marque su prediccion en el recuadro")
                                    .FontSize(7).FontColor("#666666").AlignRight();
                            });
                        });
                        col.Item().PaddingTop(4).LineHorizontal(1).LineColor("#2E7D32");
                        col.Item().PaddingBottom(4);
                    });

                    page.Content().Column(mainCol =>
                    {
                        var grupos = partidos
                            .Where(p => p.Stage.StartsWith("Grupo"))
                            .GroupBy(p => p.Stage)
                            .OrderBy(g => g.Key)
                            .ToList();

                        var eliminatorias = partidos
                            .Where(p => !p.Stage.StartsWith("Grupo"))
                            .GroupBy(p => p.Stage)
                            .ToList();

                        // Fila 1: Grupos A-D
                        mainCol.Item().Row(row =>
                        {
                            foreach (var stage in grupos.Take(4))
                            {
                                row.RelativeItem().Column(col => RenderStage(col, stage.Key, stage.ToList()));
                                row.ConstantItem(6);
                            }
                        });

                        mainCol.Item().PaddingBottom(4);

                        // Fila 2: Grupos E-H
                        mainCol.Item().Row(row =>
                        {
                            foreach (var stage in grupos.Skip(4).Take(4))
                            {
                                row.RelativeItem().Column(col => RenderStage(col, stage.Key, stage.ToList()));
                                row.ConstantItem(6);
                            }
                        });

                        mainCol.Item().PaddingBottom(4);

                        // Fila 3: Grupos I-L
                        mainCol.Item().Row(row =>
                        {
                            foreach (var stage in grupos.Skip(8).Take(4))
                            {
                                row.RelativeItem().Column(col => RenderStage(col, stage.Key, stage.ToList()));
                                row.ConstantItem(6);
                            }
                        });

                        mainCol.Item().PageBreak();

                        // Página 2: Eliminatorias
                        mainCol.Item().Row(row =>
                        {
                            var dieciseisavos = eliminatorias.FirstOrDefault(s => s.Key == "Dieciseisavos");
                            if (dieciseisavos != null)
                            {
                                row.RelativeItem().Column(col =>
                                    RenderStage(col, "Dieciseisavos (1-8)", dieciseisavos.Take(8).ToList()));
                                row.ConstantItem(6);
                                row.RelativeItem().Column(col =>
                                    RenderStage(col, "Dieciseisavos (9-16)", dieciseisavos.Skip(8).ToList()));
                                row.ConstantItem(6);
                            }

                            var octavos = eliminatorias.FirstOrDefault(s => s.Key == "Octavos");
                            if (octavos != null)
                            {
                                row.RelativeItem().Column(col =>
                                    RenderStage(col, "Octavos", octavos.ToList()));
                                row.ConstantItem(6);
                            }

                            row.RelativeItem().Column(col =>
                            {
                                var fases = new[] { "Cuartos", "Semifinal", "Tercer Lugar", "Final" };
                                foreach (var fase in fases)
                                {
                                    var stage = eliminatorias.FirstOrDefault(s => s.Key == fase);
                                    if (stage != null)
                                        RenderStage(col, fase, stage.ToList());
                                }
                            });
                        });
                    });

                    page.Footer().Row(row =>
                    {
                        row.RelativeItem().Text("Vinccler C.A. — Quiniela FIFA 2026")
                            .FontSize(7).FontColor("#666666");
                        row.ConstantItem(150).Text($"Codigo: {planilla.Codigo}")
                            .FontSize(7).Bold().AlignRight();
                    });
                });
            }
        }).GeneratePdf();
    }

    private static void RenderStage(ColumnDescriptor col, string stageName, List<Match> matches)
    {
        col.Item().Background("#2E7D32").Padding(2)
            .Text(stageName).FontColor(Colors.White).Bold().FontSize(8);

        col.Item().Table(table =>
        {
            table.ColumnsDefinition(cols =>
            {
                cols.ConstantColumn(22);   // Número
                cols.RelativeColumn();     // Local
                cols.ConstantColumn(20);   // @
                cols.RelativeColumn();     // Visitante
                cols.ConstantColumn(18);   // L
                cols.ConstantColumn(18);   // E
                cols.ConstantColumn(18);   // V
            });

            // Header
            table.Cell().Background("#E8F5E9").Padding(2).Text("#").FontSize(7).Bold();
            table.Cell().Background("#E8F5E9").Padding(2).Text("Local").FontSize(7).Bold().AlignRight();
            table.Cell().Background("#E8F5E9").Padding(2).Text("").FontSize(7);
            table.Cell().Background("#E8F5E9").Padding(2).Text("Visitante").FontSize(7).Bold();
            table.Cell().Background("#E8F5E9").Padding(2).Text("L").FontSize(7).Bold().AlignCenter();
            table.Cell().Background("#E8F5E9").Padding(2).Text("E").FontSize(7).Bold().AlignCenter();
            table.Cell().Background("#E8F5E9").Padding(2).Text("V").FontSize(7).Bold().AlignCenter();

            for (int i = 0; i < matches.Count; i++)
            {
                var m = matches[i];
                var bg = i % 2 == 0 ? Colors.White : Colors.Grey.Lighten4;

                table.Cell().Background(bg).Padding(2)
                    .Text(m.MatchNumber).FontSize(7).FontColor("#666666");
                table.Cell().Background(bg).Padding(2)
                    .Text(m.HomeTeam == "TBD" ? "___________" : m.HomeTeam)
                    .FontSize(7.5f).AlignRight();
                table.Cell().Background(bg).Padding(2)
                    .Text("@").FontSize(7).AlignCenter().FontColor("#2E7D32").Bold();
                table.Cell().Background(bg).Padding(2)
                    .Text(m.AwayTeam == "TBD" ? "___________" : m.AwayTeam)
                    .FontSize(7.5f);
                table.Cell().Background(bg).Border(0.5f).BorderColor("#CCCCCC")
                    .Height(14).AlignCenter().AlignMiddle().Text("L").FontSize(7).FontColor("#CCCCCC");
                table.Cell().Background(bg).Border(0.5f).BorderColor("#CCCCCC")
                    .Height(14).AlignCenter().AlignMiddle().Text("E").FontSize(7).FontColor("#CCCCCC");
                table.Cell().Background(bg).Border(0.5f).BorderColor("#CCCCCC")
                    .Height(14).AlignCenter().AlignMiddle().Text("V").FontSize(7).FontColor("#CCCCCC");
            }
        });
        col.Item().PaddingBottom(4);
    }
}