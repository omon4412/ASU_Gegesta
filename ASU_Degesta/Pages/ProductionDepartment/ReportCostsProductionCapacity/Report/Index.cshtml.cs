using ASU_Degesta.Models.Handbooks;
using ASU_Degesta.Models.ProductionDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportCostsProductionCapacity.Report
{
    [Authorize(Roles = "admin, Начальник производственного отдела")]
    public class IndexModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public List<Equipments> EquipmentsList;
        public List<TypesOfProducts> TypesOfProductsList;

        public IndexModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
            EquipmentsList = _context.Equipments.AsNoTracking().ToList();
            TypesOfProductsList = _context.TypesOfProducts.AsNoTracking().ToList();
        }

        public IList<Models.ProductionDepartment.ReportCostsProductionCapacity> ReportCostsProductionCapacity { get; set; } = default!;

        public async Task<NotFoundResult> OnGetAsync()
        {
            return NotFound();
            if (_context.ReportCostsProductionCapacity != null)
            {
                ReportCostsProductionCapacity = await _context.ReportCostsProductionCapacity.ToListAsync();
            }
        }
    }
}