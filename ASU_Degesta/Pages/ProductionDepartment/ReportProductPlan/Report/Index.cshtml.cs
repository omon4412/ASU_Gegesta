using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASU_Degesta.Data;
using ASU_Degesta.Models.Handbooks;
using ASU_Degesta.Models.ProductionDepartment;
using Microsoft.AspNetCore.Authorization;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportProductPlan.Report
{
    [Authorize(Roles = "admin, Начальник производственного отдела")]
    public class IndexModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public List<TypesOfProducts> TypesOfProductsList;
        public List<Units> UnitsList;

        public IndexModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
            TypesOfProductsList = _context.TypesOfProducts.AsNoTracking().ToList();
            UnitsList = _context.Units.AsNoTracking().ToList();
        }

        public IList<Models.ProductionDepartment.ReportProductPlan> ReportProductPlan { get; set; } = default!;

        public async Task<NotFoundResult> OnGetAsync()
        {
            return NotFound();
            if (_context.ReportProductPlan != null)
            {
                ReportProductPlan = await _context.ReportProductPlan.ToListAsync();
            }
        }
    }
}