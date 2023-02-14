using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASU_Degesta.Data;
using ASU_Degesta.Models.Handbooks;

namespace ASU_Degesta.Pages.Classifier
{
    public class DetailsModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public DetailsModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        public types_of_products types_of_products { get; set; } = default!;

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
                this.types_of_products = types_of_products;
            }

            return Page();
        }
    }
}