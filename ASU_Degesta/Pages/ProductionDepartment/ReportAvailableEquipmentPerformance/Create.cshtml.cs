using ASU_Degesta.Models;
using ASU_Degesta.Models.ProductionDepartment;
using ASU_Degesta.Models.SalesDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportAvailableEquipmentPerformance
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

        [BindProperty] public ReportAvailableEquipmentPerformance_id ReportAvailableEquipmentPerformance_id { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ReportAvailableEquipmentPerformance_id.creation_date = DateTime.Now.ToString();
            ReportAvailableEquipmentPerformance_id.creator = _userManager.Context.User.Identity.Name;
            ReportAvailableEquipmentPerformance_id.doc_id = IDGenerator.GetNewID();

            if (!ModelState.IsValid || _context.ReportAvailableEquipmentPerformance_id == null ||
                ReportAvailableEquipmentPerformance_id == null)
            {
                return Page();
            }

            _context.ReportAvailableEquipmentPerformance_id.Add(ReportAvailableEquipmentPerformance_id);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}