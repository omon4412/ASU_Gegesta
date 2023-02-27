using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ASU_Degesta.Migrations
{
    public partial class report_available_equipment_performancefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportAvailableEquipmentPerformance_id",
                columns: table => new
                {
                    doc_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    doc_name = table.Column<string>(type: "longtext", nullable: false),
                    creation_date = table.Column<string>(type: "longtext", nullable: false),
                    creator = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportAvailableEquipmentPerformance_id", x => x.doc_id);
                });

            migrationBuilder.CreateTable(
                name: "ReportAvailableEquipmentPerformance",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    doc_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    types_of_products_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    perfomance = table.Column<int>(type: "int", nullable: false),
                    units_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportAvailableEquipmentPerformance", x => x.id);
                    table.ForeignKey(
                        name: "FK_ReportAvailableEquipmentPerformance_ReportAvailableEquipment~",
                        column: x => x.doc_id,
                        principalTable: "ReportAvailableEquipmentPerformance_id",
                        principalColumn: "doc_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportAvailableEquipmentPerformance_TypesOfProducts_types_of~",
                        column: x => x.types_of_products_id,
                        principalTable: "TypesOfProducts",
                        principalColumn: "TypesOfProductsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportAvailableEquipmentPerformance_Units_units_id",
                        column: x => x.units_id,
                        principalTable: "Units",
                        principalColumn: "Units_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportAvailableEquipmentPerformance_doc_id",
                table: "ReportAvailableEquipmentPerformance",
                column: "doc_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAvailableEquipmentPerformance_types_of_products_id",
                table: "ReportAvailableEquipmentPerformance",
                column: "types_of_products_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAvailableEquipmentPerformance_units_id",
                table: "ReportAvailableEquipmentPerformance",
                column: "units_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportAvailableEquipmentPerformance");

            migrationBuilder.DropTable(
                name: "ReportAvailableEquipmentPerformance_id");
        }
    }
}
