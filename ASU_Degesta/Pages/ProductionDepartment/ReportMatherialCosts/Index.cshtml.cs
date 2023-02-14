using ASU_Degesta.Models.ProductionDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportMatherialCosts
{
    [Authorize(Roles = "admin, Начальник производственного отдела")]
    public class IndexModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public IndexModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        public IList<ReportMatherialCosts_id> ReportMatherialCosts_id { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ReportProductPlan_id != null)
            {
                ReportMatherialCosts_id = await _context.ReportMatherialCosts_id.ToListAsync();
            }
        }
    }
}