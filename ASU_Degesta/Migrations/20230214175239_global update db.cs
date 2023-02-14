using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASU_Degesta.Migrations
{
    public partial class globalupdatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AddColumn<string>(
            //     name: "types_id",
            //     table: "SpecificationContractMaterials",
            //     type: "varchar(255)",
            //     nullable: true);

            // migrationBuilder.AddColumn<string>(
            //     name: "types_id",
            //     table: "ReportProductPlan",
            //     type: "varchar(255)",
            //     nullable: true);

            // migrationBuilder.CreateIndex(
            //     name: "IX_SpecificationContractMaterials_types_id",
            //     table: "SpecificationContractMaterials",
            //     column: "types_id");

            // migrationBuilder.CreateIndex(
            //     name: "IX_SpecificationContractMaterials_units_id",
            //     table: "SpecificationContractMaterials",
            //     column: "units_id");
            //
            // migrationBuilder.CreateIndex(
            //     name: "IX_ReportProductPlan_types_id",
            //     table: "ReportProductPlan",
            //     column: "types_id");
            //
            // migrationBuilder.CreateIndex(
            //     name: "IX_ReportProductPlan_units_id",
            //     table: "ReportProductPlan",
            //     column: "units_id");
            //
            // migrationBuilder.CreateIndex(
            //     name: "IX_ReportMatherialCosts_units_id",
            //     table: "ReportMatherialCosts",
            //     column: "units_id");
            //
            // migrationBuilder.CreateIndex(
            //     name: "IX_payroll_statement_doc_id",
            //     table: "payroll_statement",
            //     column: "doc_id");

            migrationBuilder.AddForeignKey(
                name: "FK_payroll_statement_payroll_statement_name_id_doc_id",
                table: "payroll_statement",
                column: "doc_id",
                principalTable: "payroll_statement_name_id",
                principalColumn: "doc_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportMatherialCosts_Units_units_id",
                table: "ReportMatherialCosts",
                column: "units_id",
                principalTable: "Units",
                principalColumn: "Units_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportProductPlan_TypesOfProducts_types_id",
                table: "ReportProductPlan",
                column: "types_id",
                principalTable: "TypesOfProducts",
                principalColumn: "TypesOfProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportProductPlan_Units_units_id",
                table: "ReportProductPlan",
                column: "units_id",
                principalTable: "Units",
                principalColumn: "Units_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificationContractMaterials_TypesOfProducts_types_id",
                table: "SpecificationContractMaterials",
                column: "types_id",
                principalTable: "TypesOfProducts",
                principalColumn: "TypesOfProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificationContractMaterials_Units_units_id",
                table: "SpecificationContractMaterials",
                column: "units_id",
                principalTable: "Units",
                principalColumn: "Units_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_payroll_statement_payroll_statement_name_id_doc_id",
                table: "payroll_statement");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportMatherialCosts_Units_units_id",
                table: "ReportMatherialCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportProductPlan_TypesOfProducts_types_id",
                table: "ReportProductPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportProductPlan_Units_units_id",
                table: "ReportProductPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecificationContractMaterials_TypesOfProducts_types_id",
                table: "SpecificationContractMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecificationContractMaterials_Units_units_id",
                table: "SpecificationContractMaterials");

            migrationBuilder.DropIndex(
                name: "IX_SpecificationContractMaterials_types_id",
                table: "SpecificationContractMaterials");

            migrationBuilder.DropIndex(
                name: "IX_SpecificationContractMaterials_units_id",
                table: "SpecificationContractMaterials");

            migrationBuilder.DropIndex(
                name: "IX_ReportProductPlan_types_id",
                table: "ReportProductPlan");

            migrationBuilder.DropIndex(
                name: "IX_ReportProductPlan_units_id",
                table: "ReportProductPlan");

            migrationBuilder.DropIndex(
                name: "IX_ReportMatherialCosts_units_id",
                table: "ReportMatherialCosts");

            migrationBuilder.DropIndex(
                name: "IX_payroll_statement_doc_id",
                table: "payroll_statement");

            migrationBuilder.DropColumn(
                name: "types_id",
                table: "SpecificationContractMaterials");

            migrationBuilder.DropColumn(
                name: "types_id",
                table: "ReportProductPlan");
        }
    }
}
