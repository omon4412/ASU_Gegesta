using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASU_Degesta.Migrations
{
    public partial class types_of : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportProductCost_TypesOfProducts_types_id",
                table: "ReportProductCost");

            migrationBuilder.DropIndex(
                name: "IX_ReportProductCost_types_id",
                table: "ReportProductCost");

            migrationBuilder.DropColumn(
                name: "types_id",
                table: "ReportProductCost");

            migrationBuilder.AlterColumn<string>(
                name: "types_of_products_id",
                table: "ReportProductCost",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.CreateIndex(
                name: "IX_ReportProductCost_types_of_products_id",
                table: "ReportProductCost",
                column: "types_of_products_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportProductCost_TypesOfProducts_types_of_products_id",
                table: "ReportProductCost",
                column: "types_of_products_id",
                principalTable: "TypesOfProducts",
                principalColumn: "TypesOfProductsId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportProductCost_TypesOfProducts_types_of_products_id",
                table: "ReportProductCost");

            migrationBuilder.DropIndex(
                name: "IX_ReportProductCost_types_of_products_id",
                table: "ReportProductCost");

            migrationBuilder.AlterColumn<string>(
                name: "types_of_products_id",
                table: "ReportProductCost",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AddColumn<string>(
                name: "types_id",
                table: "ReportProductCost",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportProductCost_types_id",
                table: "ReportProductCost",
                column: "types_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportProductCost_TypesOfProducts_types_id",
                table: "ReportProductCost",
                column: "types_id",
                principalTable: "TypesOfProducts",
                principalColumn: "TypesOfProductsId");
        }
    }
}
