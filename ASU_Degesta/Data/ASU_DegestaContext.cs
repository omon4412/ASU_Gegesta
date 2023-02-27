using ASU_Degesta.Models;
using ASU_Degesta.Models.Accounting;
using ASU_Degesta.Models.PED;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ASU_Degesta.Models.SalesDepartment;

namespace ASU_Degesta.Data;

public class ASU_DegestaContext : IdentityDbContext<DegestaUser>
{
    public ASU_DegestaContext(DbContextOptions<ASU_DegestaContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<ASU_Degesta.Models.Handbooks.Units>? Units { get; set; }

    public DbSet<ASU_Degesta.Models.Handbooks.TypesOfProducts>? TypesOfProducts { get; set; }

    public DbSet<ASU_Degesta.Models.Handbooks.types_of_products>? types_of_products { get; set; }

    public DbSet<payroll_statement>? payroll_statement { get; set; }

    public DbSet<payroll_statement_name_id>? payroll_statement_name_id { get; set; }

    public DbSet<SpecificationContractMaterials> SpecificationContractMaterials { get; set; } =
        default!;

    public DbSet<SpecificationContractMaterials_id> SpecificationContractMaterials_id { get; set; } =
        default!;

    public DbSet<ReportProductPlan_id> ReportProductPlan_id { get; set; } =
        default!;

    public DbSet<ReportProductPlan> ReportProductPlan { get; set; } = default!;

    public DbSet<ASU_Degesta.Models.ProductionDepartment.ReportMatherialCosts_id>
        ReportMatherialCosts_id { get; set; } = default!;

    public DbSet<ASU_Degesta.Models.ProductionDepartment.ReportMatherialCosts> ReportMatherialCosts { get; set; } =
        default!;

    public DbSet<ASU_Degesta.Models.PED.ReportProductCost> ReportProductCost { get; set; } =
        default!;

    public DbSet<ASU_Degesta.Models.PED.ReportProductCost_id> ReportProductCost_id { get; set; } =
        default!;

    public DbSet<ASU_Degesta.Models.SalesDepartment.ForecastMaximumDemandProducts> ForecastMaximumDemandProducts
    {
        get;
        set;
    } =
        default!;

    public DbSet<ASU_Degesta.Models.SalesDepartment.ForecastMaximumDemandProducts_id> ForecastMaximumDemandProducts_id
    {
        get;
        set;
    } =
        default!;
    
    public DbSet<ASU_Degesta.Models.SalesDepartment.PriceList> PriceList { get; set; } =
        default!;
    public DbSet<ASU_Degesta.Models.SalesDepartment.PriceList_id> PriceList_id { get; set; } =
        default!;
}