using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASU_Degesta.Data;
using ASU_Degesta.Models.Handbooks;
using ASU_Degesta.Models.ProductionDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportProductPlan.Report
{
    [Authorize(Roles = "admin, Начальник производственного отдела")]
    public class CreateModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;
        public List<TypesOfProducts> TypesOfProductsList;
        public List<Units> UnitsList;

        public CreateModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
            TypesOfProductsList = _context.TypesOfProducts.AsNoTracking().ToList();
            UnitsList = _context.Units.AsNoTracking().ToList();
        }

        public string idd;

        public IActionResult OnGetAsync(string docid, int? id)
        {
            idd = docid;
            return Page();
        }

        [BindProperty] public Models.ProductionDepartment.ReportProductPlan ReportProductPlan { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            if (!ModelState.IsValid || _context.ReportProductPlan == null ||
                ReportProductPlan == null)
            {
                return Page();
            }

            _context.ReportProductPlan.Add(ReportProductPlan);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Details", new {id = ReportProductPlan.doc_id});
        }
    }
}