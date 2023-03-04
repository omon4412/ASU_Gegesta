using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ASU_Degesta.Migrations
{
    public partial class MonthlyProductReleasePlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthlyProductReleasePlan",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    doc_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    types_of_products_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    count = table.Column<double>(type: "double", nullable: false),
                    units_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyProductReleasePlan", x => x.id);
                    table.ForeignKey(
                        name: "FK_MonthlyProductReleasePlan_ReportProductCost_id_doc_id",
                        column: x => x.doc_id,
                        principalTable: "ReportProductCost_id",
                        principalColumn: "doc_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonthlyProductReleasePlan_TypesOfProducts_types_of_products_~",
                        column: x => x.types_of_products_id,
                        principalTable: "TypesOfProducts",
                        principalColumn: "TypesOfProductsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonthlyProductReleasePlan_Units_units_id",
                        column: x => x.units_id,
                        principalTable: "Units",
                        principalColumn: "Units_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyProductReleasePlan_id",
                columns: table => new
                {
                    doc_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    doc_name = table.Column<string>(type: "longtext", nullable: false),
                    creation_date = table.Column<string>(type: "longtext", nullable: false),
                    creator = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyProductReleasePlan_id", x => x.doc_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyProductReleasePlan_doc_id",
                table: "MonthlyProductReleasePlan",
                column: "doc_id");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyProductReleasePlan_types_of_products_id",
                table: "MonthlyProductReleasePlan",
                column: "types_of_products_id");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyProductReleasePlan_units_id",
                table: "MonthlyProductReleasePlan",
                column: "units_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthlyProductReleasePlan");

            migrationBuilder.DropTable(
                name: "MonthlyProductReleasePlan_id");
        }
    }
}
