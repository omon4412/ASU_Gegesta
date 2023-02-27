using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASU_Degesta.Models.Handbooks;

namespace ASU_Degesta.Models.ProductionDepartment;

public class ReportAvailableEquipmentPerformance
{
    [Key] public int id { get; set; }

    [Display(Name = "Номер документа")] public string doc_id { get; set; }
    [ForeignKey("doc_id")]
    public ReportAvailableEquipmentPerformance_id? ReportProductPlan_id { get; set; }

    [Display(Name = "Станок")] public int EquipmentId { get; set; }
    [ForeignKey("EquipmentId")]
    public Equipments? Equipments { get; set; }

    [Display(Name = "Производительность")] public int perfomance { get; set; }

    [Display(Name = "Единицы измерения")] public int units_id { get; set; }
    [ForeignKey("units_id")]
    public Units? Units { get; set; }
}