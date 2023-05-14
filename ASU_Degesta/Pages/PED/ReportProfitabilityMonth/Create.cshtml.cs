using System.ComponentModel;
using ASU_Degesta.Models;
using ASU_Degesta.Models.Handbooks;
using ASU_Degesta.Models.PED;
using ASU_Degesta.Models.SalesDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASU_Degesta.Pages.PED.ReportProfitabilityMonth
{
    [Authorize(Roles = "admin, Начальник планово-экономического отдела")]
    public class CreateModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;
        private readonly SignInManager<DegestaUser> _userManager;

        public List<ReportProductCost_id> rep_cost;
        public List<ReportProductPlan_id> rep_plan;
        public List<PriceList_id> price_list;

        public List<TypesOfProducts> types_of_products;
        public List<Units> units;

        public CreateModel(ASU_Degesta.Data.ASU_DegestaContext context, SignInManager<DegestaUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            rep_cost = _context.ReportProductCost_id.AsNoTracking().ToList();
            rep_plan = _context.ReportProductPlan_id.AsNoTracking().ToList();
            price_list = _context.PriceList_id.AsNoTracking().ToList();
            types_of_products = _context.TypesOfProducts.AsNoTracking().ToList();
            units = _context.Units.AsNoTracking().ToList();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public ReportProfitabilityMonth_id ReportProfitabilityMonth_id { get; set; } = default!;

        [BindProperty]
        [DisplayName("Отчёт о себестоимости единицы продукции")]
        public string rep_cost_id { get; set; } = default!;

        [BindProperty]
        [DisplayName("Отчёт выполнения плана изделий в номенклатуре за месяц")]
        public string rep_plan_id { get; set; } = default!;

        [BindProperty]
        [DisplayName("Прайс-лист")]
        public string price_list_id { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            ReportProfitabilityMonth_id.creation_date = DateTime.Now.ToString();
            ReportProfitabilityMonth_id.creator = _userManager.Context.User.Identity.Name;
            ReportProfitabilityMonth_id.doc_id = IDGenerator.GetNewID();

            if (!ModelState.IsValid || _context.ReportProfitabilityMonth_id == null ||
                ReportProfitabilityMonth_id == null)
            {
                return Page();
            }

            _context.ReportProfitabilityMonth_id.Add(ReportProfitabilityMonth_id);
            await _context.SaveChangesAsync();

            var cost = _context.ReportProductCost.Where(x => x.doc_id == rep_cost_id).ToList();
            var plan = _context.ReportProductPlan.Where(x => x.doc_id == rep_plan_id).ToList();
            var price = _context.PriceList.Where(x => x.doc_id == price_list_id).ToList();

            var test = types_of_products.Join(cost,
                t_p => t_p.TypesOfProductsId,
                cost => cost.types_of_products_id,
                (t_p, cost) => new {t_p, cost}).Join(plan,
                t_p => t_p.t_p.TypesOfProductsId,
                mc => mc.types_of_products_id,
                (t_p, mc) => new {t_p, mc}).Join(price,
                t_p => t_p.t_p.t_p.TypesOfProductsId,
                pl_mth => pl_mth.types_of_products_id,
                (t_p, pl_mth) => new {t_p, pl_mth}).Select(x => new
            {
                name = x.t_p.t_p.t_p.TypesOfProductsId,
                //prod = x.t_p.mc.produced,
                //price1 = x.pl_mth.price,
                rev = x.t_p.mc.produced * x.pl_mth.price,
                cost_pr = x.t_p.mc.produced * x.t_p.t_p.cost.cost_price,
                profit = Math.Round(x.t_p.mc.produced * x.pl_mth.price - x.t_p.mc.produced * x.t_p.t_p.cost.cost_price,
                    2),
                // sum = Math.Round((x.t_p.t_p.cost.cost_price +
                //                   Math.Round(
                //                       x.t_p.mc.overhead_production_costs + x.t_p.mc.general_business_invoices +
                //                       x.t_p.mc.direct_costs, 2))
                //     * x.pl_mth.produced + (pay.Sum(t => t.total_accrued) / x.pl_mth.produced), 2),
                sum = Math.Round(
                    (x.t_p.mc.produced * x.pl_mth.price - x.t_p.mc.produced * x.t_p.t_p.cost.cost_price) /
                    (x.t_p.mc.produced * x.pl_mth.price), 2),
                unit = x.t_p.t_p.cost.units_id,
            });

            foreach (var item in test)
            {
                Models.PED.ReportProfitabilityMonth what = new Models.PED.ReportProfitabilityMonth
                {
                    doc_id = ReportProfitabilityMonth_id.doc_id,
                    types_of_products_id = item.name,
                    revenue = item.rev,
                    cost_price = item.cost_pr,
                    profit = item.profit,
                    profitability = item.sum,
                    units_id = item.unit
                };
                _context.ReportProfitabilityMonth.Add(what);
            }

            await _context.SaveChangesAsync();
            // var resr = cost.Join(types_of_products,
            //     spec => spec.types_of_products_id,
            //     t_p => t_p.TypesOfProductsId,
            //    (spec, t_p) => new {spec, t_p}).Select(x=>x.t_p.Name);

            return RedirectToPage("./Index");
        }
    }
}