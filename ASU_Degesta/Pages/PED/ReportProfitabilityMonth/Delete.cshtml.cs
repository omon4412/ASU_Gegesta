using ASU_Degesta.Models.PED;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.PED.ReportProfitabilityMonth
{
    [Authorize(Roles = "admin, Начальник планово-экономического отдела")]
    public class DeleteModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public DeleteModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        [BindProperty] public ReportProfitabilityMonth_id ReportProfitabilityMonth_id { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.ReportProfitabilityMonth_id == null)
            {
                return NotFound();
            }

            var ReportProfitabilityMonth_id =
                await _context.ReportProfitabilityMonth_id.FirstOrDefaultAsync(m => m.doc_id == id);

            if (ReportProfitabilityMonth_id == null)
            {
                return NotFound();
            }
            else
            {
                this.ReportProfitabilityMonth_id = ReportProfitabilityMonth_id;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.ReportProfitabilityMonth_id == null)
            {
                return NotFound();
            }

            var ReportProfitabilityMonth_id = await _context.ReportProfitabilityMonth_id.FindAsync(id);

            if (ReportProfitabilityMonth_id != null)
            {
                this.ReportProfitabilityMonth_id = ReportProfitabilityMonth_id;
                _context.ReportProfitabilityMonth_id.Remove(ReportProfitabilityMonth_id);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}