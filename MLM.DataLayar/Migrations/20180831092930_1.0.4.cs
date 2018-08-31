using Microsoft.EntityFrameworkCore.Migrations;

namespace MLM.DataLayer.Migrations
{
    public partial class _104 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserPins_UserID",
                table: "UserPins");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "UserPins",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "UserPins",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPins_UserID",
                table: "UserPins",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");
        }
    }
}
