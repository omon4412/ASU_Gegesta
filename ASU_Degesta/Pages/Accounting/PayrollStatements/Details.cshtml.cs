using ASU_Degesta.Models.Accounting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.Accounting.PayrollStatements
{
    [Authorize(Roles = "admin, Бухгалтер")]
    public class DetailsModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public DetailsModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        public IList<payroll_statement> payroll_statement { get; set; } = default!;
        public List<payroll_statement_name_id> info { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null || _context.payroll_statement == null)
            {
                return NotFound();
            }

            info = await _context.payroll_statement_name_id.Where(x => x.doc_id == id).ToListAsync();
            if (info.Count == 0)
            {
                return NotFound();
            }

            payroll_statement = await _context.payroll_statement.Where(x => String.Equals(x.doc_id, id)).ToListAsync();

            return Page();
        }
    }
}