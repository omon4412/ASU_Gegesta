using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASU_Degesta.Data;
using ASU_Degesta.Models.Handbooks;

namespace ASU_Degesta.Pages.Handbooks.TypesOfProducts
{
    public class DetailsModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public DetailsModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        public Models.Handbooks.TypesOfProducts TypesOfProducts { get; set; } = default!;

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
    }
}