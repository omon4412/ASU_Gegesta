using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ASU_Degesta.Migrations
{
    public partial class Equipments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportAvailableEquipmentPerformance_TypesOfProducts_types_of~",
                table: "ReportAvailableEquipmentPerformance");

            migrationBuilder.DropIndex(
                name: "IX_ReportAvailableEquipmentPerformance_types_of_products_id",
                table: "ReportAvailableEquipmentPerformance");

            migrationBuilder.DropColumn(
                name: "types_of_products_id",
                table: "ReportAvailableEquipmentPerformance");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "ReportAvailableEquipmentPerformance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EquipmentName = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.EquipmentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportAvailableEquipmentPerformance_EquipmentId",
                table: "ReportAvailableEquipmentPerformance",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportAvailableEquipmentPerformance_Equipments_EquipmentId",
                table: "ReportAvailableEquipmentPerformance",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "EquipmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportAvailableEquipmentPerformance_Equipments_EquipmentId",
                table: "ReportAvailableEquipmentPerformance");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_ReportAvailableEquipmentPerformance_EquipmentId",
                table: "ReportAvailableEquipmentPerformance");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "ReportAvailableEquipmentPerformance");

            migrationBuilder.AddColumn<string>(
                name: "types_of_products_id",
                table: "ReportAvailableEquipmentPerformance",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAvailableEquipmentPerformance_types_of_products_id",
                table: "ReportAvailableEquipmentPerformance",
                column: "types_of_products_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportAvailableEquipmentPerformance_TypesOfProducts_types_of~",
                table: "ReportAvailableEquipmentPerformance",
                column: "types_of_products_id",
                principalTable: "TypesOfProducts",
                principalColumn: "TypesOfProductsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
