using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ASU_Degesta.Migrations
{
    public partial class RepMathCosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportMatherialCosts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    doc_id = table.Column<string>(type: "longtext", nullable: false),
                    types_of_products_id = table.Column<string>(type: "longtext", nullable: false),
                    direct_costs = table.Column<double>(type: "double", nullable: false),
                    overhead_production_costs = table.Column<double>(type: "double", nullable: false),
                    general_business_invoices = table.Column<double>(type: "double", nullable: false),
                    units_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportMatherialCosts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ReportMatherialCosts_id",
                columns: table => new
                {
                    doc_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    doc_name = table.Column<string>(type: "longtext", nullable: false),
                    creation_date = table.Column<string>(type: "longtext", nullable: false),
                    creator = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportMatherialCosts_id", x => x.doc_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportMatherialCosts");

            migrationBuilder.DropTable(
                name: "ReportMatherialCosts_id");
        }
    }
}
