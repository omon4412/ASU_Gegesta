using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASU_Degesta.Pages.ProductionDepartment;

[Authorize(Roles = "admin, Начальник производственного отдела")]
public class Index : PageModel
{
    public void OnGet()
    {
    }
}