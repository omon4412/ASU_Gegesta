using ASU_Degesta.Models;
using ASU_Degesta.Models.SalesDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.SalesDepartment.Specification
{
    [Authorize(Roles = "admin, Менеджер по продажам")]
    public class IndexModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public IndexModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        public IList<SpecificationContractMaterials_id> SpecificationContractMaterials_id { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SpecificationContractMaterials_id != null)
            {
                SpecificationContractMaterials_id = await _context.SpecificationContractMaterials_id.OrderByDescending(x=>x.creation_date).ToListAsync();
            }
        }
    }
}