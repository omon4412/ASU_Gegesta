using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASU_Degesta.Migrations
{
    public partial class int_double : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "cost_price",
                table: "ReportProductCost",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "cost_price",
                table: "ReportProductCost",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }
    }
}
