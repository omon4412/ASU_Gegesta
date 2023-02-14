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
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.Handbooks.TypesOfProducts
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
            if (_context.types_of_products != null)
            {
                classified = _context.types_of_products.ToList();
            }

            // foreach (var item in classified.Where(it => EF.Functions.Like(it.code, "2%")))
            // {
            //     List<string> test1 = new List<string>();
            //     if (item.code.Length == 1)
            //     {
            //        // test1.Add();
            //     }
            // }

            return Page();
        }

        [BindProperty] public Models.Handbooks.TypesOfProducts TypesOfProducts { get; set; } = default!;
        public IList<Models.Handbooks.types_of_products> classified { get; set; } = default!;

        public List<string> class1 = new List<string>();
        public List<string> class2 = new List<string>();
        public List<string> class3 = new List<string>();

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.TypesOfProducts == null || TypesOfProducts == null)
            {
                return Page();
            }


            _context.TypesOfProducts.Add(TypesOfProducts);
            //_context.types_of_products.Add(classified);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}