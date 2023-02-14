using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASU_Degesta.Pages.SalesDepartment;

[Authorize(Roles = "admin, Менеджер по продажам")]
public class Index : PageModel
{
    public void OnGet()
    {
    }
}