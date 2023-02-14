﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASU_Degesta.Migrations
{
    public partial class sales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpecificationContractMaterials_id",
                columns: table => new
                {
                    doc_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    doc_name = table.Column<string>(type: "longtext", nullable: false),
                    creation_date = table.Column<string>(type: "longtext", nullable: false),
                    creator = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationContractMaterials_id", x => x.doc_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecificationContractMaterials_id");
        }
    }
}
