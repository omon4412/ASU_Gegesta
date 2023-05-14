using ASU_Degesta.Models.Accounting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASU_Degesta.Pages.CheckDocument;

[Authorize(Roles = "admin")]
public class Index : PageModel
{
    private readonly ASU_Degesta.Data.ASU_DegestaContext _context;
    [BindProperty] public string data { get; set; } = default!;

    public payroll_statement_name_id ret;
        public string link = "";

    public Index(ASU_Degesta.Data.ASU_DegestaContext context)
    {
        _context = context;
    }

    public void OnPostAsync()
    {
        var t1 = _context.payroll_statement_name_id.Where(c => c.doc_id.Equals(data));
        var t2 = _context.MonthlyProductReleasePlan_id.Where(c => c.doc_id.Equals(data));
        var t3 = _context.ReportProductCost_id.Where(c => c.doc_id.Equals(data));
        var t4 = _context.ReportProductPlan_id.Where(c => c.doc_id.Equals(data));
        var t5 = _context.ReportProfitabilityMonth_id.Where(c => c.doc_id.Equals(data));
        var t6 = _context.ReportAvailableEquipmentPerformance_id.Where(c => c.doc_id.Equals(data));
        var t7 = _context.ReportCostsProductionCapacity_id.Where(c => c.doc_id.Equals(data));
        var t8 = _context.ReportMatherialCosts_id.Where(c => c.doc_id.Equals(data));
        var t9 = _context.ForecastMaximumDemandProducts_id.Where(c => c.doc_id.Equals(data));
        var t10 = _context.PriceList_id.Where(c => c.doc_id.Equals(data));
        var t11 = _context.SpecificationContractMaterials_id.Where(c => c.doc_id.Equals(data));

        if (t1.Count() != 0)
        {
            ret = new payroll_statement_name_id();
            ret.doc_id = t1.First().doc_id;
            ret.creation_date = t1.First().creation_date;
            ret.creator = t1.First().creator;
            ret.doc_name = t1.First().doc_name;
            link = "Accounting/PayrollStatements/Details?id="+ret.doc_id;
        }else if (t2.Count() != 0)
        {
            ret = new payroll_statement_name_id();
            ret.doc_id = t2.First().doc_id;
            ret.creation_date = t2.First().creation_date;
            ret.creator = t2.First().creator;
            ret.doc_name = t2.First().doc_name;
            link = "PED/MonthlyProductReleasePlan/Details?id="+ret.doc_id;
        }else if (t3.Count() != 0)
        {
            ret = new payroll_statement_name_id();
            ret.doc_id = t3.First().doc_id;
            ret.creation_date = t3.First().creation_date;
            ret.creator = t3.First().creator;
            ret.doc_name = t3.First().doc_name;
            link = "PED/ReportProductsCost/Details?id="+ret.doc_id;
        }else if (t4.Count() != 0)
        {
            ret = new payroll_statement_name_id();
            ret.doc_id = t4.First().doc_id;
            ret.creation_date = t4.First().creation_date;
            ret.creator = t4.First().creator;
            ret.doc_name = t4.First().doc_name;
            link = "PED/ReportProductPlan/Details?id="+ret.doc_id;
        }else if (t5.Count() != 0)
        {
            ret = new payroll_statement_name_id();
            ret.doc_id = t5.First().doc_id;
            ret.creation_date = t5.First().creation_date;
            ret.creator = t5.First().creator;
            ret.doc_name = t5.First().doc_name;
            link = "PED/ReportProfitabilityMonth/Details?id="+ret.doc_id;
        }else if (t6.Count() != 0)
        {
            ret = new payroll_statement_name_id();
            ret.doc_id = t6.First().doc_id;
            ret.creation_date = t6.First().creation_date;
            ret.creator = t6.First().creator;
            ret.doc_name = t6.First().doc_name;
            link = "ProductionDepartment/ReportAvailableEquipmentPerformance/Details?id="+ret.doc_id;
        }else if (t7.Count() != 0)
        {
            ret = new payroll_statement_name_id();
            ret.doc_id = t7.First().doc_id;
            ret.creation_date = t7.First().creation_date;
            ret.creator = t7.First().creator;
            ret.doc_name = t7.First().doc_name;
            link = "ProductionDepartment/ReportCostsProductionCapacity/Details?id="+ret.doc_id;
        }else if (t8.Count() != 0)
        {
            ret = new payroll_statement_name_id();
            ret.doc_id = t8.First().doc_id;
            ret.creation_date = t8.First().creation_date;
            ret.creator = t8.First().creator;
            ret.doc_name = t8.First().doc_name;
            link = "ProductionDepartment/ReportMatherialCosts/Details?id="+ret.doc_id;
        }else if (t9.Count() != 0)
        {
            ret = new payroll_statement_name_id();
            ret.doc_id = t9.First().doc_id;
            ret.creation_date = t9.First().creation_date;
            ret.creator = t9.First().creator;
            ret.doc_name = t9.First().doc_name;
            link = "SalesDepartment/ForecastMaximumDemandProducts/Details?id="+ret.doc_id;
        }else if (t10.Count() != 0)
        {
            ret = new payroll_statement_name_id();
            ret.doc_id = t10.First().doc_id;
            ret.creation_date = t10.First().creation_date;
            ret.creator = t10.First().creator;
            ret.doc_name = t10.First().doc_name;
            link = "SalesDepartment/PriceList/Details?id="+ret.doc_id;
        }else if (t11.Count() != 0)
        {
            ret = new payroll_statement_name_id();
            ret.doc_id = t11.First().doc_id;
            ret.creation_date = t11.First().creation_date;
            ret.creator = t11.First().creator;
            ret.doc_name = t11.First().doc_name;
            link = "SalesDepartment/Specification/Details?id="+ret.doc_id;
        }
        else
        {
            link = "!";
        }
        
        // List<object> lst = new List<object>();
        // lst.Add(t1);
        // lst.Add(t2);
        // lst.Add(t3);
        // lst.Add(t4);
        // lst.Add(t5);
        // lst.Add(t6);
        // lst.Add(t7);
        // lst.Add(t8);
        // lst.Add(t9);
        // lst.Add(t10);
        // lst.Add(t11);
        //
        // foreach (var t in lst)
        // {
        //     if (t != null)
        //     {
        //         Console.WriteLine(t);
        //     }
        // }
    }

    public void OnGet()
    {
        // payroll_statement_name_id        t1               = new  payroll_statement_name_id();
        //     MonthlyProductReleasePlan_id      t2          = new MonthlyProductReleasePlan_id();
        // ReportProductCost_id                   t3         = new ReportProductCost_id();
        //     ReportProductPlan_id                  t4      = new ReportProductPlan_id();
        // ReportProfitabilityMonth_id              t5       = new ReportProfitabilityMonth_id();
        //     ReportAvailableEquipmentPerformance_id   t6   = new ReportAvailableEquipmentPerformance_id();
        // ReportCostsProductionCapacity_id            t7    = new ReportCostsProductionCapacity_id();
        //     ReportMatherialCosts_id               t8      = new ReportMatherialCosts_id();
        // ForecastMaximumDemandProducts_id        t9        = new ForecastMaximumDemandProducts_id();
        //     PriceList_id                          t10      = new PriceList_id();
        // SpecificationContractMaterials_id         t11      = new SpecificationContractMaterials_id();
    }
}