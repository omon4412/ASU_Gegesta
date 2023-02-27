using ASU_Degesta.Models.Handbooks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.SalesDepartment.PriceList.Report
{
    [Authorize(Roles = "admin, Менеджер по продажам")]
    public class CreateModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;
        public List<TypesOfProducts> TypesOfProductsList;
        public List<Units> UnitsList;

        public CreateModel(ASU_Degesta.Data.ASU_DegestaContext context)
        {
            _context = context;
            TypesOfProductsList = _context.TypesOfProducts.AsNoTracking().ToList();
            UnitsList = _context.Units.AsNoTracking().ToList();
        }

        public string idd;

        public IActionResult OnGetAsync(string docid, int? id)
        {
            idd = docid;
            return Page();
        }

        [BindProperty] public Models.SalesDepartment.PriceList PriceList { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            if (!ModelState.IsValid || _context.PriceList == null ||
                PriceList == null)
            {
                return Page();
            }

            _context.PriceList.Add(PriceList);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Details", new {id = PriceList.doc_id});
        }
    }
}