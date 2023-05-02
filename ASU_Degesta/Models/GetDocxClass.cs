using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace ASU_Degesta.Models;

public static class GetDocxClass
{
     public static void AddHeader(Body body, string department, int fontSize,
        Dictionary<string, BorderValues> borders, JustificationValues justificationValues,
        bool headerBold = false)
    {
        Table table1 = new Table();

        TableProperties props = new TableProperties();

        TableCellVerticalAlignment tcVA = new TableCellVerticalAlignment() {Val = TableVerticalAlignmentValues.Center};
        
        var tableWidth = new TableWidth() {Width = "5200", Type = TableWidthUnitValues.Pct};
        TableLayout tl = new TableLayout() {Type = TableLayoutValues.Autofit};

        props.TableLayout = tl;

        props.Append(tableWidth);
        props.Append(tcVA);
        table1.AppendChild<TableProperties>(props);
        var data1 = new List<List<string>>()
        {
            new() {"ООО “Дежеста”"},
            new() {department},
        };

        for (var i = 0; i < 2; i++)
        {
            var tr1 = new TableRow();
            for (var j = 0; j < 1; j++)
            {
                var rp = new RunProperties()
                {
                    FontSize = new FontSize()
                    {
                        Val = new StringValue((fontSize * 2).ToString()),
                    },
                    //Bold = headerBold == true && i == 0 ? new Bold() : null,
                    RunFonts = new RunFonts()
                    {
                        Ascii = "Times New Roman",
                        HighAnsi = "Times New Roman"
                    }
                };
                var tc = new TableCell();
                tc.Append(new Paragraph(new ParagraphProperties(
                        new Justification() {Val = justificationValues}),
                    new Run(rp, new Text(data1[i][j]))));

                tc.Append(new TableCellProperties(
                    new TableCellWidth
                        {Width = i == 0 && j == 0 || i == 1 && j == 0 ? "1" : "0", Type = TableWidthUnitValues.Auto}));
                tr1.Append(tc);
            }

            table1.Append(tr1);
        }

        body.Append(table1);
    }
    public static void AddSignature(Body body, string position, int fontSize,
        Dictionary<string, BorderValues> borders, JustificationValues justificationValues,
        bool headerBold = false)
    {
        Table table1 = new Table();

        TableProperties props = new TableProperties();

        TableCellVerticalAlignment tcVA = new TableCellVerticalAlignment() {Val = TableVerticalAlignmentValues.Center};
        var tableWidth = new TableWidth() {Width = "5200", Type = TableWidthUnitValues.Pct};
        TableLayout tl = new TableLayout() {Type = TableLayoutValues.Autofit};

        props.TableLayout = tl;

        props.Append(tableWidth);
        props.Append(tcVA);
        table1.AppendChild<TableProperties>(props);
        var data1 = new List<List<string>>()
        {
            new() {position, "__________________", "__________________________"},
            new() {"", "(подпись)", "(фамилия, инициалы)"},
        };

        for (var i = 0; i < 2; i++)
        {
            var tr1 = new TableRow();
            for (var j = 0; j < 3; j++)
            {
                var rp = new RunProperties()
                {
                    FontSize = new FontSize()
                    {
                        Val = new StringValue((fontSize * 2).ToString()),
                    },
                    //Bold = headerBold == true && i == 0 ? new Bold() : null,
                    RunFonts = new RunFonts()
                    {
                        Ascii = "Times New Roman",
                        HighAnsi = "Times New Roman"
                    }
                };
                var tc = new TableCell();
                tc.Append(new Paragraph(new ParagraphProperties(
                        new Justification() {Val = justificationValues}),
                    new Run(rp, new Text(data1[i][j]))));

                tc.Append(new TableCellProperties(
                    new TableCellWidth
                        {Width = i == 0 && j == 0 || i == 1 && j == 0 ? "1" : "0", Type = TableWidthUnitValues.Auto}));
                tr1.Append(tc);
            }

            table1.Append(tr1);
        }

        body.Append(table1);
    }

    public static Table AddTable(Body body, List<List<string>> data, int fontSize,
        Dictionary<string, BorderValues> borders, JustificationValues justificationValues,
        bool headerBold = false)
    {
        Table table = new Table();

        TableProperties props = new TableProperties(
            new TableBorders(
                new TopBorder
                {
                    Val = new EnumValue<BorderValues>(borders["top"]),
                    Size = 0
                },
                new BottomBorder
                {
                    Val = new EnumValue<BorderValues>(borders["bottom"]),
                    Size = 0
                },
                new LeftBorder
                {
                    Val = new EnumValue<BorderValues>(borders["left"]),
                    Size = 0
                },
                new RightBorder
                {
                    Val = new EnumValue<BorderValues>(borders["right"]),
                    Size = 0
                },
                new InsideHorizontalBorder
                {
                    Val = new EnumValue<BorderValues>(borders["inside_horizontal"]),
                    Size = 0
                },
                new InsideVerticalBorder
                {
                    Val = new EnumValue<BorderValues>(borders["inside_vertical"]),
                    Size = 0
                }));

        TableCellVerticalAlignment tcVA = new TableCellVerticalAlignment() {Val = TableVerticalAlignmentValues.Center};
        var tableWidth = new TableWidth() {Width = "5000", Type = TableWidthUnitValues.Pct};
        TableLayout tl = new TableLayout() {Type = TableLayoutValues.Autofit};

        props.TableLayout = tl;

        props.Append(tableWidth);
        props.Append(tcVA);
        table.AppendChild<TableProperties>(props);
        
        for (var i = 0; i < data.Count; i++)
        {
            var tr = new TableRow();
            for (var j = 0; j < data[i].Count; j++)
            {
                var rp = new RunProperties()
                {
                    FontSize = new FontSize()
                    {
                        Val = new StringValue((fontSize * 2).ToString()),
                    },
                    Bold = headerBold == true && i == 0 ? new Bold() : null,
                    RunFonts = new RunFonts()
                    {
                        Ascii = "Times New Roman",
                        HighAnsi = "Times New Roman"
                    }
                };
                var tc = new TableCell();
                tc.Append(new Paragraph(new ParagraphProperties(
                        new Justification() {Val = justificationValues}),
                    new Run(rp, new Text(data[i][j]))));

                tc.Append(new TableCellProperties(
                    new TableCellWidth {Type = TableWidthUnitValues.Nil,}));
                tr.Append(tc);
            }

            table.Append(tr);
        }

        body.Append(table);
        return table;
    }

    public static void MergeTableCells(TableRow row, int startCellIndex, int endCellIndex)
    {
        TableCell cell1 = row.Elements<TableCell>().ElementAt(startCellIndex);
        TableCellProperties cellOneProperties = new TableCellProperties();
        cellOneProperties.Append(new HorizontalMerge()
        {
            Val = MergedCellValues.Restart
        });
        cell1.Append(cellOneProperties);
        for (int i = startCellIndex + 1; i < endCellIndex + 1; i++)
        {
            TableCell cell2 = row.Elements<TableCell>().ElementAt(i);

            TableCellProperties cellTwoProperties = new TableCellProperties();
            cellTwoProperties.Append(new HorizontalMerge()
            {
                Val = MergedCellValues.Continue
            });

            cell2.Append(cellTwoProperties);
        }
    }
}