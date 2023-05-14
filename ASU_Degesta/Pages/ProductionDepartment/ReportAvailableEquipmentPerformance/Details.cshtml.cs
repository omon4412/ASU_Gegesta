using ASU_Degesta.Models.Handbooks;
using ASU_Degesta.Models.ProductionDepartment;
using ASU_Degesta.Models.SalesDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportAvailableEquipmentPerformance
{
    public class DetailsModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public DetailsModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
            EquipmentsList = _context.Equipments.AsNoTracking().ToList();
            UnitsList = _context.Units.AsNoTracking().ToList();
        }

        public IList<Models.ProductionDepartment.ReportAvailableEquipmentPerformance>
            ReportAvailableEquipmentPerformance { get; set; } = default!;

        public List<Equipments> EquipmentsList;
        public List<Units> UnitsList;
        public List<ReportAvailableEquipmentPerformance_id> info { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null || _context.ReportAvailableEquipmentPerformance_id == null)
            {
                return NotFound();
            }

            info = await _context.ReportAvailableEquipmentPerformance_id.Where(x => x.doc_id == id).ToListAsync();
            if (info.Count == 0)
            {
                return NotFound();
            }

            ReportAvailableEquipmentPerformance = await _context.ReportAvailableEquipmentPerformance
                .Where(x => String.Equals(x.doc_id, id)).OrderBy(x => x.EquipmentId).ToListAsync();

            return Page();
        }
    }
}