using ASU_Degesta.Models.Handbooks;
using ASU_Degesta.Models.PED;
using ASU_Degesta.Models.ProductionDepartment;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;

namespace ASU_Degesta.Models.Controllers;

[ApiController]
[Route("api/GetReportProfitabilityMonthDocx")]
public class ReportProfitabilityMonthController : Controller
{
    public ActionResult OnGet([FromBody] ReportProfitabilityMonthData data)
    {
        var datas = data.Reports;
        var stream = new MemoryStream();
        using (WordprocessingDocument doc = WordprocessingDocument.Create(stream,
                   DocumentFormat.OpenXml.WordprocessingDocumentType.Document, true))
        {
            MainDocumentPart mainPart = doc.AddMainDocumentPart();

            new Document(new Body()).Save(mainPart);

            Body body = mainPart.Document.Body;
           
            PageMargin pageMargin = new PageMargin();
            pageMargin.Top = 720;
            pageMargin.Right = 720;
            pageMargin.Bottom = 720;
            pageMargin.Left = 720;
            pageMargin.Header = 0;
            pageMargin.Footer = 0;
            pageMargin.Gutter = 0;

            SectionProperties sectionProperties = new SectionProperties();

            sectionProperties.Append(pageMargin);

            doc.MainDocumentPart.Document.Body.Append(sectionProperties);

            Dictionary<string, BorderValues> borders3 = new Dictionary<string, BorderValues>
            {
                {"top", BorderValues.None},
                {"bottom", BorderValues.Single},
                {"left", BorderValues.None},
                {"right", BorderValues.None},
                {"inside_horizontal", BorderValues.None},
                {"inside_vertical", BorderValues.None},
            };
            GetDocxClass.AddHeader(body, "Планово-экономический отдел", 12, borders3, JustificationValues.Right);

            body.Append(new Paragraph(new ParagraphProperties(
                    new Justification() {Val = JustificationValues.Center}),
                new Run(DataFabric.CreateTimesNewRoman16(),
                    new Text(
                        data.Report_ID.doc_name))));
            body.Append(new Paragraph());

            body.Append(new Paragraph(new ParagraphProperties(
                    new Justification() {Val = JustificationValues.Left}),
                new Run(DataFabric.CreateTimesNewRoman12(),
                    new Text("Дата формирования: " +
                             data.Report_ID.creation_date))));
            body.Append(new Paragraph(new ParagraphProperties(
                    new Justification() {Val = JustificationValues.Left}),
                new Run(DataFabric.CreateTimesNewRoman12(),
                    new Text("Серийный номер документа: " +
                             data.Report_ID.doc_id))));
            body.Append(new Paragraph());

            var data_table = new List<List<string>>();

            data_table.Add(new List<string>()
            {
                "Наименование", "Выручка с продаж", "Себестоимость", "Прибыль", "Единицы измерения", "Рентабельность"
            });

            double rev_sum = 0;
            double cost_price_sum = 0;
            double profit_sum = 0;
            foreach (var item in datas)
            {
                data_table.Add(new List<string>()
                {
                    data.TypesOfProductsList.Where(x => x.TypesOfProductsId == item.types_of_products_id)
                        .FirstOrDefault().Name,
                    item.revenue.ToString(),
                    item.cost_price.ToString(),
                    item.profit.ToString(),
                    data.UnitsList.Where(x => x.Units_ID == item.units_id).FirstOrDefault().Name,
                    Math.Round(item.profitability * 100, 0).ToString() + '%'
                });
                rev_sum += item.revenue;
                cost_price_sum += item.cost_price;
                profit_sum += item.profit;
            }


            data_table.Add(new List<string>()
            {
                "Сумма", rev_sum.ToString(), cost_price_sum.ToString(), profit_sum.ToString(), "ден. ед.", "-"
            });

            Dictionary<string, BorderValues> borders = new Dictionary<string, BorderValues>
            {
                {"top", BorderValues.Single},
                {"bottom", BorderValues.Single},
                {"left", BorderValues.Single},
                {"right", BorderValues.Single},
                {"inside_horizontal", BorderValues.Single},
                {"inside_vertical", BorderValues.Single},
            };

            GetDocxClass.AddTable(body, data_table, 12, borders, JustificationValues.Center, true);
            body.Append(new Paragraph());

            Dictionary<string, BorderValues> borders2 = new Dictionary<string, BorderValues>
            {
                {"top", BorderValues.None},
                {"bottom", BorderValues.Single},
                {"left", BorderValues.None},
                {"right", BorderValues.None},
                {"inside_horizontal", BorderValues.None},
                {"inside_vertical", BorderValues.None},
            };

            body.Append(new Paragraph(new ParagraphProperties(
                    new Justification() {Val = JustificationValues.Left}),
                new Run(new RunProperties()
                    {
                        FontSize = new FontSize()
                        {
                            Val = new StringValue("24"),
                        },
                        RunFonts = new RunFonts()
                        {
                            Ascii = "Times New Roman",
                            HighAnsi = "Times New Roman"
                        }
                    },
                    new Text("Рентабельность производства: "
                             + Math.Round(data.Reports.Sum(x => x.profit)
                                 / data.Reports.Sum(x => x.revenue) * 100, 0) + " %"))));
            
            body.Append(new Paragraph());
            
            GetDocxClass.AddSignature(body, "Начальник планово-экономического отдела:", 12, borders2,
                JustificationValues.Center);

            body.Append(new Paragraph());

            mainPart.Document.Save();

            doc.Close();

            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "test.docx");
        }
    }

    public class ReportProfitabilityMonthData
    {
        public List<ReportProfitabilityMonth> Reports { get; set; }
        public ReportProfitabilityMonth_id Report_ID { get; set; }

        public List<Units> UnitsList { get; set; }
        public List<TypesOfProducts> TypesOfProductsList { get; set; }
    }
}