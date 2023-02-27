using ASU_Degesta.Models.Handbooks;
using ASU_Degesta.Models.ProductionDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportAvailableEquipmentPerformance.Report
{
    [Authorize(Roles = "admin, Начальник производственного отдела")]
    public class EditModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;
        public List<Equipments> EquipmentsList;
        public List<Units> UnitsList;

        public EditModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
            EquipmentsList = _context.Equipments.AsNoTracking().ToList();
            UnitsList = _context.Units.AsNoTracking().ToList();
        }

        [BindProperty] public Models.ProductionDepartment.ReportAvailableEquipmentPerformance ReportAvailableEquipmentPerformance { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string docid, int? id)
        {
            if (id == null || docid == null || _context.ReportAvailableEquipmentPerformance == null)
            {
                return NotFound();
            }

            var ReportAvailableEquipmentPerformance =
                await _context.ReportAvailableEquipmentPerformance.FirstOrDefaultAsync(m => m.id == id && m.doc_id == docid);
            if (ReportAvailableEquipmentPerformance == null)
            {
                return NotFound();
            }

            this.ReportAvailableEquipmentPerformance = ReportAvailableEquipmentPerformance;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ReportAvailableEquipmentPerformance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportAvailableEquipmentPerformanceExists(ReportAvailableEquipmentPerformance.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Details", new {id = ReportAvailableEquipmentPerformance.doc_id});
        }

        private bool ReportAvailableEquipmentPerformanceExists(int id)
        {
            return (_context.ReportAvailableEquipmentPerformance?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}