using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASU_Degesta.Data;
using ASU_Degesta.Models.ProductionDepartment;
using Microsoft.AspNetCore.Authorization;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportProductPlan
{
    [Authorize(Roles = "admin, Начальник производственного отдела")]
    public class DeleteModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public DeleteModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        [BindProperty] public ReportProductPlan_id ReportProductPlan_id { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.ReportProductPlan_id == null)
            {
                return NotFound();
            }

            var reportproductplan_id = await _context.ReportProductPlan_id.FirstOrDefaultAsync(m => m.doc_id == id);

            if (reportproductplan_id == null)
            {
                return NotFound();
            }
            else
            {
                ReportProductPlan_id = reportproductplan_id;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.ReportProductPlan_id == null)
            {
                return NotFound();
            }

            var reportproductplan_id = await _context.ReportProductPlan_id.FindAsync(id);

            if (reportproductplan_id != null)
            {
                ReportProductPlan_id = reportproductplan_id;
                _context.ReportProductPlan_id.Remove(ReportProductPlan_id);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}