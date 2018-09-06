using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MLM.DataLayer.Migrations
{
    public partial class _103 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LevelIncomes_LevelIncomeTypes_LevelIncomeTypeID",
                table: "LevelIncomes");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelIncomes_Users_UserID",
                table: "LevelIncomes");

            migrationBuilder.DropIndex(
                name: "IX_LevelIncomes_LevelIncomeTypeID",
                table: "LevelIncomes");

            migrationBuilder.DropColumn(
                name: "LevelIncomeTypeID",
                table: "LevelIncomes");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "LevelIncomes",
                nullable: false,
                oldClrType: typeof(Guid));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "LevelIncomes",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "LevelIncomeTypeID",
                table: "LevelIncomes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LevelIncomes_LevelIncomeTypeID",
                table: "LevelIncomes",
                column: "LevelIncomeTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_LevelIncomes_LevelIncomeTypes_LevelIncomeTypeID",
                table: "LevelIncomes",
                column: "LevelIncomeTypeID",
                principalTable: "LevelIncomeTypes",
                principalColumn: "LevelIncomeTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelIncomes_Users_UserID",
                table: "LevelIncomes",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
