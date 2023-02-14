using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASU_Degesta.Data;
using ASU_Degesta.Models.Handbooks;
using Microsoft.AspNetCore.Authorization;

namespace ASU_Degesta.Pages.Handbooks.TypesOfProducts
{
    [Authorize(Roles = "admin")]
    public class EditModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public EditModel(ASU_Degesta.Data.ASU_DegestaContext context)
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

            TypesOfProducts = typesofproducts;
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

            _context.Attach(TypesOfProducts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypesOfProductsExists(TypesOfProducts.TypesOfProductsId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TypesOfProductsExists(string id)
        {
            return (_context.TypesOfProducts?.Any(e => e.TypesOfProductsId == id)).GetValueOrDefault();
        }
    }
}