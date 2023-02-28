using ASU_Degesta.Models.Handbooks;
using ASU_Degesta.Models.ProductionDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportCostsProductionCapacity.Report
{
    [Authorize(Roles = "admin, Начальник производственного отдела")]
    public class EditModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;
        public List<Equipments> EquipmentsList;
        public List<TypesOfProducts> TypesOfProductsList;

        public EditModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
            EquipmentsList = _context.Equipments.AsNoTracking().ToList();
            TypesOfProductsList = _context.TypesOfProducts.AsNoTracking().ToList();
        }

        [BindProperty] public Models.ProductionDepartment.ReportCostsProductionCapacity ReportCostsProductionCapacity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string docid, int? id)
        {
            if (id == null || docid == null || _context.ReportCostsProductionCapacity == null)
            {
                return NotFound();
            }

            var ReportCostsProductionCapacity =
                await _context.ReportCostsProductionCapacity.FirstOrDefaultAsync(m => m.id == id && m.doc_id == docid);
            if (ReportCostsProductionCapacity == null)
            {
                return NotFound();
            }

            this.ReportCostsProductionCapacity = ReportCostsProductionCapacity;
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

            _context.Attach(ReportCostsProductionCapacity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportCostsProductionCapacityExists(ReportCostsProductionCapacity.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Details", new {id = ReportCostsProductionCapacity.doc_id});
        }

        private bool ReportCostsProductionCapacityExists(int id)
        {
            return (_context.ReportCostsProductionCapacity?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}