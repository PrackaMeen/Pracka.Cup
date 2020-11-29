using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pracka.Cup.Database.Migrations
{
    public partial class Teamsinitialseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Created", "Icon", "Modified", "Name" },
                values: new object[] { 1, new DateTime(2020, 11, 29, 21, 3, 55, 14, DateTimeKind.Local).AddTicks(6878), "BOSTON_BRUINS", new DateTime(2020, 11, 29, 21, 3, 55, 18, DateTimeKind.Local).AddTicks(9413), "Boston" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Created", "Icon", "Modified", "Name" },
                values: new object[] { 2, new DateTime(2020, 11, 29, 21, 3, 55, 19, DateTimeKind.Local).AddTicks(468), "BUFFALO_SABRES", new DateTime(2020, 11, 29, 21, 3, 55, 19, DateTimeKind.Local).AddTicks(484), "Buffalo" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Created", "Icon", "Modified", "Name" },
                values: new object[] { 3, new DateTime(2020, 11, 29, 21, 3, 55, 19, DateTimeKind.Local).AddTicks(502), "PHILADELPHIA_FLYERS", new DateTime(2020, 11, 29, 21, 3, 55, 19, DateTimeKind.Local).AddTicks(505), "Philadelpia" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
