using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASU_Degesta.Pages.Accounting;

[Authorize(Roles = "admin, Бухгалтер")]
public class Index : PageModel
{
    public void OnGet()
    {
    }
}