using ASU_Degesta.Models;
using ASU_Degesta.Models.Handbooks;
using ASU_Degesta.Models.SalesDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.SalesDepartment.Specification.Contract
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

        [BindProperty] public SpecificationContractMaterials SpecificationContractMaterials { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SpecificationContractMaterials == null)
            {
                return NotFound();
            }

            var specificationcontractmaterials =
                await _context.SpecificationContractMaterials.FirstOrDefaultAsync(m => m.id == id);

            if (specificationcontractmaterials == null)
            {
                return NotFound();
            }
            else
            {
                SpecificationContractMaterials = specificationcontractmaterials;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string docid, int? id)
        {
            if (id == null || docid == null || _context.SpecificationContractMaterials == null)
            {
                return NotFound();
            }

            var specificationcontractmaterials = await _context.SpecificationContractMaterials
                .FirstOrDefaultAsync(m => m.id == id && m.doc_id == docid);

            if (specificationcontractmaterials != null)
            {
                SpecificationContractMaterials = specificationcontractmaterials;
                _context.SpecificationContractMaterials.Remove(SpecificationContractMaterials);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../Details", new {id = SpecificationContractMaterials.doc_id});
        }
    }
}