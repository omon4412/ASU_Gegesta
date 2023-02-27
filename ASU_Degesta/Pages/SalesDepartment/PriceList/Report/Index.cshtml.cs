using ASU_Degesta.Models.Handbooks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.SalesDepartment.PriceList.Report
{
    [Authorize(Roles = "admin, Менеджер по продажам")]
    public class IndexModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public List<TypesOfProducts> TypesOfProductsList;
        public List<Units> UnitsList;

        public IndexModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
            TypesOfProductsList = _context.TypesOfProducts.AsNoTracking().ToList();
            UnitsList = _context.Units.AsNoTracking().ToList();
        }

        public IList<Models.SalesDepartment.PriceList> PriceList { get; set; } = default!;

        public async Task<NotFoundResult> OnGetAsync()
        {
            return NotFound();
            if (_context.PriceList != null)
            {
                PriceList = await _context.PriceList.ToListAsync();
            }
        }
    }
}