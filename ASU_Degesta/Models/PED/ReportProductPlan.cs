using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASU_Degesta.Models.Handbooks;
using ASU_Degesta.Models.ProductionDepartment;

namespace ASU_Degesta.Models.PED;

public class ReportProductPlan
{
    [Key] public int id { get; set; }

    [Display(Name = "Номер документа")] public string doc_id { get; set; }
    [ForeignKey("doc_id")]
    public ReportProductPlan_id? ReportProductPlan_id { get; set; }

    [Display(Name = "Наименование")] public string types_of_products_id { get; set; }
    [ForeignKey("types_of_products_id")]
    public TypesOfProducts? TypesOfProducts { get; set; }

    [Display(Name = "Произведено")] public int produced { get; set; }

    [Display(Name = "Единицы измерения")] public int units_id { get; set; }
    [ForeignKey("units_id")]
    public Units? Units { get; set; }
}