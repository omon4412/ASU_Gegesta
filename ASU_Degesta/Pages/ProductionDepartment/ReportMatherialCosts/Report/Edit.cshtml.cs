using ASU_Degesta.Models.Handbooks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportMatherialCosts.Report
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

        [BindProperty]
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

            this.ReportMatherialCosts = ReportMatherialCosts;
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

            _context.Attach(ReportMatherialCosts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportMatherialCostsExists(ReportMatherialCosts.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Details", new {id = ReportMatherialCosts.doc_id});
        }

        private bool ReportMatherialCostsExists(int id)
        {
            return (_context.ReportMatherialCosts?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}