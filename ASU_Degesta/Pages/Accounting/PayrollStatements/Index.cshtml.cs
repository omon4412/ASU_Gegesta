using ASU_Degesta.Models.Accounting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.Accounting.PayrollStatements
{
    [Authorize(Roles = "admin, Бухгалтер")]
    public class IndexModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public IndexModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        public IList<payroll_statement_name_id> payroll_statement { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.payroll_statement_name_id != null)
            {
                payroll_statement = await _context.payroll_statement_name_id.OrderByDescending(x=>x.creation_date).ToListAsync();
            }
        }
    }
}