using ASU_Degesta.Models;
using ASU_Degesta.Models.Accounting;
using ASU_Degesta.Models.Handbooks;
using ASU_Degesta.Models.PED;
using ASU_Degesta.Models.ProductionDepartment;
using ASU_Degesta.Models.SalesDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.PED.ReportProductsCost
{
    [Authorize(Roles = "admin, Начальник планово-экономического отдела")]
    public class CreateModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;
        private readonly SignInManager<DegestaUser> _userManager;

        public List<SpecificationContractMaterials_id> Specifications;
        public List<ReportMatherialCosts_id> ReportMatherialCosts;
        public List<ReportProductPlan_id> ReportProductPlan;
        public List<payroll_statement_name_id> payroll_statement;

        public List<TypesOfProducts> types_of_products;
        public List<Units> units;

        public CreateModel(ASU_Degesta.Data.ASU_DegestaContext context, SignInManager<DegestaUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            Specifications = _context.SpecificationContractMaterials_id.AsNoTracking().ToList();
            ReportMatherialCosts = _context.ReportMatherialCosts_id.AsNoTracking().ToList();
            ReportProductPlan = _context.ReportProductPlan_id.AsNoTracking().ToList();
            payroll_statement = _context.payroll_statement_name_id.AsNoTracking().ToList();
            types_of_products = _context.TypesOfProducts.AsNoTracking().ToList();
            units = _context.Units.AsNoTracking().ToList();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public ReportProductCost_id ReportProductCost_id { get; set; } = default!;
        [BindProperty] public string Specification_id { get; set; } = default!;
        [BindProperty] public string ReportMatherialCosts_id { get; set; } = default!;
        [BindProperty] public string ReportProductPlan_id { get; set; } = default!;
        [BindProperty] public string payroll_statement_id { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
            ReportProductCost_id.creation_date = DateTime.Now.ToString();
            ReportProductCost_id.creator = _userManager.Context.User.Identity.Name;
            ReportProductCost_id.doc_id = IDGenerator.GetNewID();

            if (!ModelState.IsValid || _context.ReportProductCost_id == null ||
                ReportProductCost_id == null)
            {
                return Page();
            }

            _context.ReportProductCost_id.Add(ReportProductCost_id);
            await _context.SaveChangesAsync();

            var spec = _context.SpecificationContractMaterials.Where(x => x.doc_id == Specification_id).ToList();
            var repmath = _context.ReportMatherialCosts.Where(x => x.doc_id == ReportMatherialCosts_id).ToList();
            var repprod = _context.ReportProductPlan.Where(x => x.doc_id == ReportProductPlan_id).ToList();
            var pay = _context.payroll_statement.Where(x => x.doc_id == payroll_statement_id).ToList();

            var test = types_of_products.Join(spec,
                t_p => t_p.TypesOfProductsId,
                spec => spec.types_of_products_id,
                (t_p, spec) => new {t_p, spec}).Join(repmath,
                t_p => t_p.t_p.TypesOfProductsId,
                mc => mc.types_of_products_id,
                (t_p, mc) => new {t_p, mc}).Join(repprod,
                t_p => t_p.t_p.t_p.TypesOfProductsId,
                pl_mth => pl_mth.types_of_products_id,
                (t_p, pl_mth) => new {t_p, pl_mth}).Select(x => new
            {
                name = x.t_p.t_p.t_p.TypesOfProductsId,
                sum = Math.Round((x.t_p.t_p.spec.price_per_unit +
                                  Math.Round(
                                      x.t_p.mc.overhead_production_costs + x.t_p.mc.general_business_invoices +
                                      x.t_p.mc.direct_costs, 2))
                    * x.pl_mth.produced + (pay.Sum(t => t.total_accrued) / x.pl_mth.produced), 2),
                unit = x.t_p.t_p.spec.units_id
            });

            foreach (var item in test)
            {
                ReportProductCost what = new ReportProductCost
                {
                    doc_id = ReportProductCost_id.doc_id,
                    types_of_products_id = item.name,
                    cost_price = item.sum,
                    units_id = item.unit
                };
                _context.ReportProductCost.Add(what);
            }

            await _context.SaveChangesAsync();
            // var resr = spec.Join(types_of_products,
            //     spec => spec.types_of_products_id,
            //     t_p => t_p.TypesOfProductsId,
            //     (spec, t_p) => new {spec, t_p}).Select(x=>x.t_p.Name);

            return RedirectToPage("./Index");
        }
    }
}