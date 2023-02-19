using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASU_Degesta.Migrations
{
    public partial class new_types_rel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_ReportMatherialCosts_TypesOfProducts_types_id",
            //     table: "ReportMatherialCosts");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_ReportProductPlan_TypesOfProducts_types_id",
            //     table: "ReportProductPlan");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_SpecificationContractMaterials_TypesOfProducts_types_id",
            //     table: "SpecificationContractMaterials");

            // migrationBuilder.DropIndex(
            //     name: "IX_SpecificationContractMaterials_types_id",
            //     table: "SpecificationContractMaterials");

            // migrationBuilder.DropIndex(
            //     name: "IX_ReportProductPlan_types_id",
            //     table: "ReportProductPlan");

            // migrationBuilder.DropIndex(
            //     name: "IX_ReportMatherialCosts_types_id",
            //     table: "ReportMatherialCosts");

            // migrationBuilder.DropColumn(
            //     name: "types_id",
            //     table: "SpecificationContractMaterials");

            // migrationBuilder.DropColumn(
            //     name: "types_id",
            //     table: "ReportProductPlan");

            // migrationBuilder.DropColumn(
            //     name: "types_id",
            //     table: "ReportMatherialCosts");

            migrationBuilder.AlterColumn<string>(
                name: "types_of_products_id",
                table: "SpecificationContractMaterials",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "types_of_products_id",
                table: "ReportProductPlan",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "types_of_products_id",
                table: "ReportMatherialCosts",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            // migrationBuilder.CreateIndex(
            //     name: "IX_SpecificationContractMaterials_types_of_products_id",
            //     table: "SpecificationContractMaterials",
            //     column: "types_of_products_id");

            // migrationBuilder.CreateIndex(
            //     name: "IX_ReportProductPlan_types_of_products_id",
            //     table: "ReportProductPlan",
            //     column: "types_of_products_id");

            // migrationBuilder.CreateIndex(
            //     name: "IX_ReportMatherialCosts_types_of_products_id",
            //     table: "ReportMatherialCosts",
            //     column: "types_of_products_id");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_ReportMatherialCosts_TypesOfProducts_types_of_products_id",
            //     table: "ReportMatherialCosts",
            //     column: "types_of_products_id",
            //     principalTable: "TypesOfProducts",
            //     principalColumn: "TypesOfProductsId",
            //     onDelete: ReferentialAction.Cascade);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_ReportProductPlan_TypesOfProducts_types_of_products_id",
            //     table: "ReportProductPlan",
            //     column: "types_of_products_id",
            //     principalTable: "TypesOfProducts",
            //     principalColumn: "TypesOfProductsId",
            //     onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificationContractMaterials_TypesOfProducts_types_of_prod~",
                table: "SpecificationContractMaterials",
                column: "types_of_products_id",
                principalTable: "TypesOfProducts",
                principalColumn: "TypesOfProductsId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportMatherialCosts_TypesOfProducts_types_of_products_id",
                table: "ReportMatherialCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportProductPlan_TypesOfProducts_types_of_products_id",
                table: "ReportProductPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecificationContractMaterials_TypesOfProducts_types_of_prod~",
                table: "SpecificationContractMaterials");

            migrationBuilder.DropIndex(
                name: "IX_SpecificationContractMaterials_types_of_products_id",
                table: "SpecificationContractMaterials");

            migrationBuilder.DropIndex(
                name: "IX_ReportProductPlan_types_of_products_id",
                table: "ReportProductPlan");

            migrationBuilder.DropIndex(
                name: "IX_ReportMatherialCosts_types_of_products_id",
                table: "ReportMatherialCosts");

            migrationBuilder.AlterColumn<string>(
                name: "types_of_products_id",
                table: "SpecificationContractMaterials",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AddColumn<string>(
                name: "types_id",
                table: "SpecificationContractMaterials",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "types_of_products_id",
                table: "ReportProductPlan",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AddColumn<string>(
                name: "types_id",
                table: "ReportProductPlan",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "types_of_products_id",
                table: "ReportMatherialCosts",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AddColumn<string>(
                name: "types_id",
                table: "ReportMatherialCosts",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationContractMaterials_types_id",
                table: "SpecificationContractMaterials",
                column: "types_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReportProductPlan_types_id",
                table: "ReportProductPlan",
                column: "types_id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ReportProductPlan_TypesOfProducts_types_id",
                table: "ReportProductPlan",
                column: "types_id",
                principalTable: "TypesOfProducts",
                principalColumn: "TypesOfProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificationContractMaterials_TypesOfProducts_types_id",
                table: "SpecificationContractMaterials",
                column: "types_id",
                principalTable: "TypesOfProducts",
                principalColumn: "TypesOfProductsId");
        }
    }
}
