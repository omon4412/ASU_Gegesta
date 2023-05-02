using ASU_Degesta.Models.PED;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.PED.ReportProfitabilityMonth
{
    [Authorize(Roles = "admin, Начальник планово-экономического отдела")]
    public class IndexModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public IndexModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        public IList<ReportProfitabilityMonth_id> ReportProfitabilityMonth_id { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ReportProductPlan_id != null)
            {
                ReportProfitabilityMonth_id = await _context.ReportProfitabilityMonth_id.OrderByDescending(x=>x.creation_date).ToListAsync();
            }
        }
    }
}