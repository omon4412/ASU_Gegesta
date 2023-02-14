using ASU_Degesta.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASU_Degesta.Pages.Roles;

[Authorize(Roles = "admin, HR")]
public class UserList : PageModel
{
    private readonly ILogger<EditUser> _logger;
    private readonly UserManager<DegestaUser> _userManager;
    private readonly SignInManager<DegestaUser> _signInManager;
    public readonly RoleManager<IdentityRole> _roleManager;
    public IList<string> UserRoles;

    public UserList(ILogger<EditUser> logger, UserManager<DegestaUser> userManager,
        SignInManager<DegestaUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public async Task OnGet()
    {
        UserRoles = await _userManager.GetRolesAsync(_userManager.GetUserAsync(HttpContext.User).Result);
    }
}