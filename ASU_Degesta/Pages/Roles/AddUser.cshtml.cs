using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using ASU_Degesta.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace ASU_Degesta.Pages.Roles;

public class AddUser : PageModel
{
    private readonly ILogger<EditUser> _logger;
    private readonly UserManager<DegestaUser> _userManager;
    private readonly SignInManager<DegestaUser> _signInManager;
    private readonly IUserStore<DegestaUser> _userStore;
    private readonly IUserEmailStore<DegestaUser> _emailStore;
    public readonly RoleManager<IdentityRole> _roleManager;
    [BindProperty] public AddUser.InputModel Input { get; set; }
    public DegestaUser User;

    public class InputModel
    {
        [Display(Name = "ФИО")] [Required] public string Name { get; set; }
        [Required] [EmailAddress] public string Email { get; set; }
        [Required] public string Pass { get; set; }
    }

    public AddUser(UserManager<DegestaUser> userManager,
        SignInManager<DegestaUser> signInManager, RoleManager<IdentityRole> roleManager, ILogger<EditUser> logger,
        IUserStore<DegestaUser> userStore)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _logger = logger;
        _userStore = userStore;
        _emailStore = GetEmailStore();
    }

    public async Task<RedirectToPageResult> OnPost()
    {
        var user = CreateUser();

        await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
        await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
        var result = await _userManager.CreateAsync(user, Input.Pass);

        if (result.Succeeded)
        {
            _logger.LogInformation("User created a new account with password.");

            user.EmailConfirmed = true;
            user.Name = Input.Name;
            await _userManager.UpdateAsync(user);
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return RedirectToPage("./UserList");
    }

    private DegestaUser CreateUser()
    {
        try
        {
            return Activator.CreateInstance<DegestaUser>();
        }
        catch
        {
            throw new InvalidOperationException($"Can't create an instance of '{nameof(DegestaUser)}'. " +
                                                $"Ensure that '{nameof(DegestaUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                                                $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
        }
    }

    private IUserEmailStore<DegestaUser> GetEmailStore()
    {
        if (!_userManager.SupportsUserEmail)
        {
            throw new NotSupportedException("The default UI requires a user store with email support.");
        }

        return (IUserEmailStore<DegestaUser>) _userStore;
    }
}