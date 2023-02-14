using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASU_Degesta.Data;
using ASU_Degesta.Models.Handbooks;
using Microsoft.AspNetCore.Authorization;

namespace ASU_Degesta.Pages.Classifier
{
    [Authorize(Roles = "admin")]
    public class CreateModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public CreateModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public types_of_products types_of_products { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.types_of_products == null || types_of_products == null)
            {
                return Page();
            }

            _context.types_of_products.Add(types_of_products);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}