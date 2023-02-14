using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASU_Degesta.Models;
using ASU_Degesta.Models.ProductionDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportProductPlan
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

        [BindProperty] public ReportProductPlan_id ReportProductPlan_id { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ReportProductPlan_id.creation_date = DateTime.Now.ToString();
            ReportProductPlan_id.creator = _userManager.Context.User.Identity.Name;
            ReportProductPlan_id.doc_id = IDGenerator.GetNewID();

            if (!ModelState.IsValid || _context.ReportProductPlan_id == null ||
                ReportProductPlan_id == null)
            {
                return Page();
            }

            _context.ReportProductPlan_id.Add(ReportProductPlan_id);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}