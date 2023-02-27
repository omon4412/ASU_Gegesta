using ASU_Degesta.Models.Handbooks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.SalesDepartment.PriceList.Report
{
    [Authorize(Roles = "admin, Менеджер по продажам")]
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

        [BindProperty] public Models.SalesDepartment.PriceList PriceList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PriceList == null)
            {
                return NotFound();
            }

            var PriceList = await _context.PriceList.FirstOrDefaultAsync(m => m.id == id);

            if (PriceList == null)
            {
                return NotFound();
            }
            else
            {
                this.PriceList = PriceList;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string docid, int? id)
        {
            if (id == null || docid == null || _context.PriceList == null)
            {
                return NotFound();
            }

            var PriceList = await _context.PriceList
                .FirstOrDefaultAsync(m => m.id == id && m.doc_id == docid);

            if (PriceList != null)
            {
                this.PriceList = PriceList;
                _context.PriceList.Remove(PriceList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../Details", new {id = PriceList.doc_id});
        }
    }
}