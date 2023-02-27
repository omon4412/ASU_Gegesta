using ASU_Degesta.Models.Handbooks;
using ASU_Degesta.Models.ProductionDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportAvailableEquipmentPerformance.Report
{
    [Authorize(Roles = "admin, Начальник производственного отдела")]
    public class IndexModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public List<Equipments> EquipmentsList;
        public List<Units> UnitsList;

        public IndexModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
            EquipmentsList = _context.Equipments.AsNoTracking().ToList();
            UnitsList = _context.Units.AsNoTracking().ToList();
        }

        public IList<Models.ProductionDepartment.ReportAvailableEquipmentPerformance> ReportAvailableEquipmentPerformance { get; set; } = default!;

        public async Task<NotFoundResult> OnGetAsync()
        {
            return NotFound();
            if (_context.ReportAvailableEquipmentPerformance != null)
            {
                ReportAvailableEquipmentPerformance = await _context.ReportAvailableEquipmentPerformance.ToListAsync();
            }
        }
    }
}