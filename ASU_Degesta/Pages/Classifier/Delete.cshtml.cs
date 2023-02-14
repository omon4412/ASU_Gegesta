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

namespace ASU_Degesta.Pages.Classifier
{
    [Authorize(Roles = "admin")]
    public class DeleteModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public DeleteModel(ASU_Degesta.Data.ASU_DegestaContext context)
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
            else
            {
                types_of_products = types_of_products;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.types_of_products == null)
            {
                return NotFound();
            }

            var types_of_products = await _context.types_of_products.FindAsync(id);

            if (types_of_products != null)
            {
                types_of_products = types_of_products;
                _context.types_of_products.Remove(types_of_products);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}