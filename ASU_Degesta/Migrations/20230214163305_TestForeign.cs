using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASU_Degesta.Migrations
{
    public partial class TestForeign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "doc_id",
                table: "ReportMatherialCosts",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.CreateIndex(
                name: "IX_ReportMatherialCosts_doc_id",
                table: "ReportMatherialCosts",
                column: "doc_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportMatherialCosts_ReportMatherialCosts_id_doc_id",
                table: "ReportMatherialCosts",
                column: "doc_id",
                principalTable: "ReportMatherialCosts_id",
                principalColumn: "doc_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportMatherialCosts_ReportMatherialCosts_id_doc_id",
                table: "ReportMatherialCosts");

            migrationBuilder.DropIndex(
                name: "IX_ReportMatherialCosts_doc_id",
                table: "ReportMatherialCosts");

            migrationBuilder.AlterColumn<string>(
                name: "doc_id",
                table: "ReportMatherialCosts",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");
        }
    }
}
