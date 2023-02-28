using ASU_Degesta.Models;
using ASU_Degesta.Models.Accounting;
using ASU_Degesta.Models.PED;
using ASU_Degesta.Models.ProductionDepartment;
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
    }

    public DbSet<Models.Handbooks.Units>? Units { get; set; }

    public DbSet<Models.Handbooks.TypesOfProducts>? TypesOfProducts { get; set; }

    public DbSet<Models.Handbooks.types_of_products>? types_of_products { get; set; }

    public DbSet<payroll_statement>? payroll_statement { get; set; }

    public DbSet<payroll_statement_name_id>? payroll_statement_name_id { get; set; }

    public DbSet<SpecificationContractMaterials> SpecificationContractMaterials { get; set; } = default!;

    public DbSet<SpecificationContractMaterials_id> SpecificationContractMaterials_id { get; set; } = default!;

    public DbSet<ReportProductPlan_id> ReportProductPlan_id { get; set; } = default!;

    public DbSet<ReportProductPlan> ReportProductPlan { get; set; } = default!;

    public DbSet<ReportMatherialCosts_id> ReportMatherialCosts_id { get; set; } = default!;

    public DbSet<ReportMatherialCosts> ReportMatherialCosts { get; set; } = default!;

    public DbSet<ReportProductCost> ReportProductCost { get; set; } = default!;

    public DbSet<ReportProductCost_id> ReportProductCost_id { get; set; } = default!;

    public DbSet<ForecastMaximumDemandProducts> ForecastMaximumDemandProducts { get; set; } = default!;

    public DbSet<ForecastMaximumDemandProducts_id> ForecastMaximumDemandProducts_id { get; set; } = default!;

    public DbSet<PriceList> PriceList { get; set; } =
        default!;

    public DbSet<PriceList_id> PriceList_id { get; set; } =
        default!;

    public DbSet<ReportAvailableEquipmentPerformance> ReportAvailableEquipmentPerformance { get; set; } = default!;

    public DbSet<ReportAvailableEquipmentPerformance_id> ReportAvailableEquipmentPerformance_id { get; set; } =
        default!;

    public DbSet<Equipments> Equipments { get; set; } = default!;

    public DbSet<ReportCostsProductionCapacity> ReportCostsProductionCapacity { get; set; } = default!;

    public DbSet<ReportCostsProductionCapacity_id> ReportCostsProductionCapacity_id { get; set; } = default!;
}