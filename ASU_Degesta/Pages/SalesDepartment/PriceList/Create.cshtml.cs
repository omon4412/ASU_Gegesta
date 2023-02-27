using ASU_Degesta.Models;
using ASU_Degesta.Models.PED;
using ASU_Degesta.Models.SalesDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASU_Degesta.Pages.SalesDepartment.PriceList
{
    [Authorize(Roles = "admin, Менеджер по продажам")]
    public class CreateModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;
        private readonly SignInManager<DegestaUser> _userManager;

        public CreateModel(ASU_Degesta.Data.ASU_DegestaContext context, SignInManager<DegestaUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public PriceList_id PriceList_id { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            PriceList_id.creation_date = DateTime.Now.ToString();
            PriceList_id.creator = _userManager.Context.User.Identity.Name;
            PriceList_id.doc_id = IDGenerator.GetNewID();

            if (!ModelState.IsValid || _context.PriceList_id == null ||
                PriceList_id == null)
            {
                return Page();
            }

            _context.PriceList_id.Add(PriceList_id);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}