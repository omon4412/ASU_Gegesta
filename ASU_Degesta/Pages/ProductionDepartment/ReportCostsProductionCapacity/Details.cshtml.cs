using ASU_Degesta.Models.Handbooks;
using ASU_Degesta.Models.ProductionDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportCostsProductionCapacity
{
    [Authorize(Roles = "admin, Начальник производственного отдела")]
    public class DetailsModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public DetailsModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
            EquipmentsList = _context.Equipments.AsNoTracking().ToList();
            TypesOfProductsList = _context.TypesOfProducts.AsNoTracking().ToList();
        }

        public IList<Models.ProductionDepartment.ReportCostsProductionCapacity>
            ReportCostsProductionCapacity { get; set; } = default!;

        public List<Equipments> EquipmentsList;
        public List<TypesOfProducts> TypesOfProductsList;
        public List<ReportCostsProductionCapacity_id> info { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null || _context.ReportCostsProductionCapacity_id == null)
            {
                return NotFound();
            }

            info = await _context.ReportCostsProductionCapacity_id.Where(x => x.doc_id == id).ToListAsync();
            if (info.Count == 0)
            {
                return NotFound();
            }

            ReportCostsProductionCapacity = await _context.ReportCostsProductionCapacity
                .Where(x => String.Equals(x.doc_id, id)).OrderBy(x => x.EquipmentId).ToListAsync();

            return Page();
        }
    }
}