using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASU_Degesta.Models.Accounting
{
    public class payroll_statement
    {
        [Key] public int id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Номер документа")]
        public string doc_id { get; set; }

        [ForeignKey("doc_id")] public payroll_statement_name_id? payroll_statement_name_id { get; set; }

        [Display(Name = "Табельный номер")] public int employee_number { get; set; }

        [Display(Name = "Фамилия И.О.")] public string employee_name { get; set; }

        [Display(Name = "Оклад (ден.ед.)")] public double salary { get; set; }

        [Display(Name = "Премия (ден.ед.)")] public double bonus { get; set; }

        [Display(Name = "Всего начислено (ден.ед.)")]
        public double total_accrued { get; set; }

        [Display(Name = "Удержания (ден.ед)")] public double withheld { get; set; }

        [Display(Name = "К выдаче (ден.ед)")] public double to_issue { get; set; }
    }
}