using ASU_Degesta.Models.Accounting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.Accounting.PayrollStatements.Employee
{
    [Authorize(Roles = "admin, Бухгалтер")]
    public class EditModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public EditModel(ASU_Degesta.Data.ASU_DegestaContext context)
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

            var payroll_statement =
                await _context.payroll_statement.FirstOrDefaultAsync(m => m.id == id && m.doc_id == docid);
            if (payroll_statement == null)
            {
                return NotFound();
            }

            this.payroll_statement = payroll_statement;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(payroll_statement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!payroll_statementExists(payroll_statement.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Details", new {id = payroll_statement.doc_id});
        }

        private bool payroll_statementExists(int id)
        {
            return (_context.payroll_statement?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}