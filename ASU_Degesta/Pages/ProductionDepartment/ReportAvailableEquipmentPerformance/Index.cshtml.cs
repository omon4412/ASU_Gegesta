using ASU_Degesta.Models.ProductionDepartment;
using ASU_Degesta.Models.SalesDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportAvailableEquipmentPerformance
{
    [Authorize(Roles = "admin, Начальник производственного отдела")]
    public class IndexModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public IndexModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        public IList<ReportAvailableEquipmentPerformance_id> ReportAvailableEquipmentPerformance_id { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ReportAvailableEquipmentPerformance_id != null)
            {
                ReportAvailableEquipmentPerformance_id = await _context.ReportAvailableEquipmentPerformance_id.OrderByDescending(x=>x.creation_date).ToListAsync();
            }
        }
    }
}