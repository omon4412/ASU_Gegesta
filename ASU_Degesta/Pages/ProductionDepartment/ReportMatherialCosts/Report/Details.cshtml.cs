using ASU_Degesta.Models.Handbooks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportMatherialCosts.Report
{
    [Authorize(Roles = "admin, Начальник производственного отдела")]
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

        public Models.ProductionDepartment.ReportMatherialCosts ReportMatherialCosts { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string docid, int? id)
        {
            if (id == null || docid == null || _context.ReportMatherialCosts == null)
            {
                return NotFound();
            }

            var ReportMatherialCosts =
                await _context.ReportMatherialCosts.FirstOrDefaultAsync(m => m.id == id && m.doc_id == docid);
            if (ReportMatherialCosts == null)
            {
                return NotFound();
            }
            else
            {
                this.ReportMatherialCosts = ReportMatherialCosts;
            }

            return Page();
        }
    }
}