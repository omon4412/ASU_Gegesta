using System.ComponentModel.DataAnnotations;

namespace ASU_Degesta.Models.Handbooks;

public class Units
{
    [Key]
    public int Units_ID { get; set; }
    
    [Display(Name = "Единицы измерения")] 
    public string Name { get; set; }
}