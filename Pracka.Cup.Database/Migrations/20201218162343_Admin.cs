using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pracka.Cup.Database.Migrations
{
    public partial class Admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedUTC", "FirstName", "LastName", "ModifiedUTC", "Nickname", "SelectedTeamId" },
                values: new object[] { new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Main", "Administrator", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Admin", 1 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedUTC", "ModifiedUTC" },
                values: new object[] { new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedUTC", "ModifiedUTC", "SelectedTeamId" },
                values: new object[] { new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CreatedUTC", "FirstName", "LastName", "ModifiedUTC", "Nickname", "SelectedTeamId" },
                values: new object[] { 4, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Player", "3", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Player3", 3 });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedUTC", "Icon", "ModifiedUTC", "Name" },
                values: new object[] { new DateTime(2020, 12, 18, 16, 23, 43, 374, DateTimeKind.Utc).AddTicks(323), "BUFFALO_SABRES", new DateTime(2020, 12, 18, 16, 23, 43, 375, DateTimeKind.Utc).AddTicks(6564), "Buffalo" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedUTC", "Icon", "ModifiedUTC", "Name" },
                values: new object[] { new DateTime(2020, 12, 18, 16, 23, 43, 375, DateTimeKind.Utc).AddTicks(7652), "BOSTON_BRUINS", new DateTime(2020, 12, 18, 16, 23, 43, 375, DateTimeKind.Utc).AddTicks(7670), "Boston" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedUTC", "ModifiedUTC" },
                values: new object[] { new DateTime(2020, 12, 18, 16, 23, 43, 375, DateTimeKind.Utc).AddTicks(7690), new DateTime(2020, 12, 18, 16, 23, 43, 375, DateTimeKind.Utc).AddTicks(7693) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedUTC", "FirstName", "LastName", "ModifiedUTC", "Nickname", "SelectedTeamId" },
                values: new object[] { new DateTime(2020, 12, 18, 12, 39, 22, 280, DateTimeKind.Utc).AddTicks(5754), "Player", "1", new DateTime(2020, 12, 18, 12, 39, 22, 280, DateTimeKind.Utc).AddTicks(5758), "Player1", 2 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedUTC", "ModifiedUTC" },
                values: new object[] { new DateTime(2020, 12, 18, 12, 39, 22, 280, DateTimeKind.Utc).AddTicks(6060), new DateTime(2020, 12, 18, 12, 39, 22, 280, DateTimeKind.Utc).AddTicks(6063) });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedUTC", "ModifiedUTC", "SelectedTeamId" },
                values: new object[] { new DateTime(2020, 12, 18, 12, 39, 22, 280, DateTimeKind.Utc).AddTicks(6070), new DateTime(2020, 12, 18, 12, 39, 22, 280, DateTimeKind.Utc).AddTicks(6071), 3 });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedUTC", "Icon", "ModifiedUTC", "Name" },
                values: new object[] { new DateTime(2020, 12, 18, 12, 39, 22, 275, DateTimeKind.Utc).AddTicks(4330), "BOSTON_BRUINS", new DateTime(2020, 12, 18, 12, 39, 22, 276, DateTimeKind.Utc).AddTicks(9734), "Boston" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedUTC", "Icon", "ModifiedUTC", "Name" },
                values: new object[] { new DateTime(2020, 12, 18, 12, 39, 22, 277, DateTimeKind.Utc).AddTicks(743), "BUFFALO_SABRES", new DateTime(2020, 12, 18, 12, 39, 22, 277, DateTimeKind.Utc).AddTicks(760), "Buffalo" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedUTC", "ModifiedUTC" },
                values: new object[] { new DateTime(2020, 12, 18, 12, 39, 22, 277, DateTimeKind.Utc).AddTicks(778), new DateTime(2020, 12, 18, 12, 39, 22, 277, DateTimeKind.Utc).AddTicks(780) });
        }
    }
}
