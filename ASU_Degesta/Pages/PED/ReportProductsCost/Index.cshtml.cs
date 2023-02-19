using ASU_Degesta.Models.PED;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.PED.ReportProductsCost
{
    [Authorize(Roles = "admin, Начальник планово-экономического отдела")]
    public class IndexModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public IndexModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        public IList<ReportProductCost_id> ReportProductCost_id { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ReportProductPlan_id != null)
            {
                ReportProductCost_id = await _context.ReportProductCost_id.OrderByDescending(x=>x.creation_date).ToListAsync();
            }
        }
    }
}