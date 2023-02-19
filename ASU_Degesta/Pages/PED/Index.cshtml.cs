using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASU_Degesta.Pages.PED;

[Authorize(Roles = "admin, Начальник планово-экономического отдела")]
public class Index : PageModel
{
    public void OnGet()
    {
    }
}