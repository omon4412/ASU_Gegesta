using ASU_Degesta.Models;
using ASU_Degesta.Models.Handbooks;
using ASU_Degesta.Models.SalesDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.SalesDepartment.Specification
{
    [Authorize(Roles = "admin, Менеджер по продажам")]
    public class DetailsModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public DetailsModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
            TypesOfProductsList = _context.TypesOfProducts.AsNoTracking().ToList();
            UnitsList = _context.Units.AsNoTracking().ToList();
        }

        public IList<SpecificationContractMaterials> SpecificationContractMaterials { get; set; } = default!;
        public List<TypesOfProducts> TypesOfProductsList;
        public List<Units> UnitsList;
        public List<SpecificationContractMaterials_id> info { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null || _context.SpecificationContractMaterials_id == null)
            {
                return NotFound();
            }

            info = await _context.SpecificationContractMaterials_id.Where(x => x.doc_id == id).ToListAsync();
            if (info.Count == 0)
            {
                return NotFound();
            }

            SpecificationContractMaterials = await _context.SpecificationContractMaterials
                .Where(x => String.Equals(x.doc_id, id)).ToListAsync();

            return Page();
        }
    }
}