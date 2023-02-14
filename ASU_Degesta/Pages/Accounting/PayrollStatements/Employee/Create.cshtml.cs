using ASU_Degesta.Models.Accounting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASU_Degesta.Pages.Accounting.PayrollStatements.Employee
{
    [Authorize(Roles = "admin, Бухгалтер")]
    public class CreateModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public CreateModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        public string idd;

        public IActionResult OnGetAsync(string docid, int? id)
        {
            idd = docid;
            return Page();
        }

        [BindProperty] public payroll_statement payroll_statement { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.payroll_statement == null || payroll_statement == null)
            {
                return Page();
            }

            _context.payroll_statement.Add(payroll_statement);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Details", new {id = payroll_statement.doc_id});
        }
    }
}