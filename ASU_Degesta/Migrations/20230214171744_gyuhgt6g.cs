using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASU_Degesta.Migrations
{
    public partial class gyuhgt6g : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "doc_id",
                table: "ReportProductPlan",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.CreateIndex(
                name: "IX_ReportProductPlan_doc_id",
                table: "ReportProductPlan",
                column: "doc_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportProductPlan_ReportProductPlan_id_doc_id",
                table: "ReportProductPlan",
                column: "doc_id",
                principalTable: "ReportProductPlan_id",
                principalColumn: "doc_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportProductPlan_ReportProductPlan_id_doc_id",
                table: "ReportProductPlan");

            migrationBuilder.DropIndex(
                name: "IX_ReportProductPlan_doc_id",
                table: "ReportProductPlan");

            migrationBuilder.AlterColumn<string>(
                name: "doc_id",
                table: "ReportProductPlan",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");
        }
    }
}
