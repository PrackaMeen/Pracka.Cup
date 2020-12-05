using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pracka.Cup.Database.Migrations
{
    public partial class GameResultsChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedUTC",
                table: "Teams",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 5, 22, 16, 22, 791, DateTimeKind.Utc).AddTicks(8859),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 5, 20, 40, 46, 551, DateTimeKind.Utc).AddTicks(7729));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedUTC",
                table: "Teams",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 5, 22, 16, 22, 787, DateTimeKind.Utc).AddTicks(7922),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 5, 20, 40, 46, 547, DateTimeKind.Utc).AddTicks(9746));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedUTC",
                table: "Players",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 5, 22, 16, 22, 796, DateTimeKind.Utc).AddTicks(5091),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 5, 20, 40, 46, 554, DateTimeKind.Utc).AddTicks(1263));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedUTC",
                table: "Players",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 5, 22, 16, 22, 796, DateTimeKind.Utc).AddTicks(4789),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 5, 20, 40, 46, 554, DateTimeKind.Utc).AddTicks(953));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedUTC",
                table: "Histories",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 5, 22, 16, 22, 799, DateTimeKind.Utc).AddTicks(6124),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 5, 20, 40, 46, 556, DateTimeKind.Utc).AddTicks(7865));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedUTC",
                table: "Histories",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 5, 22, 16, 22, 799, DateTimeKind.Utc).AddTicks(5768),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 5, 20, 40, 46, 556, DateTimeKind.Utc).AddTicks(7601));

            migrationBuilder.AddColumn<int>(
                name: "GameType",
                table: "Histories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedUTC",
                value: new DateTime(2020, 12, 5, 22, 16, 22, 799, DateTimeKind.Utc).AddTicks(3328));

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedUTC",
                value: new DateTime(2020, 12, 5, 22, 16, 22, 799, DateTimeKind.Utc).AddTicks(3675));

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedUTC",
                value: new DateTime(2020, 12, 5, 22, 16, 22, 799, DateTimeKind.Utc).AddTicks(3684));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedUTC",
                value: new DateTime(2020, 12, 5, 22, 16, 22, 793, DateTimeKind.Utc).AddTicks(6888));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedUTC",
                value: new DateTime(2020, 12, 5, 22, 16, 22, 795, DateTimeKind.Utc).AddTicks(4682));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedUTC",
                value: new DateTime(2020, 12, 5, 22, 16, 22, 795, DateTimeKind.Utc).AddTicks(4717));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameType",
                table: "Histories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedUTC",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 5, 20, 40, 46, 551, DateTimeKind.Utc).AddTicks(7729),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 12, 5, 22, 16, 22, 791, DateTimeKind.Utc).AddTicks(8859));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedUTC",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 5, 20, 40, 46, 547, DateTimeKind.Utc).AddTicks(9746),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 12, 5, 22, 16, 22, 787, DateTimeKind.Utc).AddTicks(7922));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedUTC",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 5, 20, 40, 46, 554, DateTimeKind.Utc).AddTicks(1263),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 12, 5, 22, 16, 22, 796, DateTimeKind.Utc).AddTicks(5091));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedUTC",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 5, 20, 40, 46, 554, DateTimeKind.Utc).AddTicks(953),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 12, 5, 22, 16, 22, 796, DateTimeKind.Utc).AddTicks(4789));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedUTC",
                table: "Histories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 5, 20, 40, 46, 556, DateTimeKind.Utc).AddTicks(7865),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 12, 5, 22, 16, 22, 799, DateTimeKind.Utc).AddTicks(6124));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedUTC",
                table: "Histories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 5, 20, 40, 46, 556, DateTimeKind.Utc).AddTicks(7601),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 12, 5, 22, 16, 22, 799, DateTimeKind.Utc).AddTicks(5768));

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
    }
}
