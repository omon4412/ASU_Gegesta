using System.ComponentModel.DataAnnotations;
using ASU_Degesta.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASU_Degesta.Pages.Roles;

[Authorize(Roles = "admin, HR")]
public class Index : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly UserManager<DegestaUser> _userManager;
    private readonly SignInManager<DegestaUser> _signInManager;
    public readonly RoleManager<IdentityRole> _roleManager;

    public Index(UserManager<DegestaUser> userManager,
        SignInManager<DegestaUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public class InputModel
    {
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [Required]
        [Display(Name = "Новая должность")]
        public string NewRole { get; set; }
    }

    [BindProperty] public InputModel Input { get; set; }

    [TempData] public string StatusMessage { get; set; }

    public async void OnPost()
    {
        Console.WriteLine(Input.NewRole);
        var roleExist = await _roleManager.RoleExistsAsync(Input.NewRole);
        if (!roleExist)
        {
            //create the roles and seed them to the database: Question 1
            await _roleManager.CreateAsync(new IdentityRole(Input.NewRole));
        }

        if (User.Identity != null)
            await _userManager.AddToRoleAsync(_userManager.FindByNameAsync(User.Identity.Name).Result, Input.NewRole);
    }

    public async void OnPostDelete(string id)
    {
        IdentityRole role = await _roleManager.FindByIdAsync(id);
        if (role != null)
        {
            if (role.Name == "admin")
            {
                StatusMessage = "Админа удалить нельзя!";
                //return RedirectToAction("Index");
            }

            IdentityResult result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                StatusMessage = "Должность успешно удалена!";
            }
            else
            {
                StatusMessage = "Произошла ошибка!" + result.ToString();
            }
        }

        //return RedirectToAction("Index");
    }

    public async Task<IActionResult> OnPostEdit(string id)
    {
        // IdentityRole role = await _roleManager.FindByIdAsync(id);
        // if (role != null)
        // {
        //     if (role.Name == "admin")
        //     {
        //         StatusMessage = "Админа нельзя редактировать!";
        //         return RedirectToAction("Index");
        //     }
        //     
        //     role.Name = 
        //     IdentityRole result = await _roleManager.FindByIdAsync(role);
        //     if (result.Succeeded)
        //     {
        //         StatusMessage = "Должность успешно изменена!";
        //     }
        //     else
        //     {
        //         StatusMessage = "Произошла ошибка!" + result.ToString();
        //     }
        // }

        return RedirectToAction("Index");
    }
}