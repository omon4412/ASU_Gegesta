using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ASU_Degesta.Migrations
{
    public partial class report_costs_production_capacity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportCostsProductionCapacity",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    doc_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    types_of_products_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    costs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportCostsProductionCapacity", x => x.id);
                    table.ForeignKey(
                        name: "FK_ReportCostsProductionCapacity_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportCostsProductionCapacity_ReportAvailableEquipmentPerfor~",
                        column: x => x.doc_id,
                        principalTable: "ReportAvailableEquipmentPerformance_id",
                        principalColumn: "doc_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportCostsProductionCapacity_TypesOfProducts_types_of_produ~",
                        column: x => x.types_of_products_id,
                        principalTable: "TypesOfProducts",
                        principalColumn: "TypesOfProductsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportCostsProductionCapacity_id",
                columns: table => new
                {
                    doc_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    doc_name = table.Column<string>(type: "longtext", nullable: false),
                    creation_date = table.Column<string>(type: "longtext", nullable: false),
                    creator = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportCostsProductionCapacity_id", x => x.doc_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportCostsProductionCapacity_doc_id",
                table: "ReportCostsProductionCapacity",
                column: "doc_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReportCostsProductionCapacity_EquipmentId",
                table: "ReportCostsProductionCapacity",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportCostsProductionCapacity_types_of_products_id",
                table: "ReportCostsProductionCapacity",
                column: "types_of_products_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportCostsProductionCapacity");

            migrationBuilder.DropTable(
                name: "ReportCostsProductionCapacity_id");
        }
    }
}
