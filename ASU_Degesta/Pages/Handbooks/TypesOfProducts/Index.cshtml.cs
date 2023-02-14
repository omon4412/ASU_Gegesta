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
    public class IndexModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public IndexModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        public IList<Models.Handbooks.TypesOfProducts> TypesOfProducts { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TypesOfProducts != null)
            {
                TypesOfProducts = await _context.TypesOfProducts.ToListAsync();
            }
        }
    }
}