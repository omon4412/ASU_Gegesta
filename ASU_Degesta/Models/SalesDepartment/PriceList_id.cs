using System.ComponentModel.DataAnnotations;

namespace ASU_Degesta.Models.SalesDepartment;

public class PriceList_id
{
    [Key]
    [Display(Name = "Номер документа")]
    public string doc_id { get; set; }

    [Display(Name = "Название документа")]
    public string doc_name { get; set; }
    
    [Display(Name = "Дата создания")]
    public string creation_date { get; set; }
    
    [Display(Name = "Создатель")]
    public string creator { get; set; }
}