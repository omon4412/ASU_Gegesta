using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ASU_Degesta.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.CreateTable(
            //     name: "AspNetRoles",
            //     columns: table => new
            //     {
            //         Id = table.Column<string>(type: "varchar(255)", nullable: false),
            //         Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
            //         NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
            //         ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //     });
            //
            // migrationBuilder.CreateTable(
            //     name: "AspNetUsers",
            //     columns: table => new
            //     {
            //         Id = table.Column<string>(type: "varchar(255)", nullable: false),
            //         Name = table.Column<string>(type: "longtext", nullable: true),
            //         Job = table.Column<string>(type: "longtext", nullable: true),
            //         UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
            //         NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
            //         Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
            //         NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
            //         EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
            //         PasswordHash = table.Column<string>(type: "longtext", nullable: true),
            //         SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
            //         ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
            //         PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
            //         PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
            //         TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
            //         LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
            //         LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
            //         AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //     });
            //
            // migrationBuilder.CreateTable(
            //     name: "payroll_statement",
            //     columns: table => new
            //     {
            //         id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
            //         doc_id = table.Column<string>(type: "varchar(50)", nullable: false),
            //         employee_number = table.Column<int>(type: "int", nullable: false),
            //         employee_name = table.Column<string>(type: "longtext", nullable: false),
            //         salary = table.Column<double>(type: "double", nullable: false),
            //         bonus = table.Column<double>(type: "double", nullable: false),
            //         total_accrued = table.Column<double>(type: "double", nullable: false),
            //         withheld = table.Column<double>(type: "double", nullable: false),
            //         to_issue = table.Column<double>(type: "double", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_payroll_statement", x => x.id);
            //     });
            //
            // migrationBuilder.CreateTable(
            //     name: "payroll_statement_name_id",
            //     columns: table => new
            //     {
            //         doc_id = table.Column<string>(type: "varchar(255)", nullable: false),
            //         doc_name = table.Column<string>(type: "longtext", nullable: false),
            //         creation_date = table.Column<string>(type: "longtext", nullable: false),
            //         creator = table.Column<string>(type: "longtext", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_payroll_statement_name_id", x => x.doc_id);
            //     });
            //
            // migrationBuilder.CreateTable(
            //     name: "types_of_products",
            //     columns: table => new
            //     {
            //         types_of_products_id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
            //         code = table.Column<string>(type: "longtext", nullable: false),
            //         Name = table.Column<string>(type: "longtext", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_types_of_products", x => x.types_of_products_id);
            //     });
            //
            // migrationBuilder.CreateTable(
            //     name: "TypesOfProducts",
            //     columns: table => new
            //     {
            //         TypesOfProductsId = table.Column<string>(type: "varchar(255)", nullable: false),
            //         Name = table.Column<string>(type: "longtext", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_TypesOfProducts", x => x.TypesOfProductsId);
            //     });
            //
            // migrationBuilder.CreateTable(
            //     name: "Units",
            //     columns: table => new
            //     {
            //         Units_ID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
            //         Name = table.Column<string>(type: "longtext", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Units", x => x.Units_ID);
            //     });
            //
            // migrationBuilder.CreateTable(
            //     name: "AspNetRoleClaims",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
            //         RoleId = table.Column<string>(type: "varchar(255)", nullable: false),
            //         ClaimType = table.Column<string>(type: "longtext", nullable: true),
            //         ClaimValue = table.Column<string>(type: "longtext", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //             column: x => x.RoleId,
            //             principalTable: "AspNetRoles",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });
            //
            // migrationBuilder.CreateTable(
            //     name: "AspNetUserClaims",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
            //         UserId = table.Column<string>(type: "varchar(255)", nullable: false),
            //         ClaimType = table.Column<string>(type: "longtext", nullable: true),
            //         ClaimValue = table.Column<string>(type: "longtext", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //             column: x => x.UserId,
            //             principalTable: "AspNetUsers",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });
            //
            // migrationBuilder.CreateTable(
            //     name: "AspNetUserLogins",
            //     columns: table => new
            //     {
            //         LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
            //         ProviderKey = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
            //         ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
            //         UserId = table.Column<string>(type: "varchar(255)", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //         table.ForeignKey(
            //             name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //             column: x => x.UserId,
            //             principalTable: "AspNetUsers",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });
            //
            // migrationBuilder.CreateTable(
            //     name: "AspNetUserRoles",
            //     columns: table => new
            //     {
            //         UserId = table.Column<string>(type: "varchar(255)", nullable: false),
            //         RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //         table.ForeignKey(
            //             name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //             column: x => x.RoleId,
            //             principalTable: "AspNetRoles",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //             column: x => x.UserId,
            //             principalTable: "AspNetUsers",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });
            //
            // migrationBuilder.CreateTable(
            //     name: "AspNetUserTokens",
            //     columns: table => new
            //     {
            //         UserId = table.Column<string>(type: "varchar(255)", nullable: false),
            //         LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
            //         Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
            //         Value = table.Column<string>(type: "longtext", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //         table.ForeignKey(
            //             name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //             column: x => x.UserId,
            //             principalTable: "AspNetUsers",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });

            migrationBuilder.CreateTable(
                name: "SpecificationContractMaterials",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    doc_id = table.Column<string>(type: "longtext", nullable: false),
                    types_of_productsTypesOfProductsId = table.Column<string>(type: "varchar(255)", nullable: true),
                    count_of_matherials = table.Column<int>(type: "int", nullable: false),
                    price_per_unit = table.Column<double>(type: "double", nullable: false),
                    price = table.Column<double>(type: "double", nullable: false),
                    Units_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationContractMaterials", x => x.id);
                    table.ForeignKey(
                        name: "FK_SpecificationContractMaterials_TypesOfProducts_types_of_prod~",
                        column: x => x.types_of_productsTypesOfProductsId,
                        principalTable: "TypesOfProducts",
                        principalColumn: "TypesOfProductsId");
                    table.ForeignKey(
                        name: "FK_SpecificationContractMaterials_Units_Units_ID",
                        column: x => x.Units_ID,
                        principalTable: "Units",
                        principalColumn: "Units_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            // migrationBuilder.CreateIndex(
            //     name: "IX_AspNetRoleClaims_RoleId",
            //     table: "AspNetRoleClaims",
            //     column: "RoleId");
            //
            // migrationBuilder.CreateIndex(
            //     name: "RoleNameIndex",
            //     table: "AspNetRoles",
            //     column: "NormalizedName",
            //     unique: true);
            //
            // migrationBuilder.CreateIndex(
            //     name: "IX_AspNetUserClaims_UserId",
            //     table: "AspNetUserClaims",
            //     column: "UserId");
            //
            // migrationBuilder.CreateIndex(
            //     name: "IX_AspNetUserLogins_UserId",
            //     table: "AspNetUserLogins",
            //     column: "UserId");
            //
            // migrationBuilder.CreateIndex(
            //     name: "IX_AspNetUserRoles_RoleId",
            //     table: "AspNetUserRoles",
            //     column: "RoleId");
            //
            // migrationBuilder.CreateIndex(
            //     name: "EmailIndex",
            //     table: "AspNetUsers",
            //     column: "NormalizedEmail");
            //
            // migrationBuilder.CreateIndex(
            //     name: "UserNameIndex",
            //     table: "AspNetUsers",
            //     column: "NormalizedUserName",
            //     unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationContractMaterials_types_of_productsTypesOfProdu~",
                table: "SpecificationContractMaterials",
                column: "types_of_productsTypesOfProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationContractMaterials_Units_ID",
                table: "SpecificationContractMaterials",
                column: "Units_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "payroll_statement");

            migrationBuilder.DropTable(
                name: "payroll_statement_name_id");

            migrationBuilder.DropTable(
                name: "SpecificationContractMaterials");

            migrationBuilder.DropTable(
                name: "types_of_products");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TypesOfProducts");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
