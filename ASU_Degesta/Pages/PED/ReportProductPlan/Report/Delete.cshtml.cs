using ASU_Degesta.Models.Handbooks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.PED.ReportProductPlan.Report
{
    [Authorize(Roles = "admin, Начальник планово-экономического отдела")]
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

        [BindProperty] public Models.PED.ReportProductPlan ReportProductPlan { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ReportProductPlan == null)
            {
                return NotFound();
            }

            var reportproductplan = await _context.ReportProductPlan.FirstOrDefaultAsync(m => m.id == id);

            if (reportproductplan == null)
            {
                return NotFound();
            }
            else
            {
                ReportProductPlan = reportproductplan;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string docid, int? id)
        {
            if (id == null || docid == null || _context.ReportProductPlan == null)
            {
                return NotFound();
            }

            var reportproductplan = await _context.ReportProductPlan
                .FirstOrDefaultAsync(m => m.id == id && m.doc_id == docid);

            if (reportproductplan != null)
            {
                ReportProductPlan = reportproductplan;
                _context.ReportProductPlan.Remove(ReportProductPlan);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../Details", new {id = ReportProductPlan.doc_id});
        }
    }
}