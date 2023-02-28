using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASU_Degesta.Migrations
{
    public partial class report_costs_production_capacityfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportCostsProductionCapacity_ReportAvailableEquipmentPerfor~",
                table: "ReportCostsProductionCapacity");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportCostsProductionCapacity_ReportCostsProductionCapacity_~",
                table: "ReportCostsProductionCapacity",
                column: "doc_id",
                principalTable: "ReportCostsProductionCapacity_id",
                principalColumn: "doc_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportCostsProductionCapacity_ReportCostsProductionCapacity_~",
                table: "ReportCostsProductionCapacity");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportCostsProductionCapacity_ReportAvailableEquipmentPerfor~",
                table: "ReportCostsProductionCapacity",
                column: "doc_id",
                principalTable: "ReportAvailableEquipmentPerformance_id",
                principalColumn: "doc_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
