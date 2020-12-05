using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pracka.Cup.Database.Migrations
{
    public partial class DateTimesAsUTC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "GameDate",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Histories");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUTC",
                table: "Teams",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 5, 20, 40, 46, 547, DateTimeKind.Utc).AddTicks(9746));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedUTC",
                table: "Teams",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 5, 20, 40, 46, 551, DateTimeKind.Utc).AddTicks(7729));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUTC",
                table: "Players",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 5, 20, 40, 46, 554, DateTimeKind.Utc).AddTicks(953));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedUTC",
                table: "Players",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 5, 20, 40, 46, 554, DateTimeKind.Utc).AddTicks(1263));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUTC",
                table: "Histories",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 5, 20, 40, 46, 556, DateTimeKind.Utc).AddTicks(7601));

            migrationBuilder.AddColumn<DateTime>(
                name: "GameDateUTC",
                table: "Histories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedUTC",
                table: "Histories",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 5, 20, 40, 46, 556, DateTimeKind.Utc).AddTicks(7865));

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedUTC",
                value: new DateTime(2020, 12, 5, 20, 40, 46, 564, DateTimeKind.Utc).AddTicks(4193));

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedUTC",
                value: new DateTime(2020, 12, 5, 20, 40, 46, 564, DateTimeKind.Utc).AddTicks(4520));

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedUTC",
                value: new DateTime(2020, 12, 5, 20, 40, 46, 564, DateTimeKind.Utc).AddTicks(4529));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedUTC",
                value: new DateTime(2020, 12, 5, 20, 40, 46, 561, DateTimeKind.Utc).AddTicks(6724));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedUTC",
                value: new DateTime(2020, 12, 5, 20, 40, 46, 563, DateTimeKind.Utc).AddTicks(3377));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedUTC",
                value: new DateTime(2020, 12, 5, 20, 40, 46, 563, DateTimeKind.Utc).AddTicks(3418));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedUTC",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ModifiedUTC",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "CreatedUTC",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ModifiedUTC",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CreatedUTC",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "GameDateUTC",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "ModifiedUTC",
                table: "Histories");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Histories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "GameDate",
                table: "Histories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Histories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2020, 12, 4, 21, 57, 28, 8, DateTimeKind.Utc).AddTicks(635), new DateTime(2020, 12, 4, 21, 57, 28, 8, DateTimeKind.Utc).AddTicks(640) });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2020, 12, 4, 21, 57, 28, 8, DateTimeKind.Utc).AddTicks(966), new DateTime(2020, 12, 4, 21, 57, 28, 8, DateTimeKind.Utc).AddTicks(969) });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2020, 12, 4, 21, 57, 28, 8, DateTimeKind.Utc).AddTicks(976), new DateTime(2020, 12, 4, 21, 57, 28, 8, DateTimeKind.Utc).AddTicks(977) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2020, 12, 4, 22, 57, 28, 5, DateTimeKind.Local).AddTicks(1611), new DateTime(2020, 12, 4, 22, 57, 28, 6, DateTimeKind.Local).AddTicks(8353) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2020, 12, 4, 22, 57, 28, 6, DateTimeKind.Local).AddTicks(9447), new DateTime(2020, 12, 4, 22, 57, 28, 6, DateTimeKind.Local).AddTicks(9464) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2020, 12, 4, 22, 57, 28, 6, DateTimeKind.Local).AddTicks(9482), new DateTime(2020, 12, 4, 22, 57, 28, 6, DateTimeKind.Local).AddTicks(9485) });
        }
    }
}
