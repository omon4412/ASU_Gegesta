using ASU_Degesta.Models.PED;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.PED.ReportProductsCost
{
    [Authorize(Roles = "admin, Начальник планово-экономического отдела")]
    public class DeleteModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public DeleteModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        [BindProperty] public ReportProductCost_id ReportProductCost_id { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.ReportProductCost_id == null)
            {
                return NotFound();
            }

            var ReportProductCost_id =
                await _context.ReportProductCost_id.FirstOrDefaultAsync(m => m.doc_id == id);

            if (ReportProductCost_id == null)
            {
                return NotFound();
            }
            else
            {
                this.ReportProductCost_id = ReportProductCost_id;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.ReportProductCost_id == null)
            {
                return NotFound();
            }

            var ReportProductCost_id = await _context.ReportProductCost_id.FindAsync(id);

            if (ReportProductCost_id != null)
            {
                this.ReportProductCost_id = ReportProductCost_id;
                _context.ReportProductCost_id.Remove(ReportProductCost_id);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}