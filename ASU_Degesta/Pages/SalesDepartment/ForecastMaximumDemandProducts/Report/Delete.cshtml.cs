using ASU_Degesta.Models.Handbooks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.SalesDepartment.ForecastMaximumDemandProducts.Report
{
    [Authorize(Roles = "admin, Менеджер по продажам")]
    public class DeleteModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;
        public List<TypesOfProducts> TypesOfProductsList;
        public List<Units> UnitsList;

        public DeleteModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
            TypesOfProductsList = _context.TypesOfProducts.AsNoTracking().ToList();
            UnitsList = _context.Units.AsNoTracking().ToList();
        }

        [BindProperty] public Models.SalesDepartment.ForecastMaximumDemandProducts ForecastMaximumDemandProducts { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ForecastMaximumDemandProducts == null)
            {
                return NotFound();
            }

            var ForecastMaximumDemandProducts = await _context.ForecastMaximumDemandProducts.FirstOrDefaultAsync(m => m.id == id);

            if (ForecastMaximumDemandProducts == null)
            {
                return NotFound();
            }
            else
            {
                this.ForecastMaximumDemandProducts = ForecastMaximumDemandProducts;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string docid, int? id)
        {
            if (id == null || docid == null || _context.ForecastMaximumDemandProducts == null)
            {
                return NotFound();
            }

            var ForecastMaximumDemandProducts = await _context.ForecastMaximumDemandProducts
                .FirstOrDefaultAsync(m => m.id == id && m.doc_id == docid);

            if (ForecastMaximumDemandProducts != null)
            {
                this.ForecastMaximumDemandProducts = ForecastMaximumDemandProducts;
                _context.ForecastMaximumDemandProducts.Remove(ForecastMaximumDemandProducts);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../Details", new {id = ForecastMaximumDemandProducts.doc_id});
        }
    }
}