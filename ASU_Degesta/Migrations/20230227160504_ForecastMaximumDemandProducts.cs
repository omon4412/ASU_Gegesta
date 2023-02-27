using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ASU_Degesta.Migrations
{
    public partial class ForecastMaximumDemandProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ForecastMaximumDemandProducts_id",
                columns: table => new
                {
                    doc_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    doc_name = table.Column<string>(type: "longtext", nullable: false),
                    creation_date = table.Column<string>(type: "longtext", nullable: false),
                    creator = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForecastMaximumDemandProducts_id", x => x.doc_id);
                });

            migrationBuilder.CreateTable(
                name: "ForecastMaximumDemandProducts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    doc_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    types_of_products_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    demand = table.Column<int>(type: "int", nullable: false),
                    units_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForecastMaximumDemandProducts", x => x.id);
                    table.ForeignKey(
                        name: "FK_ForecastMaximumDemandProducts_ForecastMaximumDemandProducts_~",
                        column: x => x.doc_id,
                        principalTable: "ForecastMaximumDemandProducts_id",
                        principalColumn: "doc_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForecastMaximumDemandProducts_TypesOfProducts_types_of_produ~",
                        column: x => x.types_of_products_id,
                        principalTable: "TypesOfProducts",
                        principalColumn: "TypesOfProductsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForecastMaximumDemandProducts_Units_units_id",
                        column: x => x.units_id,
                        principalTable: "Units",
                        principalColumn: "Units_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForecastMaximumDemandProducts_doc_id",
                table: "ForecastMaximumDemandProducts",
                column: "doc_id");

            migrationBuilder.CreateIndex(
                name: "IX_ForecastMaximumDemandProducts_types_of_products_id",
                table: "ForecastMaximumDemandProducts",
                column: "types_of_products_id");

            migrationBuilder.CreateIndex(
                name: "IX_ForecastMaximumDemandProducts_units_id",
                table: "ForecastMaximumDemandProducts",
                column: "units_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForecastMaximumDemandProducts");

            migrationBuilder.DropTable(
                name: "ForecastMaximumDemandProducts_id");
        }
    }
}
