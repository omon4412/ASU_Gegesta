using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ASU_Degesta.Migrations
{
    public partial class ReportProfitabilityMonth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportProfitabilityMonth_id",
                columns: table => new
                {
                    doc_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    doc_name = table.Column<string>(type: "longtext", nullable: false),
                    creation_date = table.Column<string>(type: "longtext", nullable: false),
                    creator = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportProfitabilityMonth_id", x => x.doc_id);
                });

            migrationBuilder.CreateTable(
                name: "ReportProfitabilityMonth",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    doc_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    types_of_products_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    revenue = table.Column<double>(type: "double", nullable: false),
                    cost_price = table.Column<double>(type: "double", nullable: false),
                    profit = table.Column<double>(type: "double", nullable: false),
                    units_id = table.Column<int>(type: "int", nullable: false),
                    profitability = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportProfitabilityMonth", x => x.id);
                    table.ForeignKey(
                        name: "FK_ReportProfitabilityMonth_ReportProfitabilityMonth_id_doc_id",
                        column: x => x.doc_id,
                        principalTable: "ReportProfitabilityMonth_id",
                        principalColumn: "doc_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportProfitabilityMonth_TypesOfProducts_types_of_products_id",
                        column: x => x.types_of_products_id,
                        principalTable: "TypesOfProducts",
                        principalColumn: "TypesOfProductsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportProfitabilityMonth_Units_units_id",
                        column: x => x.units_id,
                        principalTable: "Units",
                        principalColumn: "Units_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportProfitabilityMonth_doc_id",
                table: "ReportProfitabilityMonth",
                column: "doc_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReportProfitabilityMonth_types_of_products_id",
                table: "ReportProfitabilityMonth",
                column: "types_of_products_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReportProfitabilityMonth_units_id",
                table: "ReportProfitabilityMonth",
                column: "units_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportProfitabilityMonth");

            migrationBuilder.DropTable(
                name: "ReportProfitabilityMonth_id");
        }
    }
}
