using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASU_Degesta.Data;
using ASU_Degesta.Models.Handbooks;
using ASU_Degesta.Models.ProductionDepartment;
using Microsoft.AspNetCore.Authorization;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportProductPlan.Report
{
    [Authorize(Roles = "admin, Начальник производственного отдела")]
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

        [BindProperty] public Models.ProductionDepartment.ReportProductPlan ReportProductPlan { get; set; } = default!;

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