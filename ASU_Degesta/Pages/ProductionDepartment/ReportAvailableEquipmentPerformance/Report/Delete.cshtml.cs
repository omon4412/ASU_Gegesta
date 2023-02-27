using ASU_Degesta.Models.Handbooks;
using ASU_Degesta.Models.ProductionDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportAvailableEquipmentPerformance.Report
{
    [Authorize(Roles = "admin, Начальник производственного отдела")]
    public class DeleteModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;
        public List<Equipments> EquipmentsList;
        public List<Units> UnitsList;

        public DeleteModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
            EquipmentsList = _context.Equipments.AsNoTracking().ToList();
            UnitsList = _context.Units.AsNoTracking().ToList();
        }

        [BindProperty] public Models.ProductionDepartment.ReportAvailableEquipmentPerformance ReportAvailableEquipmentPerformance { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ReportAvailableEquipmentPerformance == null)
            {
                return NotFound();
            }

            var ReportAvailableEquipmentPerformance = await _context.ReportAvailableEquipmentPerformance.FirstOrDefaultAsync(m => m.id == id);

            if (ReportAvailableEquipmentPerformance == null)
            {
                return NotFound();
            }
            else
            {
                this.ReportAvailableEquipmentPerformance = ReportAvailableEquipmentPerformance;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string docid, int? id)
        {
            if (id == null || docid == null || _context.ReportAvailableEquipmentPerformance == null)
            {
                return NotFound();
            }

            var ReportAvailableEquipmentPerformance = await _context.ReportAvailableEquipmentPerformance
                .FirstOrDefaultAsync(m => m.id == id && m.doc_id == docid);

            if (ReportAvailableEquipmentPerformance != null)
            {
                this.ReportAvailableEquipmentPerformance = ReportAvailableEquipmentPerformance;
                _context.ReportAvailableEquipmentPerformance.Remove(ReportAvailableEquipmentPerformance);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../Details", new {id = ReportAvailableEquipmentPerformance.doc_id});
        }
    }
}