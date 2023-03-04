using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASU_Degesta.Migrations
{
    public partial class MonthlyProductReleasePlanfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyProductReleasePlan_ReportProductCost_id_doc_id",
                table: "MonthlyProductReleasePlan");

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyProductReleasePlan_MonthlyProductReleasePlan_id_doc_id",
                table: "MonthlyProductReleasePlan",
                column: "doc_id",
                principalTable: "MonthlyProductReleasePlan_id",
                principalColumn: "doc_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyProductReleasePlan_MonthlyProductReleasePlan_id_doc_id",
                table: "MonthlyProductReleasePlan");

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyProductReleasePlan_ReportProductCost_id_doc_id",
                table: "MonthlyProductReleasePlan",
                column: "doc_id",
                principalTable: "ReportProductCost_id",
                principalColumn: "doc_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
