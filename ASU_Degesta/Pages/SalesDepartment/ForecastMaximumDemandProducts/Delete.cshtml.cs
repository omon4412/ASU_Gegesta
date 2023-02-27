using ASU_Degesta.Models.PED;
using ASU_Degesta.Models.SalesDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.SalesDepartment.ForecastMaximumDemandProducts
{
    [Authorize(Roles = "admin, Менеджер по продажам")]
    public class DeleteModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public DeleteModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        [BindProperty] public ForecastMaximumDemandProducts_id ForecastMaximumDemandProducts_id { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.ForecastMaximumDemandProducts_id == null)
            {
                return NotFound();
            }

            var ForecastMaximumDemandProducts_id = await _context.ForecastMaximumDemandProducts_id.FirstOrDefaultAsync(m => m.doc_id == id);

            if (ForecastMaximumDemandProducts_id == null)
            {
                return NotFound();
            }
            else
            {
                this.ForecastMaximumDemandProducts_id = ForecastMaximumDemandProducts_id;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.ForecastMaximumDemandProducts_id == null)
            {
                return NotFound();
            }

            var ForecastMaximumDemandProducts_id = await _context.ForecastMaximumDemandProducts_id.FindAsync(id);

            if (ForecastMaximumDemandProducts_id != null)
            {
                this.ForecastMaximumDemandProducts_id = ForecastMaximumDemandProducts_id;
                _context.ForecastMaximumDemandProducts_id.Remove(ForecastMaximumDemandProducts_id);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}