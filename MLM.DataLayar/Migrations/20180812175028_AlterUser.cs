using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MLM.DataLayer.Migrations
{
    public partial class AlterUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FranchiseIncomeTypes",
                columns: table => new
                {
                    FranchiseIncomeTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pins = table.Column<int>(nullable: false),
                    FreePins = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FranchiseIncomeTypes", x => x.FranchiseIncomeTypeID);
                });

            migrationBuilder.CreateTable(
                name: "LevelIncomeTypes",
                columns: table => new
                {
                    LevelIncomeTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LevelNo = table.Column<int>(nullable: false),
                    IncomePercentage = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelIncomeTypes", x => x.LevelIncomeTypeID);
                });

            migrationBuilder.CreateTable(
                name: "SingleLegIncomeTypes",
                columns: table => new
                {
                    SingleLegIncomeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LevelNo = table.Column<int>(nullable: false),
                    Directs = table.Column<int>(nullable: false),
                    Teams = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    UpgradeCharge = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleLegIncomeTypes", x => x.SingleLegIncomeID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    SponserID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 80, nullable: true),
                    ContactNumber = table.Column<string>(maxLength: 10, nullable: false),
                    EmailID = table.Column<string>(maxLength: 100, nullable: true),
                    Gender = table.Column<string>(maxLength: 10, nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: false),
                    UserRole = table.Column<string>(maxLength: 10, nullable: false),
                    PasswordSalt = table.Column<string>(maxLength: 100, nullable: false),
                    HashPassword = table.Column<string>(maxLength: 100, nullable: false),
                    ParentSponserID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ActiveToken = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FranchiseIncomes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    FranchiseIncomeTypeID = table.Column<int>(nullable: false),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    Income = table.Column<decimal>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FranchiseIncomes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FranchiseIncomes_FranchiseIncomeTypes_FranchiseIncomeTypeID",
                        column: x => x.FranchiseIncomeTypeID,
                        principalTable: "FranchiseIncomeTypes",
                        principalColumn: "FranchiseIncomeTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FranchiseIncomes_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LevelIncomes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    LevelIncomeTypeID = table.Column<int>(nullable: false),
                    Income = table.Column<decimal>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelIncomes", x => x.UserID);
                    table.UniqueConstraint("AK_LevelIncomes_ID", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LevelIncomes_LevelIncomeTypes_LevelIncomeTypeID",
                        column: x => x.LevelIncomeTypeID,
                        principalTable: "LevelIncomeTypes",
                        principalColumn: "LevelIncomeTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LevelIncomes_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SingleLegIncomes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    SingleLegIncomeID = table.Column<int>(nullable: false),
                    TotalDirects = table.Column<int>(nullable: false),
                    TotalTeams = table.Column<int>(nullable: false),
                    LevelCompleteDate = table.Column<DateTime>(nullable: false),
                    SingleLegIncomeAmount = table.Column<decimal>(nullable: false),
                    LevelIncomeAmount = table.Column<decimal>(nullable: false),
                    TotalIncome = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleLegIncomes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SingleLegIncomes_SingleLegIncomeTypes_SingleLegIncomeID",
                        column: x => x.SingleLegIncomeID,
                        principalTable: "SingleLegIncomeTypes",
                        principalColumn: "SingleLegIncomeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SingleLegIncomes_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPins",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FranchiseIncomeID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    Pin = table.Column<int>(nullable: false),
                    IsUsed = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPins", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserPins_FranchiseIncomes_FranchiseIncomeID",
                        column: x => x.FranchiseIncomeID,
                        principalTable: "FranchiseIncomes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPins_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FranchiseIncomes_FranchiseIncomeTypeID",
                table: "FranchiseIncomes",
                column: "FranchiseIncomeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_FranchiseIncomes_UserID",
                table: "FranchiseIncomes",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_LevelIncomes_LevelIncomeTypeID",
                table: "LevelIncomes",
                column: "LevelIncomeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_LevelIncomeTypes_LevelNo",
                table: "LevelIncomeTypes",
                column: "LevelNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SingleLegIncomes_SingleLegIncomeID",
                table: "SingleLegIncomes",
                column: "SingleLegIncomeID");

            migrationBuilder.CreateIndex(
                name: "IX_SingleLegIncomes_UserID",
                table: "SingleLegIncomes",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SingleLegIncomeTypes_LevelNo",
                table: "SingleLegIncomeTypes",
                column: "LevelNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPins_FranchiseIncomeID",
                table: "UserPins",
                column: "FranchiseIncomeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPins_UserID",
                table: "UserPins",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SponserID",
                table: "Users",
                column: "SponserID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LevelIncomes");

            migrationBuilder.DropTable(
                name: "SingleLegIncomes");

            migrationBuilder.DropTable(
                name: "UserPins");

            migrationBuilder.DropTable(
                name: "LevelIncomeTypes");

            migrationBuilder.DropTable(
                name: "SingleLegIncomeTypes");

            migrationBuilder.DropTable(
                name: "FranchiseIncomes");

            migrationBuilder.DropTable(
                name: "FranchiseIncomeTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
