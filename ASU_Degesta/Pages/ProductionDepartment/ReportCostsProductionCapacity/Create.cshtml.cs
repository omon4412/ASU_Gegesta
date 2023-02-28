using ASU_Degesta.Models;
using ASU_Degesta.Models.ProductionDepartment;
using ASU_Degesta.Models.SalesDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportCostsProductionCapacity
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

        [BindProperty] public ReportCostsProductionCapacity_id ReportCostsProductionCapacity_id { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ReportCostsProductionCapacity_id.creation_date = DateTime.Now.ToString();
            ReportCostsProductionCapacity_id.creator = _userManager.Context.User.Identity.Name;
            ReportCostsProductionCapacity_id.doc_id = IDGenerator.GetNewID();

            if (!ModelState.IsValid || _context.ReportCostsProductionCapacity_id == null ||
                ReportCostsProductionCapacity_id == null)
            {
                return Page();
            }

            _context.ReportCostsProductionCapacity_id.Add(ReportCostsProductionCapacity_id);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}