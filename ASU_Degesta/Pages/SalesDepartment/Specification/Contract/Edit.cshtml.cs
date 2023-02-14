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

        [BindProperty] public SpecificationContractMaterials SpecificationContractMaterials { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string docid, int? id)
        {
            if (id == null || docid == null || _context.SpecificationContractMaterials == null)
            {
                return NotFound();
            }

            var specificationcontractmaterials =
                await _context.SpecificationContractMaterials.FirstOrDefaultAsync(m => m.id == id && m.doc_id == docid);
            if (specificationcontractmaterials == null)
            {
                return NotFound();
            }

            SpecificationContractMaterials = specificationcontractmaterials;
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

            _context.Attach(SpecificationContractMaterials).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecificationContractMaterialsExists(SpecificationContractMaterials.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Details", new {id = SpecificationContractMaterials.doc_id});
        }

        private bool SpecificationContractMaterialsExists(int id)
        {
            return (_context.SpecificationContractMaterials?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}