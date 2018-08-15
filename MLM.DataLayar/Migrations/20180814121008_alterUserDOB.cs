using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MLM.DataLayer.Migrations
{
    public partial class alterUserDOB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "ActiveToken",
                table: "Users",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ActiveToken",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
