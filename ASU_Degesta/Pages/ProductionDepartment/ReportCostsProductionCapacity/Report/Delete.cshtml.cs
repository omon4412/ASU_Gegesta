using ASU_Degesta.Models.Handbooks;
using ASU_Degesta.Models.ProductionDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportCostsProductionCapacity.Report
{
    [Authorize(Roles = "admin, Начальник производственного отдела")]
    public class DeleteModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;
        public List<Equipments> EquipmentsList;
        public List<TypesOfProducts> TypesOfProductsList;

        public DeleteModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
            EquipmentsList = _context.Equipments.AsNoTracking().ToList();
            TypesOfProductsList = _context.TypesOfProducts.AsNoTracking().ToList();
        }

        [BindProperty] public Models.ProductionDepartment.ReportCostsProductionCapacity ReportCostsProductionCapacity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ReportCostsProductionCapacity == null)
            {
                return NotFound();
            }

            var ReportCostsProductionCapacity = await _context.ReportCostsProductionCapacity.FirstOrDefaultAsync(m => m.id == id);

            if (ReportCostsProductionCapacity == null)
            {
                return NotFound();
            }
            else
            {
                this.ReportCostsProductionCapacity = ReportCostsProductionCapacity;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string docid, int? id)
        {
            if (id == null || docid == null || _context.ReportCostsProductionCapacity == null)
            {
                return NotFound();
            }

            var ReportCostsProductionCapacity = await _context.ReportCostsProductionCapacity
                .FirstOrDefaultAsync(m => m.id == id && m.doc_id == docid);

            if (ReportCostsProductionCapacity != null)
            {
                this.ReportCostsProductionCapacity = ReportCostsProductionCapacity;
                _context.ReportCostsProductionCapacity.Remove(ReportCostsProductionCapacity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../Details", new {id = ReportCostsProductionCapacity.doc_id});
        }
    }
}