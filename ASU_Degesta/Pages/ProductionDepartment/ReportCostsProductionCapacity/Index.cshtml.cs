using ASU_Degesta.Models.ProductionDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportCostsProductionCapacity
{
    [Authorize(Roles = "admin, Начальник производственного отдела")]
    public class IndexModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public IndexModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        public IList<ReportCostsProductionCapacity_id> ReportCostsProductionCapacity_id { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ReportCostsProductionCapacity_id != null)
            {
                ReportCostsProductionCapacity_id = await _context.ReportCostsProductionCapacity_id.OrderByDescending(x=>x.creation_date).ToListAsync();
            }
        }
    }
}