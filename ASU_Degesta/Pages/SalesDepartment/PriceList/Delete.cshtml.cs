using ASU_Degesta.Models.PED;
using ASU_Degesta.Models.SalesDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.SalesDepartment.PriceList
{
    [Authorize(Roles = "admin, Менеджер по продажам")]
    public class DeleteModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public DeleteModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        [BindProperty] public PriceList_id PriceList_id { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.PriceList_id == null)
            {
                return NotFound();
            }

            var PriceList_id = await _context.PriceList_id.FirstOrDefaultAsync(m => m.doc_id == id);

            if (PriceList_id == null)
            {
                return NotFound();
            }
            else
            {
                this.PriceList_id = PriceList_id;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.PriceList_id == null)
            {
                return NotFound();
            }

            var PriceList_id = await _context.PriceList_id.FindAsync(id);

            if (PriceList_id != null)
            {
                this.PriceList_id = PriceList_id;
                _context.PriceList_id.Remove(PriceList_id);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}