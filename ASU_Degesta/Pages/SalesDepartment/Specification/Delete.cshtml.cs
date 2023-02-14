using ASU_Degesta.Models;
using ASU_Degesta.Models.SalesDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.SalesDepartment.Specification
{
    [Authorize(Roles = "admin, Менеджер по продажам")]
    public class DeleteModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public DeleteModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SpecificationContractMaterials_id SpecificationContractMaterials_id { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.SpecificationContractMaterials_id == null)
            {
                return NotFound();
            }

            var specificationcontractmaterials_id =
                await _context.SpecificationContractMaterials_id.FirstOrDefaultAsync(m => m.doc_id == id);

            if (specificationcontractmaterials_id == null)
            {
                return NotFound();
            }
            else
            {
                SpecificationContractMaterials_id = specificationcontractmaterials_id;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.SpecificationContractMaterials_id == null)
            {
                return NotFound();
            }

            var specificationcontractmaterials_id = await _context.SpecificationContractMaterials_id.FindAsync(id);

            if (specificationcontractmaterials_id != null)
            {
                SpecificationContractMaterials_id = specificationcontractmaterials_id;
                _context.SpecificationContractMaterials_id.Remove(SpecificationContractMaterials_id);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}