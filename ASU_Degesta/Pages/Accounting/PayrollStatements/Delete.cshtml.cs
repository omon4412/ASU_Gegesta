using ASU_Degesta.Models.Accounting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.Accounting.PayrollStatements
{
    [Authorize(Roles = "admin, Бухгалтер")]
    public class DeleteModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public DeleteModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        [BindProperty] public payroll_statement_name_id payroll_statement { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.payroll_statement == null)
            {
                return NotFound();
            }

            var payroll_statement = await _context.payroll_statement_name_id
                .FirstOrDefaultAsync(m => m.doc_id == id);

            if (payroll_statement == null)
            {
                return NotFound();
            }
            else
            {
                this.payroll_statement = payroll_statement;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.payroll_statement == null)
            {
                return NotFound();
            }

            var payroll_statement = await _context.payroll_statement_name_id.FindAsync(id);

            if (payroll_statement != null)
            {
                this.payroll_statement = payroll_statement;
                _context.payroll_statement_name_id.Remove(payroll_statement);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}