using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASU_Degesta.Models.Handbooks;

namespace ASU_Degesta.Models.SalesDepartment;

public class PriceList
{
    [Key] public int id { get; set; }

    [Display(Name = "Номер документа")] public string doc_id { get; set; }
    [ForeignKey("doc_id")]
    public PriceList_id? ReportProductPlan_id { get; set; }

    [Display(Name = "Наименование")] public string types_of_products_id { get; set; }
    [ForeignKey("types_of_products_id")]
    public TypesOfProducts? TypesOfProducts { get; set; }

    [Display(Name = "Максимальный спрос")] public int demand { get; set; }

    [Display(Name = "Единицы измерения")] public int units_id { get; set; }
    [ForeignKey("units_id")]
    public Units? Units { get; set; }
}