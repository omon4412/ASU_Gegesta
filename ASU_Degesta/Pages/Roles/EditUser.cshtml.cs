using System.ComponentModel.DataAnnotations;
using ASU_Degesta.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASU_Degesta.Pages.Roles;

[Authorize(Roles = "admin, HR")]
public class EditUser : PageModel
{
    private readonly ILogger<EditUser> _logger;
    private readonly UserManager<DegestaUser> _userManager;
    private readonly SignInManager<DegestaUser> _signInManager;
    public readonly RoleManager<IdentityRole> _roleManager;

    public class InputModel
    {
        [Display(Name = "ФИО")] public string Name { get; set; }
        public string Email { get; set; }
    }

    [BindProperty] public InputModel Input { get; set; }
    public DegestaUser User;
    public IList<string> UserRoles;

    public EditUser(UserManager<DegestaUser> userManager,
        SignInManager<DegestaUser> signInManager, RoleManager<IdentityRole> roleManager, ILogger<EditUser> logger)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _logger = logger;
    }

    public async Task<IActionResult?> OnGet(string userId)
    {
        DegestaUser user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return RedirectToPage("./UserList");
        }

        User = user;
        UserRoles = await _userManager.GetRolesAsync(user);
        return null;
    }

    public async Task<IActionResult> OnPost(string userid, List<string> roles)
    {
        // получаем пользователя
        DegestaUser user = await _userManager.FindByIdAsync(userid);
        if (user != null)
        {
            // получем список ролей пользователя
            var userRoles = await _userManager.GetRolesAsync(user);
            // получаем все роли
            var allRoles = _roleManager.Roles.ToList();
            // получаем список ролей, которые были добавлены
            var addedRoles = roles.Except(userRoles);
            // получаем роли, которые были удалены
            var removedRoles = userRoles.Except(roles);

            await _userManager.AddToRolesAsync(user, addedRoles);

            user.Name = Input.Name;
            var token = await _userManager.GenerateChangeEmailTokenAsync(user, Input.Email);
            await _userManager.ChangeEmailAsync(user, Input.Email, token);
            await _userManager.UpdateAsync(user);

            await _userManager.RemoveFromRolesAsync(user, removedRoles);
            await _userManager.UpdateSecurityStampAsync(user);
            //await _signInManager.RefreshSignInAsync(user);
            return RedirectToPage("./UserList");
        }

        return NotFound();
    }

    public async Task<IActionResult> OnPostBlock(string id)
    {
        DegestaUser user = await _userManager.FindByIdAsync(id);
        if (user != null)
        {
            user.LockoutEnabled = true;
            user.LockoutEnd = DateTime.Now.AddYears(200);
            await _userManager.UpdateSecurityStampAsync(user);
            await _userManager.UpdateAsync(user);

            return RedirectToPage("./UserList");
        }

        return NotFound();
    }

    public async Task<IActionResult> OnPostUnBlock(string id)
    {
        DegestaUser user = await _userManager.FindByIdAsync(id);
        if (user != null)
        {
            user.LockoutEnabled = true;
            user.LockoutEnd = null;
            await _userManager.UpdateSecurityStampAsync(user);
            await _userManager.UpdateAsync(user);

            return RedirectToPage("./UserList");
        }

        return NotFound();
    }
}