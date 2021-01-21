using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreAngular.Data.Migrations
{
    public partial class Insertnewuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[] { new Guid("d6de30c5-d2c1-40eb-a11c-d5a526f34862"), "userdefaul@AspNetCoreAngular.com", "User Default" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d6de30c5-d2c1-40eb-a11c-d5a526f34862"));
        }
    }
}
