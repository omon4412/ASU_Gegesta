using ASU_Degesta.Models.Handbooks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.PED.MonthlyProductReleasePlan.Report
{
    [Authorize(Roles = "admin, Начальник планово-экономического отдела")]
    public class DetailsModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;
        public List<TypesOfProducts> TypesOfProductsList;
        public List<Units> UnitsList;

        public DetailsModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
            TypesOfProductsList = _context.TypesOfProducts.AsNoTracking().ToList();
            UnitsList = _context.Units.AsNoTracking().ToList();
        }

        public Models.PED.MonthlyProductReleasePlan MonthlyProductReleasePlan { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string docid, int? id)
        {
            if (id == null || docid == null || _context.MonthlyProductReleasePlan == null)
            {
                return NotFound();
            }

            var MonthlyProductReleasePlan =
                await _context.MonthlyProductReleasePlan.FirstOrDefaultAsync(m => m.id == id && m.doc_id == docid);
            if (MonthlyProductReleasePlan == null)
            {
                return NotFound();
            }
            else
            {
               this.MonthlyProductReleasePlan = MonthlyProductReleasePlan;
            }

            return Page();
        }
    }
}