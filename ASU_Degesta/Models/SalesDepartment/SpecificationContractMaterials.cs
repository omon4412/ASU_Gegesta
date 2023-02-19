using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASU_Degesta.Models.Handbooks;

namespace ASU_Degesta.Models.SalesDepartment
{
    public class SpecificationContractMaterials
    {
        [Key] public int id { get; set; }

        [Display(Name = "Номер документа")] public string doc_id { get; set; }
        [ForeignKey("doc_id")]
        public SpecificationContractMaterials_id? SpecificationContractMaterials_id { get; set; }

        [Display(Name = "Наименование")]
        public string types_of_products_id { get; set; }
        [ForeignKey("types_of_products_id")]
        public TypesOfProducts? TypesOfProducts { get; set; }

        [Display(Name = "Количество")] public int count_of_matherials { get; set; }

        [Display(Name = "Цена за единицу")] public double price_per_unit { get; set; }

        [Display(Name = "Стоимость")] public double price { get; set; }

        [Display(Name = "Единицы измерения")] public int units_id { get; set; }
        [ForeignKey("units_id")]
        public Units? Units { get; set; }
    }
}