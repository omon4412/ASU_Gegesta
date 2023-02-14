using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASU_Degesta.Data;
using ASU_Degesta.Models.Handbooks;
using Microsoft.AspNetCore.Authorization;

namespace ASU_Degesta.Pages.Handbooks.TypesOfProducts
{
    [Authorize(Roles = "admin")]
    public class DeleteModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public DeleteModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        [BindProperty] public Models.Handbooks.TypesOfProducts TypesOfProducts { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.TypesOfProducts == null)
            {
                return NotFound();
            }

            var typesofproducts = await _context.TypesOfProducts.FirstOrDefaultAsync(m => m.TypesOfProductsId == id);

            if (typesofproducts == null)
            {
                return NotFound();
            }
            else
            {
                TypesOfProducts = typesofproducts;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.TypesOfProducts == null)
            {
                return NotFound();
            }

            var typesofproducts = await _context.TypesOfProducts.FindAsync(id);

            if (typesofproducts != null)
            {
                TypesOfProducts = typesofproducts;
                _context.TypesOfProducts.Remove(TypesOfProducts);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}