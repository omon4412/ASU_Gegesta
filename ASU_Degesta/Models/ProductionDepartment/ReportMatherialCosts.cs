using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASU_Degesta.Models.Handbooks;

namespace ASU_Degesta.Models.ProductionDepartment;

public class ReportMatherialCosts
{
    [Key] public int id { get; set; }

    [Display(Name = "Номер документа")] public string doc_id { get; set; }
    [ForeignKey("doc_id")]
    public ReportMatherialCosts_id? ReportMatherialCosts_id { get; set; }

    [Display(Name = "Наименование")] public string types_of_products_id { get; set; }
    [ForeignKey("types_id")]
    public TypesOfProducts? TypesOfProducts { get; set; }

    [Display(Name = "Прямые")] public double direct_costs { get; set; }
    
    [Display(Name = "Накладные производственные")] public double overhead_production_costs { get; set; }
    
    [Display(Name = "Накладные общехозяйственные")] public double general_business_invoices { get; set; }

    [Display(Name = "Единицы измерения")] public int units_id { get; set; }
    [ForeignKey("units_id")]
    public Units? Units { get; set; }
}