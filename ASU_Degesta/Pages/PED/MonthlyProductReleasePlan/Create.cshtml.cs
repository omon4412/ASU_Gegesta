using System.ComponentModel;
using System.Data.Common;
using System.Text;
using ASU_Degesta.Models;
using ASU_Degesta.Models.Handbooks;
using ASU_Degesta.Models.PED;
using ASU_Degesta.Models.ProductionDepartment;
using ASU_Degesta.Models.SalesDepartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ASU_Degesta.Pages.PED.MonthlyProductReleasePlan
{
    [Authorize(Roles = "admin, Начальник планово-экономического отдела")]
    public class CreateModel : PageModel
    {
        private readonly ASU_Degesta.Data.ASU_DegestaContext _context;
        private readonly SignInManager<DegestaUser> _userManager;

        public List<ForecastMaximumDemandProducts_id> Forecast;
        public List<PriceList_id> Price;
        public List<ReportCostsProductionCapacity_id> ReportCost;
        public List<ReportAvailableEquipmentPerformance_id> ReportAvailable;

        public List<TypesOfProducts> types_of_products;
        public List<Units> units;

        public CreateModel(ASU_Degesta.Data.ASU_DegestaContext context, SignInManager<DegestaUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            Forecast = _context.ForecastMaximumDemandProducts_id.AsNoTracking().ToList();
            Price = _context.PriceList_id.AsNoTracking().ToList();
            ReportCost = _context.ReportCostsProductionCapacity_id.AsNoTracking().ToList();
            ReportAvailable = _context.ReportAvailableEquipmentPerformance_id.AsNoTracking().ToList();
            types_of_products = _context.TypesOfProducts.AsNoTracking().ToList();
            units = _context.Units.AsNoTracking().ToList();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public MonthlyProductReleasePlan_id MonthlyProductReleasePlan_id { get; set; } = default!;

        [BindProperty] 
        [DisplayName("Прогноз на максимальную потребность в изделиях на месяц")]
        public string Forecast_id { get; set; } = default!;

        [BindProperty] 
        [DisplayName("Прайс-лист")]
        public string Price_id { get; set; } = default!;

        [BindProperty] 
        [DisplayName("Отчёт о издержках производственных мощностей на производство каждого изделия")]
        public string ReportCosts_id { get; set; } = default!;

        [BindProperty] 
        [DisplayName("Отчёт о имеющихся производственных мощностях на месяц")]
        public string ReportAvailable_id { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
            MonthlyProductReleasePlan_id.creation_date = DateTime.Now.ToString();
            MonthlyProductReleasePlan_id.creator = _userManager.Context.User.Identity.Name;
            MonthlyProductReleasePlan_id.doc_id = IDGenerator.GetNewID();

            if (!ModelState.IsValid || _context.MonthlyProductReleasePlan_id == null ||
                MonthlyProductReleasePlan_id == null)
            {
                return Page();
            }

            ///Task
            var fore = _context.ForecastMaximumDemandProducts
                .Where(x => x.doc_id == Forecast_id).ToList();
            var price = _context.PriceList.Where(x => x.doc_id == Price_id).ToList();
            var repcost = _context.ReportCostsProductionCapacity.Where(x => x.doc_id == ReportCosts_id).ToList();
            var repava = _context.ReportAvailableEquipmentPerformance.Where(x => x.doc_id == ReportAvailable_id)
                .ToList();

            if (fore.Count != price.Count || repava.Count != repcost.GroupBy(x => x.EquipmentId).ToList().Count)
            {
                return Content("Ошибка в данных");
            }

            List<List<int>> data = new List<List<int>>();

            var joinData = fore.Join(repcost, t_p => t_p.types_of_products_id,
                rep => rep.types_of_products_id,
                (t_p, rep) => new {t_p, rep}).Join(repava, x => x.rep.EquipmentId, y => y.EquipmentId,
                (x, y) => new {x, y}).OrderBy(x => x.x.rep.EquipmentId).ToList();
            
            
            for (int i = 0; i < repava.Count; i++)
            {
                data.Add(joinData.Take(fore.Count).Select(x => x.x.rep.costs).ToList());
                joinData.RemoveRange(0, fore.Count);
                data[i].Add(repava[i].perfomance);
            }


            data.Add(fore.Select(x => x.demand).ToList());
            data.Add(price.Select(x => x.price).ToList());

            HttpClient client = new();

            var json1 = JsonConvert.SerializeObject(data);
            Data rrr = new Data()
            {
                json = json1
            };
            var json2 = JsonConvert.SerializeObject(rrr);
            var data1 = new StringContent(json2, Encoding.UTF8, "application/json");

            var host = HttpContext.Request.Host;
            var response = client.PostAsync($"{HttpContext.Request.Scheme}://{host}/api/SolveTheTask", data1);

            var responseString = response.Result.Content.ReadAsStringAsync().Result;
            JArray jArray = JArray.Parse(responseString);
            _context.MonthlyProductReleasePlan_id.Add(MonthlyProductReleasePlan_id);
            await _context.SaveChangesAsync();
            for (int i = 0; i < fore.Count; i++)
            {
                Models.PED.MonthlyProductReleasePlan what = new Models.PED.MonthlyProductReleasePlan
                {
                    doc_id = MonthlyProductReleasePlan_id.doc_id,
                    types_of_products_id = fore[i].types_of_products_id,
                    count = Convert.ToInt32(jArray[i]?.ToString()),
                    units_id = fore[i].units_id
                };
                _context.MonthlyProductReleasePlan.Add(what);
            }

            await _context.SaveChangesAsync();
            // foreach (var item in jArray)
            // {
            //     Models.PED.MonthlyProductReleasePlan what = new Models.PED.MonthlyProductReleasePlan();
            //     what.doc_id = MonthlyProductReleasePlan_id.doc_id;
            //     what.types_of_products_id = item.;
            //     what.count = Convert.ToInt32(item[0]?.ToString());
            //     what.units_id = item.unit;
            //     _context.ReportProductCost.Add(what);
            // }


            //if (json["workspace_id"].Value<string>() == null)


            return RedirectToPage("./Index");
        }
    }

    public class Data
    {
        public string json { get; set; }
    }
}