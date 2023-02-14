using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASU_Degesta.Migrations
{
    public partial class jhhivhuhhuhb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_SpecificationContractMaterials_TypesOfProducts_types_of_prod~",
            //     table: "SpecificationContractMaterials");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_SpecificationContractMaterials_Units_Units_ID",
            //     table: "SpecificationContractMaterials");

            // migrationBuilder.DropIndex(
            //     name: "IX_SpecificationContractMaterials_types_of_productsTypesOfProdu~",
            //     table: "SpecificationContractMaterials");
            //
            // migrationBuilder.DropIndex(
            //     name: "IX_SpecificationContractMaterials_Units_ID",
            //     table: "SpecificationContractMaterials");

            migrationBuilder.DropColumn(
                name: "types_of_productsTypesOfProductsId",
                table: "SpecificationContractMaterials");

            migrationBuilder.RenameColumn(
                name: "Units_ID",
                table: "SpecificationContractMaterials",
                newName: "units_id");

            migrationBuilder.AddColumn<string>(
                name: "types_of_products_id",
                table: "SpecificationContractMaterials",
                type: "longtext",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "types_of_products_id",
                table: "SpecificationContractMaterials");

            migrationBuilder.RenameColumn(
                name: "units_id",
                table: "SpecificationContractMaterials",
                newName: "Units_ID");

            migrationBuilder.AddColumn<string>(
                name: "types_of_productsTypesOfProductsId",
                table: "SpecificationContractMaterials",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationContractMaterials_types_of_productsTypesOfProdu~",
                table: "SpecificationContractMaterials",
                column: "types_of_productsTypesOfProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationContractMaterials_Units_ID",
                table: "SpecificationContractMaterials",
                column: "Units_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificationContractMaterials_TypesOfProducts_types_of_prod~",
                table: "SpecificationContractMaterials",
                column: "types_of_productsTypesOfProductsId",
                principalTable: "TypesOfProducts",
                principalColumn: "TypesOfProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificationContractMaterials_Units_Units_ID",
                table: "SpecificationContractMaterials",
                column: "Units_ID",
                principalTable: "Units",
                principalColumn: "Units_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
