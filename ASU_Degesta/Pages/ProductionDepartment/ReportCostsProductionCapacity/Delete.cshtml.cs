using ASU_Degesta.Models.ProductionDepartment;
using ASU_Degesta.Models.SalesDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportCostsProductionCapacity
{
    [Authorize(Roles = "admin, Начальник производственного отдела")]
    public class DeleteModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public DeleteModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        [BindProperty] public ReportCostsProductionCapacity_id ReportCostsProductionCapacity_id { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.ReportCostsProductionCapacity_id == null)
            {
                return NotFound();
            }

            var ReportCostsProductionCapacity_id = await _context.ReportCostsProductionCapacity_id.FirstOrDefaultAsync(m => m.doc_id == id);

            if (ReportCostsProductionCapacity_id == null)
            {
                return NotFound();
            }
            else
            {
                this.ReportCostsProductionCapacity_id = ReportCostsProductionCapacity_id;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.ReportCostsProductionCapacity_id == null)
            {
                return NotFound();
            }

            var ReportCostsProductionCapacity_id = await _context.ReportCostsProductionCapacity_id.FindAsync(id);

            if (ReportCostsProductionCapacity_id != null)
            {
                this.ReportCostsProductionCapacity_id = ReportCostsProductionCapacity_id;
                _context.ReportCostsProductionCapacity_id.Remove(ReportCostsProductionCapacity_id);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}