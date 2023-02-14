using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASU_Degesta.Data;
using ASU_Degesta.Models.Handbooks;
using ASU_Degesta.Models.ProductionDepartment;
using Microsoft.AspNetCore.Authorization;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportProductPlan.Report
{
    [Authorize(Roles = "admin, Начальник производственного отдела")]
    public class EditModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;
        public List<TypesOfProducts> TypesOfProductsList;
        public List<Units> UnitsList;

        public EditModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
            TypesOfProductsList = _context.TypesOfProducts.AsNoTracking().ToList();
            UnitsList = _context.Units.AsNoTracking().ToList();
        }

        [BindProperty] public Models.ProductionDepartment.ReportProductPlan ReportProductPlan { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string docid, int? id)
        {
            if (id == null || docid == null || _context.ReportProductPlan == null)
            {
                return NotFound();
            }

            var reportproductplan =
                await _context.ReportProductPlan.FirstOrDefaultAsync(m => m.id == id && m.doc_id == docid);
            if (reportproductplan == null)
            {
                return NotFound();
            }

            ReportProductPlan = reportproductplan;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ReportProductPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportProductPlanExists(ReportProductPlan.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Details", new {id = ReportProductPlan.doc_id});
        }

        private bool ReportProductPlanExists(int id)
        {
            return (_context.ReportProductPlan?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}