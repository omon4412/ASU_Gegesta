using ASU_Degesta.Models.PED;
using ASU_Degesta.Models.ProductionDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.PED.MonthlyProductReleasePlan
{
    [Authorize(Roles = "admin, Начальник планово-экономического отдела")]
    public class DeleteModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public DeleteModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        [BindProperty] public MonthlyProductReleasePlan_id MonthlyProductReleasePlan_id { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.MonthlyProductReleasePlan_id == null)
            {
                return NotFound();
            }

            var MonthlyProductReleasePlan_id = await _context.MonthlyProductReleasePlan_id.FirstOrDefaultAsync(m => m.doc_id == id);

            if (MonthlyProductReleasePlan_id == null)
            {
                return NotFound();
            }
            else
            {
                this.MonthlyProductReleasePlan_id = MonthlyProductReleasePlan_id;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.MonthlyProductReleasePlan_id == null)
            {
                return NotFound();
            }

            var MonthlyProductReleasePlan_id = await _context.MonthlyProductReleasePlan_id.FindAsync(id);

            if (MonthlyProductReleasePlan_id != null)
            {
                this.MonthlyProductReleasePlan_id = MonthlyProductReleasePlan_id;
                _context.MonthlyProductReleasePlan_id.Remove(MonthlyProductReleasePlan_id);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}