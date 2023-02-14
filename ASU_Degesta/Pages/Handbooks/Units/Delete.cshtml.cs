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

namespace ASU_Degesta.Pages.Handbooks.Units
{
    [Authorize(Roles = "admin")]
    public class DeleteModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public DeleteModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        [BindProperty] public Models.Handbooks.Units Units { get; set; } = default!;

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Units == null)
            {
                return NotFound();
            }

            var units = await _context.Units.FindAsync(id);

            if (units != null)
            {
                Units = units;
                _context.Units.Remove(Units);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}