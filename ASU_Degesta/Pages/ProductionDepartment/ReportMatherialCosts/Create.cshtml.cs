using ASU_Degesta.Models;
using ASU_Degesta.Models.ProductionDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportMatherialCosts
{
    [Authorize(Roles = "admin, Начальник производственного отдела")]
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

        [BindProperty] public ReportMatherialCosts_id ReportMatherialCosts_id { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ReportMatherialCosts_id.creation_date = DateTime.Now.ToString();
            ReportMatherialCosts_id.creator = _userManager.Context.User.Identity.Name;
            ReportMatherialCosts_id.doc_id = IDGenerator.GetNewID();

            if (!ModelState.IsValid || _context.ReportMatherialCosts_id == null ||
                ReportMatherialCosts_id == null)
            {
                return Page();
            }

            _context.ReportMatherialCosts_id.Add(ReportMatherialCosts_id);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}