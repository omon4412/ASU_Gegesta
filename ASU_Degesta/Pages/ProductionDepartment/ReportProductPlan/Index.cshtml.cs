using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASU_Degesta.Data;
using ASU_Degesta.Models.ProductionDepartment;
using Microsoft.AspNetCore.Authorization;

namespace ASU_Degesta.Pages.ProductionDepartment.ReportProductPlan
{
    [Authorize(Roles = "admin, Начальник производственного отдела")]
    public class IndexModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;

        public IndexModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
        }

        public IList<ReportProductPlan_id> ReportProductPlan_id { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ReportProductPlan_id != null)
            {
                ReportProductPlan_id = await _context.ReportProductPlan_id.ToListAsync();
            }
        }
    }
}