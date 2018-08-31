using Microsoft.EntityFrameworkCore.Migrations;

namespace MLM.DataLayer.Migrations
{
    public partial class _101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPins_Users_UserID",
                table: "UserPins");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPins_Users_UserID",
                table: "UserPins",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPins_Users_UserID",
                table: "UserPins");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPins_Users_UserID",
                table: "UserPins",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
