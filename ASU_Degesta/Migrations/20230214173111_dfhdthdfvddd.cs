using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASU_Degesta.Migrations
{
    public partial class dfhdthdfvddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "doc_id",
                table: "SpecificationContractMaterials",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            // migrationBuilder.CreateIndex(
            //     name: "IX_SpecificationContractMaterials_doc_id",
            //     table: "SpecificationContractMaterials",
            //     column: "doc_id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificationContractMaterials_SpecificationContractMaterial~",
                table: "SpecificationContractMaterials",
                column: "doc_id",
                principalTable: "SpecificationContractMaterials_id",
                principalColumn: "doc_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecificationContractMaterials_SpecificationContractMaterial~",
                table: "SpecificationContractMaterials");

            migrationBuilder.DropIndex(
                name: "IX_SpecificationContractMaterials_doc_id",
                table: "SpecificationContractMaterials");

            migrationBuilder.AlterColumn<string>(
                name: "doc_id",
                table: "SpecificationContractMaterials",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");
        }
    }
}
