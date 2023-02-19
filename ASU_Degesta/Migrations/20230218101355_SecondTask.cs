using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ASU_Degesta.Migrations
{
    public partial class SecondTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportProductCost_id",
                columns: table => new
                {
                    doc_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    doc_name = table.Column<string>(type: "longtext", nullable: false),
                    creation_date = table.Column<string>(type: "longtext", nullable: false),
                    creator = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportProductCost_id", x => x.doc_id);
                });

            migrationBuilder.CreateTable(
                name: "ReportProductCost",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    doc_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    types_of_products_id = table.Column<string>(type: "longtext", nullable: false),
                    types_id = table.Column<string>(type: "varchar(255)", nullable: true),
                    cost_price = table.Column<int>(type: "int", nullable: false),
                    units_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportProductCost", x => x.id);
                    table.ForeignKey(
                        name: "FK_ReportProductCost_ReportProductCost_id_doc_id",
                        column: x => x.doc_id,
                        principalTable: "ReportProductCost_id",
                        principalColumn: "doc_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportProductCost_TypesOfProducts_types_id",
                        column: x => x.types_id,
                        principalTable: "TypesOfProducts",
                        principalColumn: "TypesOfProductsId");
                    table.ForeignKey(
                        name: "FK_ReportProductCost_Units_units_id",
                        column: x => x.units_id,
                        principalTable: "Units",
                        principalColumn: "Units_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportProductCost_doc_id",
                table: "ReportProductCost",
                column: "doc_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReportProductCost_types_id",
                table: "ReportProductCost",
                column: "types_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReportProductCost_units_id",
                table: "ReportProductCost",
                column: "units_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportProductCost");

            migrationBuilder.DropTable(
                name: "ReportProductCost_id");
        }
    }
}
