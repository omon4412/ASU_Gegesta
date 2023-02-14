using ASU_Degesta.Models.ProductionDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportMatherialCosts
{
    [Authorize(Roles = "admin, Начальник производственного отдела")]
    public class DeleteModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public DeleteModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        [BindProperty] public ReportMatherialCosts_id ReportMatherialCosts_id { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.ReportMatherialCosts_id == null)
            {
                return NotFound();
            }

            var ReportMatherialCosts_id =
                await _context.ReportMatherialCosts_id.FirstOrDefaultAsync(m => m.doc_id == id);

            if (ReportMatherialCosts_id == null)
            {
                return NotFound();
            }
            else
            {
                this.ReportMatherialCosts_id = ReportMatherialCosts_id;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.ReportMatherialCosts_id == null)
            {
                return NotFound();
            }

            var ReportMatherialCosts_id = await _context.ReportMatherialCosts_id.FindAsync(id);

            if (ReportMatherialCosts_id != null)
            {
                this.ReportMatherialCosts_id = ReportMatherialCosts_id;
                _context.ReportMatherialCosts_id.Remove(ReportMatherialCosts_id);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}