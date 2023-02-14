using System.ComponentModel.DataAnnotations;
namespace ASU_Degesta.Models.Handbooks;

public class types_of_products
{
    [Key] 
    public int types_of_products_id { get; set; }
    
    [Display(Name = "Код")] 
    public string code { get; set; }
    
    [Display(Name = "Название")] 
    public string Name { get; set; }
}