using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASU_Degesta.Models.Handbooks;

namespace ASU_Degesta.Models.ProductionDepartment;

public class ReportCostsProductionCapacity
{
    [Key] public int id { get; set; }

    [Display(Name = "Номер документа")] public string doc_id { get; set; }
    [ForeignKey("doc_id")]
    public ReportCostsProductionCapacity_id? ReportCostsProductionCapacity_id { get; set; }

    [Display(Name = "Станок")] public int EquipmentId { get; set; }
    [ForeignKey("EquipmentId")]
    public Equipments? Equipments { get; set; }
    
    [Display(Name = "Наименование")] public string types_of_products_id { get; set; }
    [ForeignKey("types_of_products_id")]
    public TypesOfProducts? TypesOfProducts { get; set; }

    [Display(Name = "Затраты")] public int costs { get; set; }
}