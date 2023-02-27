using ASU_Degesta.Models.Handbooks;
using ASU_Degesta.Models.ProductionDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportAvailableEquipmentPerformance.Report
{
    [Authorize(Roles = "admin, Начальник производственного отдела")]
    public class CreateModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;
        public List<Equipments> EquipmentsList;
        public List<Units> UnitsList;

        public CreateModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
            EquipmentsList = _context.Equipments.AsNoTracking().ToList();
            UnitsList = _context.Units.AsNoTracking().ToList();
        }

        public string idd;

        public IActionResult OnGetAsync(string docid, int? id)
        {
            idd = docid;
            return Page();
        }

        [BindProperty] public Models.ProductionDepartment.ReportAvailableEquipmentPerformance ReportAvailableEquipmentPerformance { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            if (!ModelState.IsValid || _context.ReportAvailableEquipmentPerformance == null ||
                ReportAvailableEquipmentPerformance == null)
            {
                return Page();
            }

            _context.ReportAvailableEquipmentPerformance.Add(ReportAvailableEquipmentPerformance);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Details", new {id = ReportAvailableEquipmentPerformance.doc_id});
        }
    }
}