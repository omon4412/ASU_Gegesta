using ASU_Degesta.Models.Accounting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.Accounting.PayrollStatements.Employee
{
    [Authorize(Roles = "admin, Бухгалтер")]
    public class DeleteModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public DeleteModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        [BindProperty] public payroll_statement payroll_statement { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string docid, int? id)
        {
            if (id == null || _context.payroll_statement == null)
            {
                return NotFound();
            }

            var payroll_statement = await _context.payroll_statement
                .FirstOrDefaultAsync(m => m.id == id && m.doc_id == docid);

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

        public async Task<IActionResult> OnPostAsync(string docid, int? id)
        {
            if (id == null || docid == null || _context.payroll_statement == null)
            {
                return NotFound();
            }

            var payroll_statement = await _context.payroll_statement
                .FirstOrDefaultAsync(m => m.id == id && m.doc_id == docid);

            if (payroll_statement != null)
            {
                this.payroll_statement = payroll_statement;
                _context.payroll_statement.Remove(payroll_statement);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../Details", new {id = payroll_statement.doc_id});
        }
    }
}