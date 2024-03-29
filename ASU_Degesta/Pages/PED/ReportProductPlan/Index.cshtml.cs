using ASU_Degesta.Models.PED;
using ASU_Degesta.Models.ProductionDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.PED.ReportProductPlan
{
    [Authorize(Roles = "admin, Начальник планово-экономического отдела")]
    public class IndexModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public IndexModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        public IList<ReportProductPlan_id> ReportProductPlan_id { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ReportProductPlan_id != null)
            {
                ReportProductPlan_id = await _context.ReportProductPlan_id.OrderByDescending(x=>x.creation_date).ToListAsync();
            }
        }
    }
}