using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MLM.DataLayer.Migrations
{
    public partial class _103 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPins_FranchiseIncomes_FranchiseIncomeID",
                table: "UserPins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPins_Users_UserID",
                table: "UserPins");

            migrationBuilder.DropIndex(
                name: "IX_UserPins_FranchiseIncomeID",
                table: "UserPins");

            migrationBuilder.DropIndex(
                name: "IX_UserPins_UserID",
                table: "UserPins");

            migrationBuilder.AddColumn<Guid>(
                name: "UserPinID",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "UserPins",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "FranchiseIncomeID",
                table: "UserPins",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "UserPinID",
                table: "FranchiseIncomes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserPinID",
                table: "Users",
                column: "UserPinID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPins_UserID",
                table: "UserPins",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FranchiseIncomes_UserPinID",
                table: "FranchiseIncomes",
                column: "UserPinID");

            migrationBuilder.AddForeignKey(
                name: "FK_FranchiseIncomes_UserPins_UserPinID",
                table: "FranchiseIncomes",
                column: "UserPinID",
                principalTable: "UserPins",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserPins_UserPinID",
                table: "Users",
                column: "UserPinID",
                principalTable: "UserPins",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FranchiseIncomes_UserPins_UserPinID",
                table: "FranchiseIncomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserPins_UserPinID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserPinID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserPins_UserID",
                table: "UserPins");

            migrationBuilder.DropIndex(
                name: "IX_FranchiseIncomes_UserPinID",
                table: "FranchiseIncomes");

            migrationBuilder.DropColumn(
                name: "UserPinID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserPinID",
                table: "FranchiseIncomes");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "UserPins",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FranchiseIncomeID",
                table: "UserPins",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserPins_FranchiseIncomes_FranchiseIncomeID",
                table: "UserPins",
                column: "FranchiseIncomeID",
                principalTable: "FranchiseIncomes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPins_Users_UserID",
                table: "UserPins",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
