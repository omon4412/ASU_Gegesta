using ASU_Degesta.Models.Handbooks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.SalesDepartment.ForecastMaximumDemandProducts.Report
{
    [Authorize(Roles = "admin, Менеджер по продажам")]
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

        [BindProperty] public Models.SalesDepartment.ForecastMaximumDemandProducts ForecastMaximumDemandProducts { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string docid, int? id)
        {
            if (id == null || docid == null || _context.ForecastMaximumDemandProducts == null)
            {
                return NotFound();
            }

            var ForecastMaximumDemandProducts =
                await _context.ForecastMaximumDemandProducts.FirstOrDefaultAsync(m => m.id == id && m.doc_id == docid);
            if (ForecastMaximumDemandProducts == null)
            {
                return NotFound();
            }

            this.ForecastMaximumDemandProducts = ForecastMaximumDemandProducts;
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

            _context.Attach(ForecastMaximumDemandProducts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForecastMaximumDemandProductsExists(ForecastMaximumDemandProducts.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Details", new {id = ForecastMaximumDemandProducts.doc_id});
        }

        private bool ForecastMaximumDemandProductsExists(int id)
        {
            return (_context.ForecastMaximumDemandProducts?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}