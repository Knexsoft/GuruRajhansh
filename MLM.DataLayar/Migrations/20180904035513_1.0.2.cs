using Microsoft.EntityFrameworkCore.Migrations;

namespace MLM.DataLayer.Migrations
{
    public partial class _102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LevelIncomes_LevelIncomeTypes_LevelIncomeTypeID",
                table: "LevelIncomes");

            migrationBuilder.DropIndex(
                name: "IX_LevelIncomes_LevelIncomeTypeID",
                table: "LevelIncomes");

            migrationBuilder.DropColumn(
                name: "LevelIncomeTypeID",
                table: "LevelIncomes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
