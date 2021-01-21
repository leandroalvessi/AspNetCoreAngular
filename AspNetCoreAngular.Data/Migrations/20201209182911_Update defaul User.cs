using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreAngular.Data.Migrations
{
    public partial class UpdatedefaulUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d6de30c5-d2c1-40eb-a11c-d5a526f34862"),
                column: "DateCreate",
                value: new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d6de30c5-d2c1-40eb-a11c-d5a526f34862"),
                column: "DateCreate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
