using ASU_Degesta.Models.Handbooks;
using ASU_Degesta.Models.PED;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.PED.ReportProductsCost
{
    [Authorize(Roles = "admin, Начальник планово-экономического отдела")]
    public class DetailsModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public DetailsModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
            TypesOfProductsList = _context.TypesOfProducts.AsNoTracking().ToList();
            UnitsList = _context.Units.AsNoTracking().ToList();
        }

        public IList<Models.PED.ReportProductCost> ReportProductCost { get; set; } = default!;
        public List<TypesOfProducts> TypesOfProductsList;
        public List<Units> UnitsList;
        public List<ReportProductCost_id> info { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null || _context.ReportProductCost_id == null)
            {
                return NotFound();
            }

            info = await _context.ReportProductCost_id.Where(x => x.doc_id == id).ToListAsync();
            if (info.Count == 0)
            {
                return NotFound();
            }

            ReportProductCost =
                await _context.ReportProductCost.Where(x => String.Equals(x.doc_id, id)).OrderBy(x=>x.types_of_products_id).ToListAsync();

            return Page();
        }
    }
}