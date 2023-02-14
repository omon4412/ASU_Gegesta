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

namespace ASU_Degesta.Pages.Classifier
{
    [Authorize(Roles = "admin")]
    public class EditModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public EditModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        [BindProperty] public types_of_products types_of_products { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.types_of_products == null)
            {
                return NotFound();
            }

            var types_of_products =
                await _context.types_of_products.FirstOrDefaultAsync(m => m.types_of_products_id == id);
            if (types_of_products == null)
            {
                return NotFound();
            }

            this.types_of_products = types_of_products;
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

            _context.Attach(types_of_products).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!types_of_productsExists(types_of_products.types_of_products_id))
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

        private bool types_of_productsExists(int id)
        {
            return (_context.types_of_products?.Any(e => e.types_of_products_id == id)).GetValueOrDefault();
        }
    }
}