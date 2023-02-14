using ASU_Degesta.Models;
using ASU_Degesta.Models.Accounting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASU_Degesta.Pages.Accounting.PayrollStatements
{
    [Authorize(Roles = "admin, Бухгалтер")]
    public class CreateModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;
        private readonly SignInManager<DegestaUser> _userManager;

        public CreateModel(ASU_Degesta.Data.ASU_DegestaContext context, SignInManager<DegestaUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public payroll_statement_name_id payroll_statement { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            payroll_statement.creation_date = DateTime.Now.ToString();
            payroll_statement.creator = _userManager.Context.User.Identity.Name;
            payroll_statement.doc_id = IDGenerator.GetNewID();
            if (!ModelState.IsValid || _context.payroll_statement_name_id == null || payroll_statement == null)
            {
                return Page();
            }


            _context.payroll_statement_name_id.Add(payroll_statement);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}