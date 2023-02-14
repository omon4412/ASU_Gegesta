using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASU_Degesta.Migrations
{
    public partial class types : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "types_id",
                table: "ReportMatherialCosts",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportMatherialCosts_types_id",
                table: "ReportMatherialCosts",
                column: "types_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportMatherialCosts_TypesOfProducts_types_id",
                table: "ReportMatherialCosts",
                column: "types_id",
                principalTable: "TypesOfProducts",
                principalColumn: "TypesOfProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportMatherialCosts_TypesOfProducts_types_id",
                table: "ReportMatherialCosts");

            migrationBuilder.DropIndex(
                name: "IX_ReportMatherialCosts_types_id",
                table: "ReportMatherialCosts");

            migrationBuilder.DropColumn(
                name: "types_id",
                table: "ReportMatherialCosts");
        }
    }
}
