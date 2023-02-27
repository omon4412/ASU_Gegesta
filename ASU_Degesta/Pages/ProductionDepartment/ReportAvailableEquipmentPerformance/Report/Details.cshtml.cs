using ASU_Degesta.Models.Handbooks;
using ASU_Degesta.Models.ProductionDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportAvailableEquipmentPerformance.Report
{
    [Authorize(Roles = "admin, Начальник производственного отдела")]
    public class DetailsModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;
        public List<Equipments> EquipmentsList;
        public List<Units> UnitsList;

        public DetailsModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
            EquipmentsList = _context.Equipments.AsNoTracking().ToList();
            UnitsList = _context.Units.AsNoTracking().ToList();
        }

        public Models.ProductionDepartment.ReportAvailableEquipmentPerformance ReportAvailableEquipmentPerformance { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string docid, int? id)
        {
            if (id == null || docid == null || _context.ReportAvailableEquipmentPerformance == null)
            {
                return NotFound();
            }

            var ReportAvailableEquipmentPerformance =
                await _context.ReportAvailableEquipmentPerformance.FirstOrDefaultAsync(m => m.id == id && m.doc_id == docid);
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
    }
}