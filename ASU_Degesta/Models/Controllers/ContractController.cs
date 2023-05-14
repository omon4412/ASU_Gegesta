﻿using ASU_Degesta.Models.Handbooks;
using ASU_Degesta.Models.SalesDepartment;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;

namespace ASU_Degesta.Models.Controllers;

[ApiController]
[Route("api/GetContractDocx")]
public class ContractController : Controller
{
    public ActionResult OnGet([FromBody] ContractData data)
    {
        var datas = data.Contracts;
        

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
            GetDocxClass.AddHeader(body,  "Отдел продаж",12, borders3, JustificationValues.Right);
            
            body.Append(new Paragraph());
            
            body.Append(new Paragraph(new ParagraphProperties(
                    new Justification() {Val = JustificationValues.Center}),
                new Run(DataFabric.CreateTimesNewRoman16(),
                    new Text(
                        data.Contract_ID.doc_name))));
            body.Append(new Paragraph());

            body.Append(new Paragraph(new ParagraphProperties(
                    new Justification() {Val = JustificationValues.Left}),
                new Run(DataFabric.CreateTimesNewRoman12(),
                    new Text("Дата формирования: " +
                             data.Contract_ID.creation_date))));
            body.Append(new Paragraph(new ParagraphProperties(
                    new Justification() {Val = JustificationValues.Left}),
                new Run(DataFabric.CreateTimesNewRoman12(),
                    new Text("Серийный номер документа: " +
                             data.Contract_ID.doc_id))));
            body.Append(new Paragraph());

            var data_table = new List<List<string>>();

            data_table.Add(new List<string>()
            {
                "Наименование", "Количество", "Цена за единицу", "Стоимость", "Единицы измерения"
            });
            foreach (var item in datas)
            {
                data_table.Add(new List<string>()
                {
                    data.TypesOfProductsList.Where(x=>x.TypesOfProductsId== item.types_of_products_id).FirstOrDefault().Name,
                    item.count_of_matherials.ToString(), item.price_per_unit.ToString(),
                    item.price.ToString(), data.UnitsList.Where(x=>x.Units_ID == item.units_id).FirstOrDefault().Name
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
            GetDocxClass.AddSignature(body, "Начальник отдела продаж:", 12, borders2, JustificationValues.Center);

            body.Append(new Paragraph());

            mainPart.Document.Save();

            doc.Close();

            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "test.docx");
        }
    }

    public class ContractData
    {
        public List<SpecificationContractMaterials> Contracts { get; set; }
        public SpecificationContractMaterials_id Contract_ID { get; set; }

        public List<Units> UnitsList { get; set; }
        public List<TypesOfProducts> TypesOfProductsList { get; set; }
    }
}