using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASU_Degesta.Models.Handbooks;

namespace ASU_Degesta.Models.PED;

public class ReportProductCost
{
    [Key] public int id { get; set; }

    [Display(Name = "Номер документа")] public string doc_id { get; set; }
    [ForeignKey("doc_id")]
    public ReportProductCost_id? ReportProductPlan_id { get; set; }

    [Display(Name = "Наименование")] public string types_of_products_id { get; set; }
    [ForeignKey("types_of_products_id")]
    public TypesOfProducts? TypesOfProducts { get; set; }

    [Display(Name = "Себестоимость")] public double cost_price { get; set; }

    [Display(Name = "Единицы измерения")] public int units_id { get; set; }
    [ForeignKey("units_id")]
    public Units? Units { get; set; }
}