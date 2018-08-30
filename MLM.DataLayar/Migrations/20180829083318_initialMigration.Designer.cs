﻿// <auto-generated />
using System;
using MLM.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MLM.DataLayer.Migrations
{
    [DbContext(typeof(MLMDbContext))]
    [Migration("20180829083318_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MLM.DataLayer.EntityModel.FranchiseIncome", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("FranchiseIncomeTypeID");

                    b.Property<decimal>("Income");

                    b.Property<decimal>("TotalAmount");

                    b.Property<Guid>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("FranchiseIncomeTypeID");

                    b.HasIndex("UserID");

                    b.ToTable("FranchiseIncomes");
                });

            modelBuilder.Entity("MLM.DataLayer.EntityModel.FranchiseIncomeType", b =>
                {
                    b.Property<int>("FranchiseIncomeTypeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<int>("FreePins");

                    b.Property<int>("Pins");

                    b.HasKey("FranchiseIncomeTypeID");

                    b.ToTable("FranchiseIncomeTypes");
                });

            modelBuilder.Entity("MLM.DataLayer.EntityModel.LevelIncome", b =>
                {
                    b.Property<Guid>("UserID");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid>("ID");

                    b.Property<decimal>("Income");

                    b.Property<int>("LevelIncomeTypeID");

                    b.HasKey("UserID");

                    b.HasAlternateKey("ID");

                    b.HasIndex("LevelIncomeTypeID");

                    b.ToTable("LevelIncomes");
                });

            modelBuilder.Entity("MLM.DataLayer.EntityModel.LevelIncomeType", b =>
                {
                    b.Property<int>("LevelIncomeTypeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("IncomePercentage");

                    b.Property<int>("LevelNo");

                    b.HasKey("LevelIncomeTypeID");

                    b.HasIndex("LevelNo")
                        .IsUnique();

                    b.ToTable("LevelIncomeTypes");
                });

            modelBuilder.Entity("MLM.DataLayer.EntityModel.SingleLegIncome", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LevelCompleteDate");

                    b.Property<decimal>("LevelIncomeAmount");

                    b.Property<decimal>("SingleLegIncomeAmount");

                    b.Property<int>("SingleLegIncomeID");

                    b.Property<int>("TotalDirects");

                    b.Property<decimal>("TotalIncome");

                    b.Property<int>("TotalTeams");

                    b.Property<Guid>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("SingleLegIncomeID");

                    b.HasIndex("UserID");

                    b.ToTable("SingleLegIncomes");
                });

            modelBuilder.Entity("MLM.DataLayer.EntityModel.SingleLegIncomeType", b =>
                {
                    b.Property<int>("SingleLegIncomeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<int>("Directs");

                    b.Property<int>("LevelNo");

                    b.Property<int>("Teams");

                    b.Property<decimal>("UpgradeCharge");

                    b.HasKey("SingleLegIncomeID");

                    b.HasIndex("LevelNo")
                        .IsUnique();

                    b.ToTable("SingleLegIncomeTypes");
                });

            modelBuilder.Entity("MLM.DataLayer.EntityModel.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActiveToken")
                        .HasMaxLength(8);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("EmailID")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("HashPassword")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName")
                        .HasMaxLength(80);

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<int>("ParentSponserID");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("SponserID");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("ID");

                    b.HasIndex("SponserID")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MLM.DataLayer.EntityModel.UserPin", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid>("FranchiseIncomeID");

                    b.Property<bool>("IsUsed");

                    b.Property<int>("Pin");

                    b.Property<Guid>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("FranchiseIncomeID")
                        .IsUnique();

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("UserPins");
                });

            modelBuilder.Entity("MLM.DataLayer.EntityModel.FranchiseIncome", b =>
                {
                    b.HasOne("MLM.DataLayer.EntityModel.FranchiseIncomeType", "FranchiseIncomeType")
                        .WithMany("FranchiseIncomes")
                        .HasForeignKey("FranchiseIncomeTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MLM.DataLayer.EntityModel.User", "User")
                        .WithMany("FrenchiseIncomes")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MLM.DataLayer.EntityModel.LevelIncome", b =>
                {
                    b.HasOne("MLM.DataLayer.EntityModel.LevelIncomeType", "LevelIncomeType")
                        .WithMany("LevelIncomes")
                        .HasForeignKey("LevelIncomeTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MLM.DataLayer.EntityModel.User", "User")
                        .WithMany("LevelIncomes")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MLM.DataLayer.EntityModel.SingleLegIncome", b =>
                {
                    b.HasOne("MLM.DataLayer.EntityModel.SingleLegIncomeType", "SingleLegIncomeType")
                        .WithMany("SingleLegIncomes")
                        .HasForeignKey("SingleLegIncomeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MLM.DataLayer.EntityModel.User", "User")
                        .WithMany("SingleLegIncomes")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MLM.DataLayer.EntityModel.UserPin", b =>
                {
                    b.HasOne("MLM.DataLayer.EntityModel.FranchiseIncome", "FranchiseIncome")
                        .WithOne("UserPin")
                        .HasForeignKey("MLM.DataLayer.EntityModel.UserPin", "FranchiseIncomeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MLM.DataLayer.EntityModel.User", "User")
                        .WithOne("UserPin")
                        .HasForeignKey("MLM.DataLayer.EntityModel.UserPin", "UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}