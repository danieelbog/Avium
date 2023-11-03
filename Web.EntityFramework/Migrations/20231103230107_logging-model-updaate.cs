using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.EntityFramework.Migrations
{
    public partial class loggingmodelupdaate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_loggingData_AspNetUsers_CreatedById",
                table: "loggingData");

            migrationBuilder.DropForeignKey(
                name: "FK_loggingData_AspNetUsers_UpdatedById",
                table: "loggingData");

            migrationBuilder.DropIndex(
                name: "IX_loggingData_CreatedById",
                table: "loggingData");

            migrationBuilder.DropIndex(
                name: "IX_loggingData_UpdatedById",
                table: "loggingData");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "loggingData");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "loggingData");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "loggingData");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "loggingData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "loggingData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "loggingData",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "loggingData",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "loggingData",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_loggingData_CreatedById",
                table: "loggingData",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_loggingData_UpdatedById",
                table: "loggingData",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_loggingData_AspNetUsers_CreatedById",
                table: "loggingData",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_loggingData_AspNetUsers_UpdatedById",
                table: "loggingData",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
