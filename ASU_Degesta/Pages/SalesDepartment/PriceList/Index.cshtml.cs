using ASU_Degesta.Models.SalesDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.SalesDepartment.PriceList
{
    [Authorize(Roles = "admin, Начальник планово-экономического отдела")]
    public class IndexModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public IndexModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        public IList<PriceList_id> PriceList_id { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PriceList_id != null)
            {
                PriceList_id = await _context.PriceList_id.OrderByDescending(x=>x.creation_date).ToListAsync();
            }
        }
    }
}