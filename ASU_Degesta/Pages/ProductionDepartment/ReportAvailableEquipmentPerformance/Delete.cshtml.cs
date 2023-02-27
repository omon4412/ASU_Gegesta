using ASU_Degesta.Models.ProductionDepartment;
using ASU_Degesta.Models.SalesDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportAvailableEquipmentPerformance
{
    [Authorize(Roles = "admin, Начальник производственного отдела")]
    public class DeleteModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public DeleteModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        [BindProperty] public ReportAvailableEquipmentPerformance_id ReportAvailableEquipmentPerformance_id { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.ReportAvailableEquipmentPerformance_id == null)
            {
                return NotFound();
            }

            var ReportAvailableEquipmentPerformance_id = await _context.ReportAvailableEquipmentPerformance_id.FirstOrDefaultAsync(m => m.doc_id == id);

            if (ReportAvailableEquipmentPerformance_id == null)
            {
                return NotFound();
            }
            else
            {
                this.ReportAvailableEquipmentPerformance_id = ReportAvailableEquipmentPerformance_id;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.ReportAvailableEquipmentPerformance_id == null)
            {
                return NotFound();
            }

            var ReportAvailableEquipmentPerformance_id = await _context.ReportAvailableEquipmentPerformance_id.FindAsync(id);

            if (ReportAvailableEquipmentPerformance_id != null)
            {
                this.ReportAvailableEquipmentPerformance_id = ReportAvailableEquipmentPerformance_id;
                _context.ReportAvailableEquipmentPerformance_id.Remove(ReportAvailableEquipmentPerformance_id);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}