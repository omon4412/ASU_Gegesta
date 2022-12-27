using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASU_Degesta.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASU_Degesta.Pages;

[AllowAnonymous]
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly UserManager<DegestaUser> _userManager;
    private readonly SignInManager<DegestaUser> _signInManager;
    public IndexModel(ILogger<IndexModel> logger, UserManager<DegestaUser> userManager,
        SignInManager<DegestaUser> signInManager)
    {
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
        //userManager.GetUsersInRoleAsync(ASU_Degesta.Models.Constants.GeneralDirectorRole);
        // userManager.AddToRoleAsync(_userManager.GetUserAsync(User).Result, ASU_Degesta.Models.Constants.AdminRole);
        // var bannedUser = userManager.FindByNameAsync(User.Identity.Name).Result;
        // if (bannedUser != null)
        // {
        //      userManager.AddToRoleAsync(bannedUser, "Banned");
        //      signInManager.RefreshSignInAsync(bannedUser);
        //     //"Succesfully banned user " + Input.UsernameToBan + ".";
        // }
    }

    public void OnGet()
    {
    }
}