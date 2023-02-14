using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASU_Degesta.Data;
using ASU_Degesta.Models.Handbooks;

namespace ASU_Degesta.Pages.Handbooks.Units
{
    public class DetailsModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public DetailsModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        public Models.Handbooks.Units Units { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Units == null)
            {
                return NotFound();
            }

            var units = await _context.Units.FirstOrDefaultAsync(m => m.Units_ID == id);
            if (units == null)
            {
                return NotFound();
            }
            else
            {
                Units = units;
            }

            return Page();
        }
    }
}