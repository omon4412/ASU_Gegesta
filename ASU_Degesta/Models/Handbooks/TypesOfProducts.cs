using System.ComponentModel.DataAnnotations;

namespace ASU_Degesta.Models.Handbooks;

public class TypesOfProducts
{
    [Key] 
    [Display(Name = "Код изделия")] 
    public string TypesOfProductsId { get; set; }
    
    [Display(Name = "Тип изделия")] 
    public string Name { get; set; }
}