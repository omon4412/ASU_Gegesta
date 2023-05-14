using ASU_Degesta.Models.Accounting;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;

namespace ASU_Degesta.Models.Controllers;

[ApiController]
[Route("api/GetPayrollStatemetsDocx")]
public class PayrollStatemetsController : Controller
{
    public ActionResult OnGet([FromBody] PayrollStatemetsData data)
    {
        var datas = data.PayrollStatements;

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
            GetDocxClass.AddHeader(body,  "Бухгалтерия",12, borders3, JustificationValues.Right);
            
            body.Append(new Paragraph(new ParagraphProperties(
                    new Justification() {Val = JustificationValues.Center}),
                new Run(DataFabric.CreateTimesNewRoman16(),
                    new Text(
                        data.PayrollStatementNameId.doc_name))));
            body.Append(new Paragraph());
            
            body.Append(new Paragraph(new ParagraphProperties(
                    new Justification() {Val = JustificationValues.Left}),
                new Run(DataFabric.CreateTimesNewRoman12(),
                    new Text( "Дата формирования: " +
                        data.PayrollStatementNameId.creation_date))));
            body.Append(new Paragraph(new ParagraphProperties(
                    new Justification() {Val = JustificationValues.Left}),
                new Run(DataFabric.CreateTimesNewRoman12(),
                    new Text("Серийный номер документа: " +
                             data.PayrollStatementNameId.doc_id))));
            body.Append(new Paragraph());

            var data_table = new List<List<string>>();

            data_table.Add(new List<string>()
            {
                "Табельный номер", "Фамилия И.О.", "Оклад (ден.ед.)", "Премия (ден.ед.)",
                "Всего начислено (ден.ед.)", "Удержания (ден.ед)", "К выдаче (ден.ед)"
            });
            foreach (var item in datas)
            {
                data_table.Add(new List<string>()
                {
                    item.employee_number.ToString(), item.employee_name, item.salary.ToString(),
                    item.bonus.ToString(), item.total_accrued.ToString(), item.withheld.ToString(),
                    item.withheld.ToString()
                });
            }

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
            GetDocxClass.AddSignature(body, "Главный бухгалтер:", 12, borders2, JustificationValues.Center);

            body.Append(new Paragraph());

            mainPart.Document.Save();

            doc.Close();

            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "test.docx");
        }
    }
    public class PayrollStatemetsData
    {
        public List<payroll_statement> PayrollStatements { get; set; }
        public payroll_statement_name_id PayrollStatementNameId { get; set; }
    }
}