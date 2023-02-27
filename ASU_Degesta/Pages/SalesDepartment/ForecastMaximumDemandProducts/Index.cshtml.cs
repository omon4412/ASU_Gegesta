using ASU_Degesta.Models.PED;
using ASU_Degesta.Models.SalesDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.SalesDepartment.ForecastMaximumDemandProducts
{
    [Authorize(Roles = "admin, Менеджер по продажам")]
    public class IndexModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public IndexModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        public IList<ForecastMaximumDemandProducts_id> ForecastMaximumDemandProducts_id { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ForecastMaximumDemandProducts_id != null)
            {
                ForecastMaximumDemandProducts_id = await _context.ForecastMaximumDemandProducts_id.OrderByDescending(x=>x.creation_date).ToListAsync();
            }
        }
    }
}