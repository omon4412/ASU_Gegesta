using ASU_Degesta.Models.Handbooks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.PED.ReportProductsCost.Report
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

        public Models.PED.ReportProductCost reportProductCost { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string docid, int? id)
        {
            if (id == null || docid == null || _context.ReportProductCost == null)
            {
                return NotFound();
            }

            var ReportProductCost =
                await _context.ReportProductCost.FirstOrDefaultAsync(m => m.id == id && m.doc_id == docid);
            if (ReportProductCost == null)
            {
                return NotFound();
            }
            else
            {
                this.reportProductCost = ReportProductCost;
            }

            return Page();
        }
    }
}