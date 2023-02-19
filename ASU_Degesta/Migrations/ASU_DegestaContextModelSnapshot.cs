﻿// <auto-generated />
using System;
using ASU_Degesta.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASU_Degesta.Migrations
{
    [DbContext(typeof(ASU_DegestaContext))]
    partial class ASU_DegestaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ASU_Degesta.Models.Accounting.payroll_statement", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("bonus")
                        .HasColumnType("double");

                    b.Property<string>("doc_id")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("employee_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("employee_number")
                        .HasColumnType("int");

                    b.Property<double>("salary")
                        .HasColumnType("double");

                    b.Property<double>("to_issue")
                        .HasColumnType("double");

                    b.Property<double>("total_accrued")
                        .HasColumnType("double");

                    b.Property<double>("withheld")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.HasIndex("doc_id");

                    b.ToTable("payroll_statement");
                });

            modelBuilder.Entity("ASU_Degesta.Models.Accounting.payroll_statement_name_id", b =>
                {
                    b.Property<string>("doc_id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("creation_date")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("creator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("doc_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("doc_id");

                    b.ToTable("payroll_statement_name_id");
                });

            modelBuilder.Entity("ASU_Degesta.Models.DegestaUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Job")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("ASU_Degesta.Models.Handbooks.types_of_products", b =>
                {
                    b.Property<int>("types_of_products_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("types_of_products_id");

                    b.ToTable("types_of_products");
                });

            modelBuilder.Entity("ASU_Degesta.Models.Handbooks.TypesOfProducts", b =>
                {
                    b.Property<string>("TypesOfProductsId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("TypesOfProductsId");

                    b.ToTable("TypesOfProducts");
                });

            modelBuilder.Entity("ASU_Degesta.Models.Handbooks.Units", b =>
                {
                    b.Property<int>("Units_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Units_ID");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("ASU_Degesta.Models.PED.ReportProductCost", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("cost_price")
                        .HasColumnType("double");

                    b.Property<string>("doc_id")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("types_of_products_id")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("units_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("doc_id");

                    b.HasIndex("types_of_products_id");

                    b.HasIndex("units_id");

                    b.ToTable("ReportProductCost");
                });

            modelBuilder.Entity("ASU_Degesta.Models.PED.ReportProductCost_id", b =>
                {
                    b.Property<string>("doc_id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("creation_date")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("creator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("doc_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("doc_id");

                    b.ToTable("ReportProductCost_id");
                });

            modelBuilder.Entity("ASU_Degesta.Models.PED.ReportProductPlan", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("doc_id")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("produced")
                        .HasColumnType("int");

                    b.Property<string>("types_of_products_id")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("units_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("doc_id");

                    b.HasIndex("types_of_products_id");

                    b.HasIndex("units_id");

                    b.ToTable("ReportProductPlan");
                });

            modelBuilder.Entity("ASU_Degesta.Models.PED.ReportProductPlan_id", b =>
                {
                    b.Property<string>("doc_id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("creation_date")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("creator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("doc_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("doc_id");

                    b.ToTable("ReportProductPlan_id");
                });

            modelBuilder.Entity("ASU_Degesta.Models.ProductionDepartment.ReportMatherialCosts", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("direct_costs")
                        .HasColumnType("double");

                    b.Property<string>("doc_id")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<double>("general_business_invoices")
                        .HasColumnType("double");

                    b.Property<double>("overhead_production_costs")
                        .HasColumnType("double");

                    b.Property<string>("types_of_products_id")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("units_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("doc_id");

                    b.HasIndex("types_of_products_id");

                    b.HasIndex("units_id");

                    b.ToTable("ReportMatherialCosts");
                });

            modelBuilder.Entity("ASU_Degesta.Models.ProductionDepartment.ReportMatherialCosts_id", b =>
                {
                    b.Property<string>("doc_id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("creation_date")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("creator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("doc_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("doc_id");

                    b.ToTable("ReportMatherialCosts_id");
                });

            modelBuilder.Entity("ASU_Degesta.Models.SalesDepartment.SpecificationContractMaterials", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("count_of_matherials")
                        .HasColumnType("int");

                    b.Property<string>("doc_id")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<double>("price")
                        .HasColumnType("double");

                    b.Property<double>("price_per_unit")
                        .HasColumnType("double");

                    b.Property<string>("types_of_products_id")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("units_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("doc_id");

                    b.HasIndex("types_of_products_id");

                    b.HasIndex("units_id");

                    b.ToTable("SpecificationContractMaterials");
                });

            modelBuilder.Entity("ASU_Degesta.Models.SalesDepartment.SpecificationContractMaterials_id", b =>
                {
                    b.Property<string>("doc_id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("creation_date")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("creator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("doc_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("doc_id");

                    b.ToTable("SpecificationContractMaterials_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ASU_Degesta.Models.Accounting.payroll_statement", b =>
                {
                    b.HasOne("ASU_Degesta.Models.Accounting.payroll_statement_name_id", "payroll_statement_name_id")
                        .WithMany()
                        .HasForeignKey("doc_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("payroll_statement_name_id");
                });

            modelBuilder.Entity("ASU_Degesta.Models.PED.ReportProductCost", b =>
                {
                    b.HasOne("ASU_Degesta.Models.PED.ReportProductCost_id", "ReportProductPlan_id")
                        .WithMany()
                        .HasForeignKey("doc_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASU_Degesta.Models.Handbooks.TypesOfProducts", "TypesOfProducts")
                        .WithMany()
                        .HasForeignKey("types_of_products_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASU_Degesta.Models.Handbooks.Units", "Units")
                        .WithMany()
                        .HasForeignKey("units_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReportProductPlan_id");

                    b.Navigation("TypesOfProducts");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("ASU_Degesta.Models.PED.ReportProductPlan", b =>
                {
                    b.HasOne("ASU_Degesta.Models.PED.ReportProductPlan_id", "ReportProductPlan_id")
                        .WithMany()
                        .HasForeignKey("doc_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASU_Degesta.Models.Handbooks.TypesOfProducts", "TypesOfProducts")
                        .WithMany()
                        .HasForeignKey("types_of_products_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASU_Degesta.Models.Handbooks.Units", "Units")
                        .WithMany()
                        .HasForeignKey("units_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReportProductPlan_id");

                    b.Navigation("TypesOfProducts");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("ASU_Degesta.Models.ProductionDepartment.ReportMatherialCosts", b =>
                {
                    b.HasOne("ASU_Degesta.Models.ProductionDepartment.ReportMatherialCosts_id", "ReportMatherialCosts_id")
                        .WithMany()
                        .HasForeignKey("doc_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASU_Degesta.Models.Handbooks.TypesOfProducts", "TypesOfProducts")
                        .WithMany()
                        .HasForeignKey("types_of_products_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASU_Degesta.Models.Handbooks.Units", "Units")
                        .WithMany()
                        .HasForeignKey("units_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReportMatherialCosts_id");

                    b.Navigation("TypesOfProducts");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("ASU_Degesta.Models.SalesDepartment.SpecificationContractMaterials", b =>
                {
                    b.HasOne("ASU_Degesta.Models.SalesDepartment.SpecificationContractMaterials_id", "SpecificationContractMaterials_id")
                        .WithMany()
                        .HasForeignKey("doc_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASU_Degesta.Models.Handbooks.TypesOfProducts", "TypesOfProducts")
                        .WithMany()
                        .HasForeignKey("types_of_products_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASU_Degesta.Models.Handbooks.Units", "Units")
                        .WithMany()
                        .HasForeignKey("units_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SpecificationContractMaterials_id");

                    b.Navigation("TypesOfProducts");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ASU_Degesta.Models.DegestaUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ASU_Degesta.Models.DegestaUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASU_Degesta.Models.DegestaUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ASU_Degesta.Models.DegestaUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
