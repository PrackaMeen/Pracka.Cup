using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pracka.Cup.Database.Migrations
{
    public partial class DataFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "LastName", "Nickname" },
                values: new object[] { "4", "Player4" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedUTC", "ModifiedUTC" },
                values: new object[] { new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedUTC", "ModifiedUTC" },
                values: new object[] { new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedUTC", "ModifiedUTC" },
                values: new object[] { new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "LastName", "Nickname" },
                values: new object[] { "3", "Player3" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedUTC", "ModifiedUTC" },
                values: new object[] { new DateTime(2020, 12, 20, 17, 56, 54, 972, DateTimeKind.Utc).AddTicks(1386), new DateTime(2020, 12, 20, 17, 56, 54, 973, DateTimeKind.Utc).AddTicks(7083) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedUTC", "ModifiedUTC" },
                values: new object[] { new DateTime(2020, 12, 20, 17, 56, 54, 973, DateTimeKind.Utc).AddTicks(8161), new DateTime(2020, 12, 20, 17, 56, 54, 973, DateTimeKind.Utc).AddTicks(8178) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedUTC", "ModifiedUTC" },
                values: new object[] { new DateTime(2020, 12, 20, 17, 56, 54, 973, DateTimeKind.Utc).AddTicks(8195), new DateTime(2020, 12, 20, 17, 56, 54, 973, DateTimeKind.Utc).AddTicks(8198) });
        }
    }
}
