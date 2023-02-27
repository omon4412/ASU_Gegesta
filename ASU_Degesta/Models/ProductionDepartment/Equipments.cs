using System.ComponentModel.DataAnnotations;

namespace ASU_Degesta.Models.ProductionDepartment;

public class Equipments
{
    [Key]
    public int EquipmentId { get; set; }
    [Display(Name = "Станок")]
    public string EquipmentName { get; set; }
}